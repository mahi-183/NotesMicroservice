// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBusinessManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------
namespace BusinessManager.Interface
{
    using CommanLayer.Enumerable;
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
        IList<NotesModel> GetNotesById(string userId, NoteTypeEnum noteType);

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> UpdateNotes(NotesModel notesModel, int id);

        /// <summary>
        /// Gets or sets the delete notes.
        /// </summary>
        /// <value>
        /// The delete notes.
        /// </value>
        Task<int> DeleteNotes(int id);

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
        
        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="collaboratorModel">The collaborator model.</param>
        /// <returns></returns>
        Task<int> AddCollaborator(CollaboratorModel collaboratorModel);

        /// <summary>
        /// Get The collaborator.
        /// </summary>
        /// <param name="email">Email address</param>
        /// <returns>return the collaborator</returns>
        Task<CollaboratorModel> GetCollborators(string email);
    }
}
