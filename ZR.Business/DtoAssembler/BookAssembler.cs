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

namespace ZR.Business.DtoAssembler
{
    public class BookAssembler
    {
        public static Book BookWriteToModelFromDto(BookDto modelDto)
        {            
            Book? book = new Book()
            {

                Id = Convert.ToInt64(modelDto.Id),
                Title = modelDto.Title,
                Author = modelDto.Author,
                Price = modelDto.Price

            };

            return book;
        }
    }
}
