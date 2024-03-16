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
using ZR.Infrastructure.UnitOfWork;
using ZR.Business.Services.Interfaces;

namespace ZR.Business.Services
{
    public static class ServiceFactory
    {
        // List of service constructors accessible from their interface types to cover the DI + IOC
        private static readonly Dictionary<Type, Func<UnitOfWork, IService>> _Services =
            new Dictionary<Type, Func<UnitOfWork, IService>> {


            { typeof(IBookService), (uow) => { return new BookService(uow); ; } }
            };



        public static T GetService<T>(UnitOfWork unitOfWork) where T : IService
        {

            if (!_Services.ContainsKey(typeof(T)))
            {
                throw new ArgumentOutOfRangeException("Object of type '" + typeof(T).ToString() + "' is not declared for construction with this factory.");

            }


            return (T)_Services[typeof(T)](unitOfWork);
        }


        public static T GetUnauthorisedService<T>() where T : IService
        {
            return GetService<T>(new UnitOfWork());
        }

    }
}
