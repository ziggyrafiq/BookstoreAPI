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
using ZR.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZR.Infrastructure.Data
{
    public class BookSeeding : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData
           (
                new Book()
                {
                    Id = 1,
                    Author = "A.A. Milne",
                    Title = "Winnie-the-Pooh",
                    Price = Convert.ToDecimal(19.25)
                },
                new Book
                {
                    Id = 2,
                    Author = "Jane Austen",
                    Title = "Pride and Prejudice",
                    Price = Convert.ToDecimal(5.49)
                },
                new Book
                {
                    Id = 3,
                    Author = "William Shakespeare",
                    Title = "Romeo and Juliet",
                    Price = Convert.ToDecimal(6.95)
                }
            );



        }
    }
}
