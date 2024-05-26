namespace Rest_Api_DBfirst.Middlewares;

public class ErrorHandlingMiddleWare : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            context.Response.StatusCode = 404;
        }
    }
}