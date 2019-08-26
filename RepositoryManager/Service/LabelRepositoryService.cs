// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelRepositoryService.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------
namespace RepositoryManager.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CommanLayer.Model;
    using RepositoryManager.DBContext;
    using RepositoryManager.Interface;

    /// <summary>
    /// the Label Repository service
    /// </summary>
    public class LabelRepositoryService : ILabelRepositoryManager
    {
        /// <summary>
        /// the authenticationContext reference created.
        /// </summary>
        private readonly AuthenticationContext authenticationContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelRepositoryService"/> class.
        /// </summary>
        /// <param name="authenticationContext">The authentication context.</param>
        public LabelRepositoryService(AuthenticationContext authenticationContext)
        {
            this.authenticationContext = authenticationContext;
        }

        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>return result.</returns>
        /// <exception cref="Exception">throw exception.</exception>
        public Task<int> AddLabel(LabelModel labelModel)
        {
            try
            {
                LabelModel label = new LabelModel()
                {
                    NoteId = labelModel.NoteId,
                    UserId = labelModel.UserId,
                    Lebel = labelModel.Lebel,
                };
                this.authenticationContext.Add(label);

                var result = this.authenticationContext.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets all notes.
        /// </summary>
        /// <returns>return result.</returns>
        /// <exception cref="Exception">throw new exception.</exception>
        public IList<LabelModel> GetAllLabel()
        {
            try
            {
                List<LabelModel> list = new List<LabelModel>();
                var allLabel = from label in this.authenticationContext.Label
                               select label;
                foreach (var data in allLabel)
                {
                    list.Add(data);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the label by identifier.
        /// </summary>
        /// <param name="LabelId">The label identifier.</param>
        /// <returns>return result.</returns>
        public IList<LabelModel> GetLabelById(string UserId)
        {
            try
            {
                var list = new List<LabelModel>();
                var GetData = from label in this.authenticationContext.Label
                             where label.UserId.Equals(UserId)
                             select label;
                foreach (var data in GetData)
                {
                    list.Add(data);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <param name="UserId">user id.</param>
        /// <returns>return result.</returns>
        /// <exception cref="Exception">throw exception.</exception>
        public async Task<int> UpdateLabel(LabelModel labelModel, int LabelId)
        {
            try
            {
                var noteData = from label in this.authenticationContext.Label
                               where label.Id == LabelId
                               select label;

                foreach (var data in noteData)
                {
                    data.Lebel = labelModel.Lebel;
                }

                var result = await this.authenticationContext.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="LabelId">The label identifier.</param>
        /// <returns>return result.</returns>
        /// <exception cref="Exception">throw exception.</exception>
        public async Task<int> DeleteLabel(int labelId)
        {
            try
            {
                var data = (from label in this.authenticationContext.Label
                           where label.Id == labelId
                           select label).FirstOrDefault();
                this.authenticationContext.Label.Remove(data);
                var result = await this.authenticationContext.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
