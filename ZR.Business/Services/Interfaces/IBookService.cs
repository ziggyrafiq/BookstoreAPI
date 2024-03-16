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
using ZR.Infrastructure.Dto;
using ZR.Infrastructure.Models;

namespace ZR.Business.Services.Interfaces
{
    public interface IBookService : IService
    {
        Task<List<Book>> AsyncGetAll(string? sortBy);
        List<Book> GetAll(string? sortBy);

        Task<Book> AsyncGetById(long? id);
        Book GetById(long? id);

        Task<BookDto> AsyncAdd(BookDto model);
        BookDto Add(BookDto model);
        Task<BookDto> AsyncUpdate(BookDto model);
        BookDto Update(BookDto model);
    }
}
