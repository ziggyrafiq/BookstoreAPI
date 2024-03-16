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

using ZR.Infrastructure.Repositories;
using ZR.Infrastructure.Entities;
using ZR.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;


namespace ZR.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private DbEntities _Context;


        #region -- Constructor(s) --

        public UnitOfWork()
        {
            try
            {
                _Context = new DbEntities();

            }
            catch (Exception ex)
            {
                string? ahh = "Ahhhhhh! Exception Message: " + ex.Message;

            }
        }

        public DbEntities Context => _Context;

        public void RefreshConnection()
        {
            _Context.Dispose();
            _Context = new DbEntities();
        }

        #endregion




        #region --  Unfiltered Repositoires  --

        public Dictionary<Type, object> _Repositories = new Dictionary<Type, object>();


        public GenericRepository<TEntity>? Repository<TEntity>() where TEntity : Book
        {
            // Check to see if we have a constructor for the given type
            if (!_Repositories.ContainsKey(typeof(TEntity)))
            {

                _Repositories.Add(typeof(TEntity), new GenericRepository<TEntity>(_Context, o => o.Title != null));

            }
            return _Repositories[typeof(TEntity)] as GenericRepository<TEntity>;
        }

        #endregion

        public void Save()
        {
            _Context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _Context.SaveChangesAsync();

        }

        private bool _Disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_Disposed)
            {
                if (disposing && _Context != null)
                {
                    _Context.Dispose();
                }
            }
            _Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
