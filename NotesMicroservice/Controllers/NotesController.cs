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
            try
            {
                var result = this.businessManager.AddNotes(notesModel);
                if (!result.Equals(null))
                {
                    return Ok(new { result });
                }
                else
                {
                    return BadRequest();
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
        public IList<NotesModel> GetNotesById(string UserId)
        {
            try
            {
                var result = this.businessManager.GetNotesById(UserId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateNotes")]
        public async Task<int> UpdateNotes(NotesModel notesModel, string UserId)
        {
            try
            {
                var result =await this.businessManager.UpdateNotes(notesModel, UserId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        [HttpPost]
        [Route("DeleteNotes")]
        public async Task<int> DeleteNotes(string UserId)
        {
            try
            {
                var result = await this.businessManager.DeleteNotes(UserId);
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
                var ImageUrl = await this.businessManager.ImageUpload(formFile, id);
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
                var result = this.businessManager.Reminder(noteId);
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
                var result = this.businessManager.IsPin(noteId);
                if (!result.Equals(null))
                {
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

    }
}
