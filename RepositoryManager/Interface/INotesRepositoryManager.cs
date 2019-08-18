// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotesRepositoryManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------

namespace RepositoryManager.Interface
{
    using CommanLayer.Enumerable;
    using CommanLayer.Model;
    using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Images the upload.
        /// </summary>
        /// <param name="formFile">The form file.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<string> ImageUpload(IFormFile formFile, int id);

        /// <summary>
        /// Reminders the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IList<NotesModel> Reminder(int noteId);

        /// <summary>
        /// Determines whether the specified user identifier is pin.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IList<NotesModel> IsPin(int noteId);

        /// <summary>
        /// Gets the type of the note.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns></returns>
        IList<NotesModel> GetNoteType(NoteTypeEnum NoteType);
    }
}
