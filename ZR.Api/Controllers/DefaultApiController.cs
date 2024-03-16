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
using ZR.Api.Attributes;
using ZR.Api.Extensions;
using ZR.Business.Services.Interfaces;
using ZR.Infrastructure.Dto;
using ZR.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ZR.Api.Controllers
{
    [ApiController]
    public class DefaultApiController : BaseApiController
    {


        private readonly ILoggerManagerService _logger;

        public DefaultApiController(ILoggerManagerService loggerManagerService)
        {
            _logger = loggerManagerService;

        }


        /// <summary>
        /// Creates a new book
        /// </summary>
        /// <description>Hello World</description>
        /// <param name="body">A JSON object that represents a book.</param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        [Route("//books")]
        [ValidateModelState]
        [SwaggerOperation("CreateBook")]
        [SwaggerResponse(statusCode: 201, type: typeof(InlineResponse201), description: "Created")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        public virtual IActionResult CreateBook([FromBody] BookDto body)
        {

            BookDto? data = _Services.Service<IBookService>().Add(body);

            _logger.LogInfo("return a list of books");
            return Ok(data);
        }


        /// <summary>
        /// Deletes a book by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        /// <response code="404">Book not found</response>
        [HttpDelete]
        [Route("//books/{id}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteBookById")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Book>), description: "Success")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(List<Book>), description: "Internal Error")]
        public virtual IActionResult DeleteBookById([FromRoute][Required] long? id)
        {
           
            _Services.Service<IBookService>().Delete(id);
            _logger.LogInfo($"return a book ID {id}");
            return Ok();
        }

        /// <summary>
        /// Returns a list of books. Sorted by title by default.
        /// </summary>
        /// <param name="sortby">
        ///  value="title",
        ///  value="author",
        ///  value="price"
        /// </param>
        /// <response code="200">Return a List of Books order by Title by default/response>
        /// <response code="404">Book not found</response>
        /// <response code="500">Internal Error</response>
        [HttpGet]
        [Route("//books")]
        [ValidateModelState]
        [SwaggerOperation("GetBook")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Book>), description: "Success")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(List<Book>), description: "Internal Error")]
        public virtual IActionResult GetBook([FromQuery] string? sortby)
        {

            Book[]? data = _Services.Service<IBookService>().GetAll(sortby).ToArray();


            return StatusCode(200, data);

        }

        /// <summary>
        /// Gets a book by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        /// <response code="404">Book not found</response>
        [HttpGet]
        [Route("//books/{id}")]
        [ValidateModelState]
        [SwaggerOperation("GetBookById")]
        [SwaggerResponse(statusCode: 200, type: typeof(Book), description: "Success")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        public virtual IActionResult GetBookById([FromRoute][Required] long? id)
        {

            Book? data = _Services.Service<IBookService>().GetById(id);
            _logger.LogInfo($"return a book ID {id}");
            return Ok(data);
        }

        /// <summary>
        /// Update an existing book
        /// </summary>
        /// <param name="body">A JSON object that represents a book.</param>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Book not found</response>
        [HttpPut]
        [Route("//books/{id}")]
        [ValidateModelState]
        [SwaggerOperation("UpdateBookById")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        public virtual IActionResult UpdateBookById([FromBody] BookDto body, [FromRoute][Required] long? id)
        {
            BookDto? data = _Services.Service<IBookService>().Update(body);

            _logger.LogInfo($"Updating a book ID {body.Id}");
            return Ok(data);
        }

       
    }
}
