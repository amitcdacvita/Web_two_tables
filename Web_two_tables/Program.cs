
using Microsoft.EntityFrameworkCore;
using Web_two_tables.Models.WebAPITwoTable.Models;
using Web_two_tables.Models;
using WebAPITwoTable.Models;

namespace WebAPITwoTable
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var b = builder.Configuration.GetConnectionString("BookDatabase");
            builder.Services.AddDbContextPool<AppdbContext>((op) => op.UseSqlServer(b));
            builder.Services.AddTransient<IBookinterface, SQLBookRepository>();
            builder.Services.AddTransient<IAuthorinterface, SQLAuthorRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
