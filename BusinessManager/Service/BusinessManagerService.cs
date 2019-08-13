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
        //create reference of INotesRepository
        private INotesRepositoryManager repositoryManager;
        private const string data = "data";

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessManagerService"/> class.
        /// </summary>
        /// <param name="repositoryManager">The repository manager.</param>
        public BusinessManagerService(INotesRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        /// <summary>
        /// Add the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns></returns>
        public async Task<int> AddNotes(NotesModel notesModel)
        {
            //RepositoryManager layer method called
            var result =await this.repositoryManager.AddNotes(notesModel);
            return result;
        }

        /// <summary>
        /// Display All notes 
        /// </summary>
        /// <returns></returns>
        public IList<NotesModel> GetAllNotes()
        {
            try
            {
                var Result =this.repositoryManager.GetAllNotes();
                if (Result != null)
                {
                    return Result;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Gets or sets the get notes.
        /// </summary>
        /// <param name="notesModel"></param>
        /// <returns></returns>
        /// <value>
        /// The get notes.
        /// </value>
        public IList<NotesModel> GetNotesById(string id)
        {
            try
            {
                //repositoryManager layer method called
                var Result =this.repositoryManager.GetNotesById(id);
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="notesModel"></param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<int> UpdateNotes(NotesModel notesModel, string UserId)
        {
            var result = await this.repositoryManager.UpdateNotes(notesModel, UserId);
            return result;
        }

        /// <summary>
        /// Delete the notes.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <value>
        /// The delete notes.
        /// </value>
        public async Task<int> DeleteNotes(string id)
        {
            var result = await this.repositoryManager.DeleteNotes(id);
            return result;
        }
    }
}
