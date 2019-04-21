using Library.Application.Services.Intercafes;
using Library.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Library.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/books")]
    [ApiController]
    public class BookControllers : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookControllers(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("get/{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var result = _bookService.GetById(id);
                if (result != null)
                    return Ok(result);

                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet]
        [DisableCors]
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
        [Route("delete/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _bookService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody]BookDto dto)
        {
            try
            {
                _bookService.Update(dto);
                 return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}