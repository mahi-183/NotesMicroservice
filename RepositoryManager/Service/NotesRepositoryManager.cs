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
    public class NotesRepositoryManager 
    {
        private UserManager<NotesModel> userManager;
        private readonly AuthenticationContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepositoryManager"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="context">The context.</param>
        public NotesRepositoryManager(UserManager<NotesModel> userManager, AuthenticationContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public AuthenticationContext Context { get; }

        /// <summary>
        /// Gets the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        //public IList<NotesModel> GetNotes(int id)
        //{
            
        //}

        public async Task<string> AddNotes(NotesModel notesModel, int id)
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
                this.Context.Notes.Add(note);
                var result = Context.SaveChanges();
                return result.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
