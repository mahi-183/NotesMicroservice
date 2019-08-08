using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessManager.Interface;
using CommanLayer.Model;
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

       

        // POST: api/Notes
        [HttpPost]
        [Route("Add")]
        public IActionResult AddNotes( NotesModel notesModel)
        {
            var result =this.businessManager.AddNotes(notesModel);
            if (result != null)
            {
                return this.Ok(new { result });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
