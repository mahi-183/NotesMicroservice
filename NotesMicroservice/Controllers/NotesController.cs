using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessManager.Interface;
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
    }
}
