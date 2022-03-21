using Microsoft.OpenApi.Models;

namespace OrderService.Services.API.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwagerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Orders Service",
                    Description = "Orders Service API Management",
                    Contact = new OpenApiContact { Name = "Leonardo", Email = "leonardo@blabla.com.br" }
                });
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }
        }
    }
}
