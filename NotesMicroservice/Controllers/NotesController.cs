using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessManager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NotesMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        public IBusinessManager businessManager;

        public NotesController(IBusinessManager businessManager)
        {
            this.businessManager = businessManager;
        }

        // GET: api/Notes
        [HttpGet]
        //public IList<NotesModule> Get(int id)
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Notes/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Notes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Notes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
