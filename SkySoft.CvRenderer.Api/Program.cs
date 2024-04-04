using Microsoft.AspNetCore.Server.Kestrel.Core;
using Newtonsoft.Json.Converters;
using SkySoft.CvRenderer.Api.Services;
using SkySoft.CvRenderer.Models;
using SkySoft.CvRenderer.Utils.Deserialization;
using SkySoft.CvRenderer.Utils.JsonHelpers;
using System.Net;

namespace SkySoft.CvRenderer.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.Listen(IPAddress.Any, 5000, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http2;
                });

                //options.Listen(IPAddress.Any, 5199);

                //options.Listen(IPAddress.Any, 7236);
            });

            builder.Services.AddGrpc();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<CvCreator>();
            builder.Services.AddTransient<Deserializer>();

            builder.Services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.Converters.Add(new MultiFormatDateConverter());
            });

            builder.Services.Configure<CvOptions>(builder.Configuration.GetSection(nameof(CvOptions)));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.MapGrpcService<GreeterService>();

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
