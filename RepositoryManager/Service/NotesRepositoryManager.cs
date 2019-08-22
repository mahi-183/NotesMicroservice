// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesRepositoryManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------

namespace RepositoryManager.Service
{
    using CommanLayer.Model;
    using Microsoft.AspNetCore.Identity;
    using RepositoryManager.DBContext;
    using RepositoryManager.Interface;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.AspNetCore.Http;
    using CommanLayer;
    using CommanLayer.Enumerable;

    /// <summary>
    /// NotesRepositoryManager class implements the interface methods like AddNotes, DeleteNotes, UpdateNotes and GetNotes
    /// </summary>
    /// <seealso cref="INotesRepositoryManager" />
    public class NotesRepositoryManager : INotesRepositoryManager
    {
      
        private readonly AuthenticationContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepositoryManager"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="context">The context.</param>
        public NotesRepositoryManager(AuthenticationContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// AddNotes method is for adding the notes to the databaase
        /// </summary>
        /// <param name="notesModel"></param>
        /// <returns></returns>
        public async Task<int> AddNotes( NotesModel notesModel)
        {
            
                NotesModel note = new NotesModel()
                {
                    UserId = notesModel.UserId,
                    Title = notesModel.Title,
                    Description = notesModel.Description,
                    Color = notesModel.Color,
                    Reminder = notesModel.Reminder,
                    CreatedDate = notesModel.CreatedDate,
                    ModifiedDate = notesModel.ModifiedDate,
                    noteType = notesModel.noteType,
                    IsPin = notesModel.IsPin
                };
            try
            {
                this.context.Notes.Add(note);
                int result = await this.context.SaveChangesAsync();
                if(result >0)
                {
                    return result;
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
        /// Gets all notes.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IList<NotesModel> GetAllNotes()
        {
            try
            {
                List<NotesModel> list = new List<NotesModel>();
                var allNotes = from notes in this.context.Notes
                               select notes;

                foreach (var data in allNotes)
                {
                    list.Add(data);
                }
                return list;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the notes by identifier.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IList<NotesModel> GetNotesById(string userId, NoteTypeEnum noteType)
        {
            try
            {
                var noteList = new List<NotesModel>();
                
                var note = (from notedata in context.Notes where notedata.UserId == userId select notedata);
                foreach (var data in note)
                {
                    if (data.noteType == noteType)
                    {
                        noteList.Add(data);
                    }
                }
                return noteList; 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<int> UpdateNotes(NotesModel notesModel, int id)
        {
            try
            {
                var updateData = from notes in this.context.Notes
                                 where notes.Id == id  
                                 select notes;

                foreach (var update in updateData)
                {
                    update.Title = notesModel.Title;
                    update.Description = notesModel.Description;
                    update.Color = notesModel.Color;
                    update.Image = notesModel.Image;
                    update.Reminder = notesModel.Reminder;
                    update.ModifiedDate = notesModel.ModifiedDate;
                    update.noteType = notesModel.noteType;
                    update.IsPin = notesModel.IsPin;
                }
                var Result =await this.SaveAll();
                return Result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Saves all.
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveAll()
        {
            return await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the notes.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<int> DeleteNotes(int id)
        {
            try
            {
                var removeData = (from notes in this.context.Notes
                                 where notes.Id == id
                                 select notes).FirstOrDefault();
                //NotesModel removeDta = this.context.Notes.Where(note => note.UserId == UserId).FirstOrDefault();

                this.context.Notes.Remove(removeData);
                var Result = await this.SaveAll();
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Images the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="noteId">The note identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<string> ImageUpload(IFormFile file, int noteId)
        {
            try
            {
                //create object of the cloudinaryImage class
                CloudinaryImage cloudinary = new CloudinaryImage();
                
                //Cloudinary UploadImageCloudinary method call
                var uploadUrl = cloudinary.UploadImageCloudinary(file);

                //Query to get the note data from database 
                var data = this.context.Notes.Where(note => note.Id == noteId).FirstOrDefault();

                //update the ImageUrl to database Notes table
                data.Image = uploadUrl;

                //Update save changes in dabase table
                int result = await this.context.SaveChangesAsync();

                //if result is grater than zero then return the update result 
                if (result > 0)
                { 
                    return data.Image;
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
        /// Reminders the specified user identifier.
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IList<NotesModel> Reminder(int noteId)
        {
            try
            {
                IList<NotesModel> list = new List<NotesModel>();
                var data = from notes in this.context.Notes
                           where (notes.Id == noteId) && (notes.Reminder != null)
                           select notes;

                foreach (var reminderData in data)
                {
                    list.Add(reminderData);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Determines whether the specified user identifier is pin.
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public IList<NotesModel> IsPin(int noteId)
        {
            try
            {
                IList<NotesModel> list = new List<NotesModel>();
                var NoteData = from notes in this.context.Notes
                               where (notes.Id == noteId) && (notes.IsPin == true)
                               select notes;
                foreach (var Data in NoteData)
                {
                    list.Add(Data);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the type of the note.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns></returns>
        public IList<NotesModel> GetNoteType(NoteTypeEnum noteType)
        {
            try
            {
                IList<NotesModel> list = new List<NotesModel>();
                if (noteType == NoteTypeEnum.IsNote)
                {
                    var NoteData = from notes in this.context.Notes
                                   where (notes.noteType == NoteTypeEnum.IsNote)
                                   select notes;
                    foreach (var data in NoteData)
                    {
                        list.Add(data);
                    }
                }
                else if (noteType == NoteTypeEnum.IsArchive)
                {
                    var NoteData = from notes in this.context.Notes
                                   where (notes.noteType == NoteTypeEnum.IsArchive)
                                   select notes;
                    foreach (var data in NoteData)
                    {
                        list.Add(data);
                    }
                }
                else if (noteType == NoteTypeEnum.IsTrash)
                {
                    var NoteData = from notes in this.context.Notes
                                   where (notes.noteType == NoteTypeEnum.IsTrash)
                                   select notes;
                    foreach (var data in NoteData)
                    {
                        list.Add(data);
                    }
                }
                return list;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="collaboratorModel">The collaborator model.</param>
        /// <returns>return string result.</returns>
        /// <exception cref="Exception">throw exception.</exception>
        public async Task<int> AddCollaborator(CollaboratorModel collaboratorModel)
        {
            var collaborator = new CollaboratorModel()
            {
                UserId = collaboratorModel.UserId,
                NoteId = collaboratorModel.NoteId,
                CreatedBy = collaboratorModel.CreatedBy
            };

            try
            {
                this.context.Collaborator.Add(collaborator);
                var result = await this.context.SaveChangesAsync();
                if (result > 0)
                {
                    return result;
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
        /// 
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>return the list of the collaborator.</returns>
        public IList<CollaboratorModel> GetCollaborators(string email)
        {
            try
            {
                if (!email.Equals(null))
                {
                    IList<CollaboratorModel> collaborator = new List<CollaboratorModel>();
                    var list = from coll in this.context.Collaborator
                               where (coll.CreatedBy == email)
                               select collaborator;
                    foreach (var data in list)
                    {
                        collaborator.Add(data);
                    }
                    return collaborator;

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
