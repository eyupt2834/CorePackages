using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.SeriLog;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Core.Application.Pipelines.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ILoggableRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggingBehavior(IHttpContextAccessor httpContextAccessor, LoggerServiceBase logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _loggerServiceBase = logger;
        }

        private readonly LoggerServiceBase _loggerServiceBase;
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            List<LogParameter> logParameters = new List<LogParameter>
            {
                 new LogParameter{Type = request.GetType().Name,Value = request }
            };
            LogDetail logDetail = new LogDetail
            {
                MethodName = next.Method.Name,
                Parameters = logParameters,
                User = _httpContextAccessor.HttpContext.User.Identity.Name ?? "?"
            };

            _loggerServiceBase.Info(JsonSerializer.Serialize(logDetail));

            return await next();

        }
    }
}



