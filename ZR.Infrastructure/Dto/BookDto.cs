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
namespace ZR.Infrastructure.Dto
{

    public class BookDto
    {

        public long? Id { get; set; }

        public string Title { get; set; } = string.Empty;


        public string Author { get; set; } = string.Empty;

        public decimal? Price { get; set; }

    }

}
