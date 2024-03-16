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
using ZR.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ZR.Api.Extensions.Services
{
    public static class SqlContextServiceExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbEntities>(
              options =>
                  options.UseSqlServer(
                      configuration.GetConnectionString("DefaultConnection"),
                      x => x.MigrationsAssembly("ZR.Infrastructure.Migrations")));


        }
    }
}
