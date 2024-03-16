/************************************************************************************************************
*  COPYRIGHT BY ZIGGY RAFIQ (ZAHEER RAFIQ)
*  LinkedIn Profile URL Address: https://www.linkedin.com/in/ziggyrafiq/ 
*
*  System   :  	ZR Demo Project 01 - Book Api
*  Date     :  	20/09/2022
*  Author   :  	Ziggy Rafiq (https://www.ziggyrafiq.com)
*  Notes    :  	
*  Reminder :	PLEASE DO NOT CHANGE OR REMOVE AUTHOR NAME.
*
************************************************************************************************************/
using FluentValidation;
using ZR.Infrastructure.Models;

using System.Reflection;

namespace ZR.Api.Extensions.Services
{
    public static class SwaggerServiceExtension
    {
        public static void ConfigureSwagger(this IServiceCollection service)
        {

            

            service.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "ZR Demo Project 01 - Book Api",
                    Description = "RESTful api that manages a collection of books in a fictional store using .Net 6",
                    Version = "v1"


                });


                string? xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string? xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });
        }
    }
}
