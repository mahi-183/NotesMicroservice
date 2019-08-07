// --------------------------------------------------------------------------------------------------------------------
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
        /// Gets the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns></returns>
        IList<NotesModel> GetNotes(int id);

        /// <summary>
        /// Deletes the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<string> DeleteNotes(int id);

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<string> UpdateNotes(NotesModel notesModel, int id);

        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns></returns>
        Task<string> AddNotes(NotesModel notesModel, int id);
    }
}
