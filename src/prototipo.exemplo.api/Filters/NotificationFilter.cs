using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using Prototipo.Exemplo.Domain._Shared.Notifications;

namespace Prototipo.Exemplo.Api.Filters;

public class NotificationFilter : IAsyncResultFilter
{
    private readonly INotificationContext _notificationContext;
    public NotificationFilter(INotificationContext notificationContext)
    {
        _notificationContext = notificationContext;
    }

    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (_notificationContext.HasNotifications)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.HttpContext.Response.ContentType = "application/json";

            var erros = new { errors = _notificationContext.Notifications };

            var notifications = JsonSerializer.Serialize(erros);
            await context.HttpContext.Response.WriteAsync(notifications);

            return;
        }

        await next();
    }
}