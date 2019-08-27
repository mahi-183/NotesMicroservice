﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesController.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------
namespace NotesMicroservice.Controllers
{
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
    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        ////create reference of businessLayer method
        public IBusinessManager businessManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class.
        /// </summary>
        /// <param name="businessManager">The business manager.</param>
        public NotesController(IBusinessManager businessManager)
        {
            this.businessManager = businessManager;
        }     
        
        /// <summary>
        /// Add notes.
        /// </summary>
        /// <param name="notesModel">notes model.</param>
        /// <returns>return the result.</returns>
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddNotes(NotesModel notesModel)
        {
            try
            {
                ////BusinessLayer method call
                var result = await this.businessManager.AddNotes(notesModel);
                
                ////if result is null then it throw the error message 
                if (!result.Equals(null))
                {
                    return this.Ok(new { result });
                }
                else
                {
                    return this.BadRequest(new { Message = "Notes not added" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Get all notes.
        /// </summary>
        /// <returns>return the list of all notes</returns>
        [HttpGet]
        [Route("notes")]
        public IList<NotesModel> GetAllNotes()
        {
            try
            {
                ////BusinessLayer method call
                var result = this.businessManager.GetAllNotes();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get the notes by user id and note type.
        /// </summary>
        /// <param name="userId">user id.</param>
        /// <param name="noteType">note id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetNotes")]
        public IList<NotesModel> GetNotesById(string userId, NoteTypeEnum noteType)
        {
            try
            {
                ////check the user id and note type is not null
                if(!userId.Equals(null) && !noteType.Equals(null))
                {
                    ////BusinessLayer method call
                    var result = this.businessManager.GetNotesById(userId, noteType);
                    ////check 
                    if (!result.Equals(null))
                    {
                        ////return the all notes.
                        return result;
                    }
                    else
                    {
                        ////throw the exception
                        throw new Exception("The data was not fetched successfuly");
                    }
                }
                else
                {
                    ////throw the exception
                    throw new Exception("user id or note type are invalid");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get the notes by user id from the user microservice.
        /// </summary>
        /// <param name="userId">user id.</param>
        /// <returns>return the result.</returns>
        [HttpGet]
        [Route("GetNotesById")]
        public IList<NotesModel> GetNotesByUserId(string userId)
        {
            try
            {
                if (!userId.Equals(null))
                {
                    ////BusinessLayer method call
                    var result = this.businessManager.GetNotesByUserId(userId);
                    if (!result.Equals(null))
                    {
                        return result;
                    }
                    else
                    {
                        throw new Exception("The data not fetched");
                    }
                }
                else
                {
                    throw new Exception("The user id is not valid");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// update the notes.
        /// </summary>
        /// <param name="notesModel">notes model.</param>
        /// <param name="id">notes id.</param>
        /// <returns>return the result.</returns>
        [HttpPost]
        [Route("UpdateNotes")]
        public async Task<IActionResult> UpdateNotes(NotesModel notesModel, int id)
        {
            try
            {
                if (!notesModel.Equals(null) && !id.Equals(null))
                {
                    ////BusinessLayer method call
                    var result = await this.businessManager.UpdateNotes(notesModel, id);
                    ////check the result is not null
                    if (!result.Equals(null))
                    {
                        ////return the success result.
                        return this.Ok(new { result });
                    }
                    else
                    {
                        ////throw the exception message
                        return this.BadRequest(new { Message = "The notes are not successfuly updated" });
                    }
                }
                else
                {
                    ////throw the exception message
                    return this.BadRequest(new { Message = "The note model or note id is invalid" });
                }
            }
            catch (Exception ex)
            {
                ////throw the exception message
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Delete the notes by note id.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>return the result.</returns>
        [HttpPost]
        [Route("DeleteNotes")]
        public async Task<IActionResult> DeleteNotes(int id)
        {
            try
            {
                if (id.Equals(null))
                {
                    ////BusinessLayer method call
                    var result = await this.businessManager.DeleteNotes(id);
                    if (result.Equals(null))
                    {
                        return this.Ok(new { result });
                    }
                    else
                    {
                        ////return the bad result.
                        return this.BadRequest(new { Message = "The notes are not deleted the succussfuly" });
                    }
                }
                else
                {
                    ////return the 
                    return this.BadRequest(new { Message = "The note id is invalid" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Upload the image on cloudinary.
        /// </summary>
        /// <param name="formFile">image file</param>
        /// <param name="id">note id.</param>
        /// <returns>return url.</returns>
        [HttpPost]
        [Route("UploadImage")]
        public async Task<IActionResult> ImageUpload(IFormFile formFile, int id)
        {
            try
            {
                ////BusinessLayer method call
                var ImageUrl = await this.businessManager.ImageUpload(formFile, id);
                
                ////if the imageurl is null then it 
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

        /// <summary>
        /// reminder.
        /// </summary>
        /// <param name="noteId">note id.</param>
        /// <returns>return result.</returns>
        [HttpGet]
        [Route("Reminder")]
        public IActionResult Reminder(int noteId)
        {
            try
            {
                ////BusinessLager method call
                var result = this.businessManager.Reminder(noteId);
                
                ////if result null then return result NotFount message
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

        /// <summary>
        /// Is pin.
        /// </summary>
        /// <param name="noteId">note id.</param>
        /// <returns>return result.</returns>
        [HttpGet]
        [Route("Pin")]
        public IActionResult IsPin(int noteId)
        {
            try
            {
                ////BusinessLayer method call
                var result = this.businessManager.IsPin(noteId);
                if (!result.Equals(null))
                {
                    ////return result
                    return this.Ok(new { result });
                }
                else
                {
                    return this.BadRequest(new { message = "Not pined" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// note type.
        /// </summary>
        /// <param name="NoteType">note type.</param>
        /// <returns>return result.</returns>
        [HttpGet]
        [Route("GetNoteType")]
        public IActionResult GetNoteType(NoteTypeEnum NoteType)
        {
            try
            {
                ////BusinessLayer method call
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// add collaborator 
        /// </summary>
        /// <param name="collaboratorModel">collaborator model data.</param>
        /// <returns>return result.</returns>
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
                    return this.BadRequest(new { message = "data is not valid" });
                }
            }
            catch (Exception ex)
            {
                ////if exception occure then throw exceptions
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get collaborator.
        /// </summary>
        /// <param name="id">collaborator id.</param>
        /// <returns>return result.</returns>
        [HttpGet]
        [Route("GetCollaborator")]
        public IActionResult GetCollaborator(int id)
        {
            try
            {
                ////check the is not null
                if (!id.Equals(null))
                {
                    ////BusinessManager layer method call
                    var result = this.businessManager.GetCollborators(id);
                    if (!result.Equals(null))
                    {
                        ////return the result.
                        return this.Ok(new { result });
                    }
                    else
                    {
                        return this.BadRequest(new { message = "The collaborator not get" });
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

        /// <summary>
        /// Update the collaborator.
        /// </summary>
        /// <param name="noteId">note id.</param>
        /// <param name="id">collaborator id.</param>
        /// <param name="notesModel">notes model data.</param>
        /// <returns>return the result.</returns>
        [HttpPost]
        [Route("UpdateCollaborator")]
        public IActionResult UpdateCollaborator(int noteId, int id, NotesModel notesModel)
        {
            try
            {
                if (!id.Equals(null))
                {
                    ////BusinessManager layer method call
                    var result = this.businessManager.UpdateCollaborator(noteId, id, notesModel);
                    if (!result.Equals(null))
                    {
                        ////return the result.
                        return this.Ok(new { result });
                    }
                    else
                    {
                        return this.BadRequest(new { message = "The collaborator is not updated successfuly" });
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

        /// <summary>
        /// remove collaborator.
        /// </summary>
        /// <param name="id">collaborator id.</param>
        /// <returns>return the result.</returns>
        [HttpPost]
        [Route("RemoveCollaborator")]
        public async Task<IActionResult> RemoveCollaboratorToNote(int id)
        {
            try
            {
                ////check the id is null or not
                if (!id.Equals(null))
                {
                    ////businessManager Layer method Called
                    var result = await this.businessManager.RemoveCollaboratorToNote(id);

                    ////if result is null then throw the exception message
                    if (!result.Equals(null))
                    {
                        ////return the result.
                        return this.Ok(new { result });
                    }
                    else
                    {
                        ////throw the exception
                        throw new Exception("The collaborator is not removed");
                    }
                }
                else
                {
                    ////throw the exception message.
                    throw new Exception("the note id is null");
                }
            }
            catch (Exception ex)
            {
                ////throw the Exception.
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// delete the multiple notes
        /// </summary>
        /// <param name="id">note id.</param>
        /// <returns>return result.</returns>
        [HttpPost]
        [Route("BulkDelete")]
        public async Task<IActionResult> BulkDelete(IList<int> id)
        {
            try
            {
                if (!id.Equals(null))
                {
                    ////businessManager Layer method called
                    var result = await this.businessManager.BulkDelete(id);
                    if (!result.Equals(null))
                    {
                        ////return result.
                        return this.Ok(new { result });
                    }
                    else
                    {
                        return this.BadRequest();
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

        /// <summary>
        /// Search the notes title and description by the string
        /// </summary>
        /// <param name="searchString">search string.</param>
        /// <returns>return the notes list.</returns>
        [HttpPost]
        [Route("Search")]
        public IActionResult Search(string searchString)
        {
            try
            {
                if (!searchString.Equals(null))
                {
                    ////businessManager Layer method call.
                    var result = this.businessManager.Search(searchString);
                    ////result is not null then return result.
                    if (!result.Equals(null))
                    {
                        return this.Ok(new { result });
                    }
                    else
                    {
                        ////return the bad request.
                        return this.BadRequest(new { Message = "Entered search string is emplty" });
                    }
                }
                else
                {
                    return this.BadRequest(new { Message = "Entered search string is empty" });
                }
            }
            catch (Exception ex)
            {
                ////throw the exception.
                throw new Exception(ex.Message);
            }
        }
    }
}
