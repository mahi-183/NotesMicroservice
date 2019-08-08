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
        public NotesRepositoryManager( AuthenticationContext context)
        {
          
            this.context = context;
        }

        /// <summary>
        /// AddNotes method is for adding the notes to the databaase
        /// </summary>
        /// <param name="notesModel"></param>
        /// <returns></returns>
        public int AddNotes( NotesModel notesModel)
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
                var result =  this.context.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
