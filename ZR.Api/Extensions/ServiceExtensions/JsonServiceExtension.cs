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

using Newtonsoft.Json.Converters;

namespace ZR.Api.Extensions.Services
{
    public static class JsonService
    {
        public static void ConfigureJson(this IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson(options =>
   // options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
   options.SerializerSettings.Converters.Add(new StringEnumConverter())
);
        }
    }
}
