namespace MyProjectBackend.Startup;

public static class MiddelwareBuilder
{
    public static void BuildApp(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}