using Newtonsoft.Json.Converters;
using SkySoft.CvRenderer.Utils.Api;
using SkySoft.CvRenderer.Utils.JsonHelpers;

namespace SkySoft.CvRenderer.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<CreateCvFromModel>();
            builder.Services.AddTransient<CreateCvFromFile>();

            builder.Services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.Converters.Add(new MultiFormatDateConverter());
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
