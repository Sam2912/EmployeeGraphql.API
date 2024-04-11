namespace EmployeeGraphql.API.Extensions
{
    public static class AppExtensions
    {
        public static void UseCustomEndpoints(this IApplicationBuilder app, IHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                // app.UseSwagger();
                // app.UseSwaggerUI();
            }
        }
    }

}