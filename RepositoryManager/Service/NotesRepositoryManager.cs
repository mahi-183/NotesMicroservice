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
            try
            {
                NotesModel note = new NotesModel()
                {
                    UserId = notesModel.UserId,
                    Title = notesModel.Title,
                    Description = notesModel.Description,
                    Color = notesModel.Color
                };
                this.context.Notes.Add(note);
                int result =await this.context.SaveChangesAsync();
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
        public IList<NotesModel> GetNotesById(string UserId)
        {
            try
            {
                IList<NotesModel> list = new List<NotesModel>();

                var noteData =from note in this.context.Notes where note.UserId.Equals(UserId) orderby note.Id descending select note;

                foreach (var data in noteData)
                {
                    list.Add(data);
                }
                return list; 
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
        public async Task<int> UpdateNotes(NotesModel notesModel, string UserId)
        {
            try
            {
                var updateData = from notes in this.context.Notes
                                 where notes.UserId == UserId
                                 select notes;

                foreach (var update in updateData)
                {
                    update.Title = notesModel.Title;
                    update.Description = notesModel.Description;
                    update.Color = notesModel.Color;
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
        public async Task<int> DeleteNotes(string UserId)
        {
            try
            {
                var removeData = (from notes in this.context.Notes
                                 where notes.UserId == UserId
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
    }
}
