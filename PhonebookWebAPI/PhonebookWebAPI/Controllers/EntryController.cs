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
    public class EntryController : ApiController
    {
        private EntriesRepository _repository;

        public EntryController(EntriesRepository repository)
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

        public IHttpActionResult Post(Entry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(entry);
            return Created(Url.Link("DefaultApi",
                new { controller = "Entry", id = entry.Id }), entry);
        }

        public IHttpActionResult Put(Entry entry, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repository.Update(entry);
            return StatusCode(HttpStatusCode.NoContent);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
