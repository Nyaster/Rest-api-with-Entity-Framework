using Rest_Api_DBfirst.Errors;

namespace Rest_Api_DBfirst.Middlewares;

public class ErrorHandlingMiddleWare : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ClientTripsException e)
        {
            Console.WriteLine(e);
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync("Client arleady have trip, delete this first");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            context.Response.StatusCode= 404;
        }
    }
}