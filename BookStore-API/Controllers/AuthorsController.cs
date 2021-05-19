using AutoMapper;
using BookStore_API.Contracts;
using BookStore_API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_API.Controllers
{
    /// <summary>
    /// Endpoint used to interact with the authors in the bookstore database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public AuthorsController(IAuthorRepository authorRepositor,
            ILoggerService logger,
            IMapper mapper)
        {
            _authorRepository = authorRepositor;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all authors
        /// </summary>
        /// <returns> list of authors</returns>
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            try
            {
                _logger.LogInfo("Attempted: Get All Authors");

                var authors = await _authorRepository.FindAll();
                //maps a list of authors to the author DTO
                var response = _mapper.Map<List<AuthorDTO>>(authors);
                _logger.LogInfo("Successfully got all authors");
                return Ok(response);
            }
            catch (Exception e)
            {
               return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An author by id number</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            try
            {
                _logger.LogInfo($"Attempted to get author with id:{id}");
                var author = await _authorRepository.FindById(id);
                if(author == null)
                {
                    _logger.LogWarn($"Author not found with id:{id}");
                    return NotFound();
                }
                var response = _mapper.Map<AuthorDTO>(author);
                _logger.LogInfo($"Got author with id:{id}");

                return Ok(response);
            }
            catch (Exception e)
            {
               return InternalError($"{e.Message} - {e.InnerException}");
            }
        }





        private ObjectResult InternalError(string message)
        {
            _logger.LogError(message);
            return StatusCode(500, "Something went wrong, please contact System Admin");
        }


    }   
}
