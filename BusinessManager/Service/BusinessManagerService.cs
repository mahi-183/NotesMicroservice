﻿// --------------------------------------------------------------------------------------------------------------------
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
    using Microsoft.AspNetCore.Http;
    using CommanLayer.Enumerable;

    public class BusinessManagerService : IBusinessManager
    {
        //create reference of INotesRepository
        private INotesRepositoryManager repositoryManager;

        //The data stored in redis cache is in form of key value pair or nosql format so here data is key
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
                //RepositoryLayer method call
                var Result =this.repositoryManager.GetAllNotes();

                //if result contains null it throw the exeption 
                if (Result != null)
                {
                    //return result
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
        public IList<NotesModel> GetNotesById(int id)
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
        public async Task<int> UpdateNotes(NotesModel notesModel, int id)
        {
            try
            {
                var result = await this.repositoryManager.UpdateNotes(notesModel, id);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete the notes.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <value>
        /// The delete notes.
        /// </value>
        public async Task<int> DeleteNotes(int id)
        {
            try
            {
                ////Append the id
                ////var cachekey = data + id;

                if (!id.Equals(null))
                {
                    var result = await this.repositoryManager.DeleteNotes(id);
                    return result;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Images the upload.
        /// </summary>
        /// <param name="formFile">The form file.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<string> ImageUpload(IFormFile formFile, int id)
        {
            try
            {
                if (!formFile.Equals(null))
                {
                    ////RepositoryLayer method called
                    var result = await this.repositoryManager.ImageUpload(formFile, id);
                    if (!result.Equals(null))
                    {
                        return result;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Reminders the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public IList<NotesModel> Reminder(int noteId)
        {
            try
            {
                if (!noteId.Equals(null))
                {
                    var Result = this.repositoryManager.Reminder(noteId);
                    return Result;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Determines whether the specified user identifier is pin.
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public IList<NotesModel> IsPin(int noteId)
        {
            try
            {
                if (!noteId.Equals(null))
                {
                    var result = this.repositoryManager.IsPin(noteId);
                    return result;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the type of the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns></returns>
        public IList<NotesModel> GetNoteType(NoteTypeEnum NoteType)
        {
            try
            {
                if (!NoteType.Equals(null))
                {
                    var result = this.repositoryManager.GetNoteType(NoteType);
                    return result;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
