using Library.Application.Services.Intercafes;
using Library.Domain.Dto;
using Library.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Library.Api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookControllers : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookControllers(IBookService bookService)
        {
            _bookService = bookService;
        }

        //[HttpGet]
        //[Route("Get/{id:guid}")]
        //public IActionResult GetById(Guid id)
        //{
        //    try
        //    {
        //        var result = _repository.GetById(id);
        //        if (result != null)
        //            return Ok(result);

        //        return NotFound();
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, e);
        //    }
        //}

        [HttpGet]
        [AllowAnonymous]
        [Route("list-all")]
        public IActionResult Index()
        {
            try
            {
                var result = _bookService.GetAll();
                if (result != null)
                    return Ok(result);

                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("post")]
        public IActionResult Create([FromBody]BookDto dto)
        {
            try
            {
                _bookService.Add(dto);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                //var result = _service.GetById(id);
                //if (result != null)
                //    return Ok(result);

                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}