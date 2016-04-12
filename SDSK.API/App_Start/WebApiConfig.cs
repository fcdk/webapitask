﻿using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using log4net.Config;
using Swashbuckle.Application;

namespace SDSK.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "A title for your API");
                    c.IncludeXmlComments("SDSK.API.XML");
                })
                .EnableSwaggerUi(c =>
                {
                    c.DocExpansion(DocExpansion.Full);
                });

            BasicConfigurator.Configure();
            config.Services.Add(typeof(IExceptionLogger), new ExceptionLogger());

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
