using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhonebookWebAPI.Data;
using PhonebookWebAPI.Models;

namespace PhonebookWebAPI.Controllers
{
    public class PhonebookController : ApiController
    {
        private PhonebookRepository _repository;

        public PhonebookController(PhonebookRepository repository)
        {
            _repository = repository;
        }

        public IHttpActionResult Get()
        {
            return Ok(_repository.GetList());
        }

        public IHttpActionResult Get(int id)
        {
            var entry = _repository.Get(id);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(_repository.Get(id));
        }

        public IHttpActionResult Post(Phonebook model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repository.Add(model);
            return Created(Url.Link("DefaultApi",
                new { controller = "Phonebook", id = model.Id }), model);
        }

        public IHttpActionResult Put(Phonebook model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repository.Update(model);
            return StatusCode(HttpStatusCode.NoContent);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
