// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBusinessManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------
namespace BusinessManager.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CommanLayer.Enumerable;
    using CommanLayer.Model;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// interface of business manager
    /// </summary>
    public interface IBusinessManager
    {
        /// <summary>
        /// Shows the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>return result.</returns>
        Task<int> AddNotes(NotesModel notesModel);

        /// <summary>
        /// Gets all notes.
        /// </summary>
        /// <returns>return result.</returns>
        IList<NotesModel> GetAllNotes();

        /// <summary>
        /// get the notes by user id and note type.
        /// </summary>
        /// <param name="userId">user id.</param>
        /// <param name="noteType">user type.</param>
        /// <returns> return result.</returns>
        IList<NotesModel> GetNotesById(string userId, NoteTypeEnum noteType);

        /// <summary>
        /// update the notes model
        /// </summary>
        /// <param name="notesModel">notes model data.</param>
        /// <param name="id">notes id.</param>
        /// <returns> return result.</returns>
        Task<int> UpdateNotes(NotesModel notesModel, int id);

        /// <summary>
        /// delete the notes by its id.
        /// </summary>
        /// <param name="id">notes id.</param>
        /// <returns> return result.</returns>
        Task<int> DeleteNotes(int id);

        /// <summary>
        /// Images the upload.
        /// </summary>
        /// <param name="formFile">The form file.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>return result.</returns>
        Task<string> ImageUpload(IFormFile formFile, int id);

        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="collaboratorModel">The collaborator model.</param>
        /// <returns>return result.</returns>
        Task<int> AddCollaborator(CollaboratorModel collaboratorModel);

        /// <summary>
        /// get the collaborators.
        /// </summary>
        /// <param name="id">collaborator id</param>
        /// <returns> return result.</returns>
        IList<string> GetCollborators(int id);

        /// <summary>
        /// Remove the collaborator.
        /// </summary>
        /// <param name="id">collaborator id</param>
        /// <returns>return result.</returns>
        Task<int> RemoveCollaboratorToNote(int id);

        /// <summary>
        /// Delete the Multiple Notes.
        /// </summary>
        /// <param name="id">multiple note id.</param>
        /// <returns>return result.</returns>
        Task<int> BulkDelete(IList<int> id);

        /// <summary>
        /// Search the notes or description by given string
        /// </summary>
        /// <param name="searchstring">input string</param>
        /// <returns>return result.</returns>
        IList<NotesModel> Search(string searchstring);

        /// <summary>
        /// set reminder the specific note.
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <returns>return result.</returns>
        IList<NotesModel> Reminder(int noteId);

        /// <summary>
        /// Determines whether the specified user identifier is pin.
        /// </summary>
        /// <param name="noteId">note id.</param>
        /// <returns>return result.</returns>
        IList<NotesModel> IsPin(int noteId);

        /// <summary>
        /// get the note type.
        /// </summary>
        /// <param name="noteType">Note type.</param>
        /// <returns>return result.</returns>
        IList<NotesModel> GetNoteType(NoteTypeEnum noteType);
    }
}
