// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBusinessManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessManager.Interface
{
    using CommanLayer.Model;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBusinessManager
    {

        /// <summary>
        /// Shows the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns></returns>
        Task<int> AddNotes(NotesModel notesModel);

        /// <summary>
        /// Gets all notes.
        /// </summary>
        /// <returns></returns>
        IList<NotesModel> GetAllNotes();

        /// <summary>
        /// Gets or sets the get notes.
        /// </summary>
        /// <value>
        /// The get notes.
        /// </value>
        IList<NotesModel> GetNotesById(string id);

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> UpdateNotes(NotesModel notesModel, string UserId);

        /// <summary>
        /// Gets or sets the delete notes.
        /// </summary>
        /// <value>
        /// The delete notes.
        /// </value>
        Task<int> DeleteNotes(string UserId);

        /// <summary>
        /// Images the upload.
        /// </summary>
        /// <param name="formFile">The form file.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<string> ImageUpload(IFormFile formFile, int id);
    }
}
