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
        IList<NotesModel> GetNotesById(string userId, NoteTypeEnum noteType);

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> UpdateNotes(NotesModel notesModel, int id);

        /// <summary>
        /// Deletes the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> DeleteNotes(int id);

        /// <summary>
        /// Images the upload.
        /// </summary>
        /// <param name="formFile">The form file.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<string> ImageUpload(IFormFile formFile, int id);


        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="collaboratorModel">The collaborator model.</param>
        /// <returns>retrun the int value.</returns>
        Task<int> AddCollaborator(CollaboratorModel collaboratorModel);

        /// <summary>
        /// Get the collaborator.
        /// </summary>
        /// <param name="email">email.</param>
        /// <returns>return the collaborator data.</returns>
        IList<CollaboratorModel> GetCollborators(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> RemoveCollaboratorToNote(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> BulkDelete(IList<int> id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        IList<NotesModel> Search(string searchString);
        
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
