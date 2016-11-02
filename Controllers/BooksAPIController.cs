using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyRestAPI.Models;

namespace MyRestAPI.Controllers
{
    [Route("api/[controller]")]
    public class BooksAPIController : Controller
    {
        public IBooksRepository _booksRepository { get; set; }
        public BooksAPIController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public IEnumerable<Books> GetAll()
        {
            return _booksRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetBooks")]
        public IActionResult GetById(string id)
        {
            var item = _booksRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Books item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _booksRepository.Add(item);
            return CreatedAtRoute("GetBooks", new { id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Books item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var todo = _booksRepository.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _booksRepository.Update(item);
            return new NoContentResult();
        }
    }
}
