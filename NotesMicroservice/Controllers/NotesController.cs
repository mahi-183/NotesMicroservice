using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessManager.Interface;
using CommanLayer.Enumerable;
using CommanLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NotesMicroservice.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        //create reference of businessLayer method
        public IBusinessManager businessManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class.
        /// </summary>
        /// <param name="businessManager">The business manager.</param>
        public NotesController(IBusinessManager businessManager)
        {
            this.businessManager = businessManager;
        }     
        
        // POST: api/Notes
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddNotes( NotesModel notesModel)
        {
            try
            {
                //BusinessLayer method call
                var result = await this.businessManager.AddNotes(notesModel);
                
                //if result is null then it throw the error message 
                if (!result.Equals(null))
                {
                    return Ok(new { result });
                }
                else
                {
                    return BadRequest(new { Message = "Notes not added"});
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("notes")]
        public IList<NotesModel> GetAllNotes()
        {
            try
            {
                //BusinessLayer method call
                var result = this.businessManager.GetAllNotes();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetNotes")]
        public IList<NotesModel> GetNotesById(string userId, NoteTypeEnum noteType)
        {
            try
            {
                //BusinessLayer method call
                var result = this.businessManager.GetNotesById(userId, noteType);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateNotes")]
        public async Task<int> UpdateNotes(NotesModel notesModel, int id)
        {
            try
            {
                //BusinessLayer method call
                var result =await this.businessManager.UpdateNotes(notesModel, id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        [HttpPost]
        [Route("DeleteNotes")]
        public async Task<int> DeleteNotes(int id)
        {
            try
            {
                //BusinessLayer method call
                var result = await this.businessManager.DeleteNotes(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("UploadImage")]
        public async Task<IActionResult> ImageUpload(IFormFile formFile, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);   // This is the line that causes the intellisense error
                }

                //BusinessLayer method call
                var ImageUrl = await this.businessManager.ImageUpload(formFile, id);
                
                //if the imageurl is null then it 
                if (!ImageUrl.Equals(null))
                {
                    return this.Ok(new { ImageUrl });
                }
                else
                {
                    return this.NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("Reminder")]
        public IActionResult Reminder(int noteId)
        {
            try
            {
                //BusinessLager method call
                var result = this.businessManager.Reminder(noteId);
                
                //if result null then return result NotFount message
                if (!result.Equals(null))
                {
                    return this.Ok(new { result });
                }
                else
                {
                    return this.NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("Pin")]
        public IActionResult IsPin(int noteId)
        {
            try
            {
                //BusinessLayer method call
                var result = this.businessManager.IsPin(noteId);
                if (!result.Equals(null))
                {
                    //return result
                    return this.Ok(new { result });
                }
                else
                {
                    return BadRequest(new { message = "Not pined" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetNoteType")]
        public IActionResult GetNoteType(NoteTypeEnum NoteType)
        {
            try
            {
                //BusinessLayer method call
                var result = this.businessManager.GetNoteType(NoteType);
                if (!result.Equals(null))
                {
                    return this.Ok(new { result });
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        [HttpPost]
        [Route("AddCollaborator")]
        public async Task<IActionResult> AddCollabarator(CollaboratorModel collaboratorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ////BusinessManager Layer method call
                    var result = await this.businessManager.AddCollaborator(collaboratorModel);

                    ///return the success result
                    return this.Ok(new { result });
                }
                else
                {
                    ////return the failer result
                    return BadRequest(new { message = "data is not valid" });
                }
            }
            catch (Exception ex)
            {
                ////if exception occure then throw exceptions
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetCollaborator")]
        public async Task<IActionResult> GetCollaborator(string email)
        {
            try
            {
                if (!email.Equals(null))
                {
                    ////BusinessManager layer method call
                    var result = await this.businessManager.GetCollborators(email);
                    if (!result.Equals(null))
                    {
                        ////return the result.
                        return this.Ok(new { result });
                    }
                    else
                    {
                        return BadRequest(new { message = "The collaborator not get" });
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
