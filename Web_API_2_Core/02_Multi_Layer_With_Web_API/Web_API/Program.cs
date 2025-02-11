using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.MyDependecyInjection;
using Services.MyMappingProfile;


namespace Web_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MultiLayer"));
            });



            // here add automapper dependency

            builder.Services.AddAutoMapper(typeof(MyMappingProfile));


            // add mulitple in this file
            MydependencyRegister.RegisterDependencies(builder.Services);    


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
