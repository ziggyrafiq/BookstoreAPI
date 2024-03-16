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
    public class ServiceManager : IDisposable
    {

        private UnitOfWork _UnitOfWork;
        private readonly Dictionary<Type, IService> _Services = new Dictionary<Type, IService>();


        public ServiceManager()
        {
            _UnitOfWork = new UnitOfWork();
        }




        public void RefreshConnection()
        {
            _UnitOfWork.RefreshConnection();


            _UnitOfWork = new UnitOfWork();

            _Services.Clear();
        }
        public int Services => _Services.Count;



        public T Service<T>() where T : IService
        {
            if (_Services.ContainsKey(typeof(T)))
            {
                return (T)_Services[typeof(T)];
            }

            T? service = ServiceFactory.GetService<T>(_UnitOfWork);
            _Services.Add(typeof(T), service);
            return service;
        }


        public void Remove<T>() where T : IService
        {
            if (_Services.ContainsKey(typeof(T)))
            {
                _Services[typeof(T)].Dispose();
                _Services.Remove(typeof(T));
            }
        }

        public void Dispose()
        {

            foreach (KeyValuePair<Type, IService> service in _Services)
            {
                service.Value.Dispose();
            }


            _Services.Clear();


            _UnitOfWork.Dispose();
        }
    }
}
