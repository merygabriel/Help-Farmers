using FarmerApp.Shared.Exceptions;
using System.Net;

namespace FarmerApp.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ExceptionHandlingMiddleware> logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                logger.LogError(error, error.Message);

                var response = context.Response;
                response.ContentType = "text";

                switch (error)
                {
                    case NotFoundException:
                        {
                            response.StatusCode = (int)HttpStatusCode.NotFound;
                            break;
                        }
                    case BadHttpRequestException:
                        {
                            response.StatusCode = (int)HttpStatusCode.BadRequest;
                            break;
                        }
                    case BadRequestException:
                        {
                            response.StatusCode = (int)HttpStatusCode.BadRequest;
                            break;
                        }
                    case UnauthorizedAccessException:
                        {
                            response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            break;
                        }
                    case AccessDeniedException:
                        {
                            response.StatusCode = (int)HttpStatusCode.Forbidden;
                            break;
                        }
                    case DbConcurrencyException e:
                        {
                            response.StatusCode = (int)HttpStatusCode.Conflict;
                            break;
                        }
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                await response.WriteAsync(error.Message);
            }
        }
    }
}
