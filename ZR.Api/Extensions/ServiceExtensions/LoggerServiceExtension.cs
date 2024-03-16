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
using ZR.Business.Services;
using ZR.Business.Services.Interfaces;

namespace ZR.Api.Extensions.Services
{
    public static class LoggerServiceExtension
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {

            services.AddSingleton<ILoggerManagerService, LoggerManagerService>();
        }
    }
}
