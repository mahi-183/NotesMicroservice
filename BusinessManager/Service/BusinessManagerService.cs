// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusinessManagerService.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessManager.Service
{
    using BusinessManager.Interface;
    using CommanLayer.Model;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using RepositoryManager.Interface;

    public class BusinessManagerService : IBusinessManager
    {
        private INotesRepositoryManager repositoryManagaer;

        public BusinessManagerService(INotesRepositoryManager repositoryManager)
        {
            this.repositoryManagaer = repositoryManager;
        }
        /// <summary>
        /// Gets or sets the get notes.
        /// </summary>
        /// <param name="notesModel"></param>
        /// <returns></returns>
        /// <value>
        /// The get notes.
        /// </value>
        public IList<NotesModel> GetNotes(int id)
        {
            var Resullt = this.repositoryManagaer.GetNotes(id);
            return Resullt;
        }

        /// <summary>
        /// Delete the notes.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <value>
        /// The delete notes.
        /// </value>
        public Task<string> DeleteNotes(int id)
        {
            return this.repositoryManagaer.DeleteNotes(id);
        }

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="notesModel"></param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<string> UpdateNotes(NotesModel notesModel, int id)
        {
            var result = await this.repositoryManagaer.UpdateNotes(notesModel, id);
            return result;
        }

        /// <summary>
        /// Add the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns></returns>
        public Task<string> AddNotes(NotesModel notesModel, int id)
        {
            return this.repositoryManagaer.AddNotes(notesModel,id);
        }

    }
}
