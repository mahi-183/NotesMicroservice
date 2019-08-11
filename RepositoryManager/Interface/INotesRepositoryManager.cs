﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotesRepositoryManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------

namespace RepositoryManager.Interface
{
    using CommanLayer.Model;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface INotesRepositoryManager
    {
        /// <summary>
        /// Adds the notes.
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
        /// Gets the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns></returns>
        IList<NotesModel> GetNotesById(string id);

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> UpdateNotes(NotesModel notesModel, string UserId);

        /// <summary>
        /// Deletes the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> DeleteNotes(string id);
    }
}
