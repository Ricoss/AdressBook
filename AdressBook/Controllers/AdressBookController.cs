using AdressBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace AdressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressBookController : ControllerBase
    {
        private readonly ILogger<AdressBookController> _logger;

        public AdressBookController(ILogger<AdressBookController> logger)
        {
            _logger = logger;
        }
        // POST api/<AdressBook>
        [HttpPost]
        public ActionResult Post([FromBody] Adress adressBook)
        {
            try
            {
                Data.List.Add(adressBook);
                var message = $"Add {adressBook.Name}, {adressBook.UserName}, {adressBook.City}";
                _logger.LogInformation(message);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);

            }
        }

        // GET: api/<AdressBook>
        [HttpGet]
        public ActionResult Get()
        {  
            var result = Data.List.LastOrDefault();
            var message = "The last city added was read";
            _logger.LogInformation(message);
            return result is not null ? Ok(result) : NotFound("Lack");
        }

        [HttpGet("{miasto}")]
        public ActionResult Get(string miasto)
        {
            var query = Data.List.Where(x => miasto == x.City).ToList();
            var message = $"Select {miasto}";
            _logger.LogInformation(message);
            return query.Count() != 0 ? Ok(query) : NotFound("Lack");
        }
    }
}
