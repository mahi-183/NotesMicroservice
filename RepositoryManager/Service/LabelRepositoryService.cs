// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelRepositoryService.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------
namespace RepositoryManager.Service
{
    using CommanLayer.Model;
    using RepositoryManager.DBContext;
    using RepositoryManager.Interface;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Linq;

    public class LabelRepositoryService : ILabelRepositoryManager
    {
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
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// <returns></returns>
        public IList<LabelModel> GetLabelById(int LabelId)
        {
            try
            {
                var list = new List<LabelModel>();
                var GetData = from label in this.authenticationContext.Label
                             where label.Id == LabelId
                             select label;
                foreach (var data in GetData)
                {
                    list.Add(data);
                }
                return list;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<int> DeleteLabel(int LabelId)
        {
            try
            {
                var data = (from label in this.authenticationContext.Label
                           where label.Id == LabelId
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
