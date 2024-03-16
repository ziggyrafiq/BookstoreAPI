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
using ZR.Business.DtoAssembler;
using ZR.Business.Services.Interfaces;
using ZR.Infrastructure.Dto;
using ZR.Infrastructure.Models;


namespace ZR.Business.Services
{
    public class BookService : IBookService
    {
        private readonly UnitOfWork _UnitOfWork;

        public BookService(UnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("UnitOfWork is missign or UnitOfWork Error!");
            }

            _UnitOfWork = unitOfWork;

        }

        public async Task<List<Book>> AsyncGetAll(string? sortBy)
        {
            var book = _UnitOfWork.Repository<Book>().Get();

            switch (sortBy)
            {
                case "price":
                    book = book.OrderBy(x => x.Price);
                    break;
                case "title":
                    book = book.OrderBy(x => x.Title);
                    break;
                case "author":
                    book = book.OrderBy(x => x.Author);
                    break;
                default:
                    book = book.OrderBy(x => x.Title);
                    break;
            }
                       
            return await Task.Run(() => book.ToList() );
        }

        public List<Book> GetAll(string? sortBy)
        {
            var book = _UnitOfWork.Repository<Book>().Get();

            switch (sortBy)
            {
                case "price": 
                    book = book.OrderBy(x => x.Price);
                    break;
                case "title":
                    book = book.OrderBy(x => x.Title);
                    break;
                case "author":
                    book = book.OrderBy(x => x.Author);
                    break;
                default:
                    book = book.OrderBy(x => x.Title);
                    break;
            }

            return book.ToList();
                 
        }



        public async Task<Book> AsyncGetById(long? id)
        {

            return await Task.Run(()=>_UnitOfWork.Repository<Book>().AsyncGetByID(id));
        }

        public Book GetById(long? id)
        {

            return _UnitOfWork.Repository<Book>().GetByID(id);
        }


        public async Task<BookDto> AsyncAdd(BookDto model)
        {
            await _UnitOfWork.Repository<Book>().AsyncInsert(BookAssembler.BookWriteToModelFromDto(model));
            await _UnitOfWork.SaveAsync();
            return model;
        }

        public BookDto Add(BookDto model)
        {
            _UnitOfWork.Repository<Book>().Insert(BookAssembler.BookWriteToModelFromDto(model));
            _UnitOfWork.Save();
            return model;
        }


        public async Task<BookDto> AsyncUpdate(BookDto model)
        {
            await _UnitOfWork.Repository<Book>().AsyncUpdate(BookAssembler.BookWriteToModelFromDto(model));
            await _UnitOfWork.SaveAsync();

            return model;
        }

        public BookDto Update(BookDto model)
        {
            _UnitOfWork.Repository<Book>().Update(BookAssembler.BookWriteToModelFromDto(model));

            _UnitOfWork.Save();

            return model;
        }


        public async Task AsyncDelete(long? id)
        {
            await _UnitOfWork.Repository<Book>().AsyncDelete(id);

            await _UnitOfWork.SaveAsync();
        }

        public virtual void Delete(long? id)
        {
            _UnitOfWork.Repository<Book>().Delete(id);
            _UnitOfWork.Save();
        }



        public void Dispose()
        {
            _UnitOfWork.Dispose();
            GC.Collect(); ;
        }
    }
}
