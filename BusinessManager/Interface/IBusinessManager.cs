// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBusinessManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessManager.Interface
{
    using CommanLayer.Model;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBusinessManager
    {
        ///// <summary>
        ///// Gets or sets the get notes.
        ///// </summary>
        ///// <value>
        ///// The get notes.
        ///// </value>
        //IList<NotesModel> GetNotes(int id);
        
        ///// <summary>
        ///// Gets or sets the delete notes.
        ///// </summary>
        ///// <value>
        ///// The delete notes.
        ///// </value>
        //Task<string> DeleteNotes(int id);

        ///// <summary>
        ///// Updates the notes.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <returns></returns>
        //Task<string> UpdateNotes(NotesModel notesModel, int id);

        /// <summary>
        /// Shows the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns></returns>
        int AddNotes( NotesModel notesModel);
    }
}
