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
    using Microsoft.AspNetCore.Http;
    using CommanLayer.Enumerable;
    using ServiceStack.Redis;

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
                ////RepositoryLayer method call
                var Result =this.repositoryManager.GetAllNotes();

                ////if result contains null it throw the exeption 
                if (Result != null)
                {
                    ////return result
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
        public IList<NotesModel> GetNotesById(string userId, NoteTypeEnum noteType)
        {
            try
            {
                var cachekey = data + userId;
                //// repositoryManager layer method called
                // var Result =this.repositoryManager.GetNotesById(userId, noteType);

                using (var redis = new RedisClient())
                {
                    redis.Remove(cachekey);

                    if (redis.Get(cachekey) == null)
                    {
                        var noteData = this.repositoryManager.GetNotesById(userId, noteType);
                        if (noteData != null)
                        {
                            redis.Set(cachekey, userId);
                        }
                        return noteData;
                    }
                    else
                    {
                        IList<NotesModel> list = new List<NotesModel>();
                        var list1 = redis.Get(cachekey);
                        //list.Add(list1);
                        return list;
                    }
                }
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
        /// Adds the collaborator.
        /// </summary>
        /// <param name="collaboratorModel">The collaborator model.</param>
        /// <returns>return the string result.</returns>
        /// <exception cref="Exception">
        /// throw exception.
        /// </exception>
        public async Task<int> AddCollaborator(CollaboratorModel collaboratorModel)
        {
            try
            {
                if (!collaboratorModel.Equals(null))
                {
                    ////repository service method called
                    var result = await this.repositoryManager.AddCollaborator(collaboratorModel);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get the collaborator data.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IList<CollaboratorModel> GetCollborators(int id)
        {
            try
            {
                if (!id.Equals(null))
                {
                    ////repositoryManager Layer call
                    var result = this.repositoryManager.GetCollborators(id);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> RemoveCollaboratorToNote(int id)
        {
            try
            {
                if (!id.Equals(null))
                {
                    var result = await this.repositoryManager.RemoveCollaboratorToNote(id);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> BulkDelete(IList<int> id)
        {
            try
            {

                if (!id.Equals(null))
                {
                    ////NotesRepository Layer method called.
                    var result = await this.repositoryManager.BulkDelete(id);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<NotesModel> Search(string searchString)
        {
            try
            {
                if (!searchString.Equals(null))
                {
                    IList<NotesModel> result = new List<NotesModel>();
                    result = this.repositoryManager.Search(searchString);
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
            catch (Exception ex)
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
