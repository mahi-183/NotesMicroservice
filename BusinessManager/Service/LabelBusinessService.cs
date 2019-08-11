// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelBusinessService.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessManager.Service
{
    using BusinessManager.Interface;
    using CommanLayer.Model;
    using RepositoryManager.Interface;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class LabelBusinessService : ILabelBusinessManager
    {
        public ILabelRepositoryManager repositoryManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelBusinessService"/> class.
        /// </summary>
        /// <param name="repositoryManager">The repository manager.</param>
        public LabelBusinessService(ILabelRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<int> AddLabel(LabelModel labelModel)
        {
            try
            {
                if (!labelModel.Equals(null))
                {
                    //repositoryManager layer method called
                    var result = await this.repositoryManager.AddLabel(labelModel);
                    if (result > 0)
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
        /// Gets all label.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public IList<LabelModel> GetAllLabel()
        {
            try
            {
                //repositoryManager layer method called
                var result = this.repositoryManager.GetAllLabel();
                if (!result.Equals(null))
                {
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
        /// Gets the label by identifier.
        /// </summary>
        /// <param name="LabelId">The label identifier.</param>
        /// <returns></returns>
        public IList<LabelModel> GetLabelById(int LabelId)
        {
            if (LabelId.Equals(null))
            {
                try
                {
                    var result = this.repositoryManager.GetLabelById(LabelId);
                    if (!result.Equals(null))
                    {
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
            else
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <param name="LabelId"></param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<int> UpdateLabel(LabelModel labelModel, int LabelId)
        {
            try
            {
                if (labelModel.Equals(null) && LabelId.Equals(null))
                {
                    var result =await this.repositoryManager.UpdateLabel(labelModel, LabelId);
                    if (result > 0)
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
        /// Deletes the label.
        /// </summary>
        /// <param name="LabelId">The label identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<int> DeleteLabel(int LabelId)
        {
            if (!LabelId.Equals(null))
            {
                try
                {
                    var result = await this.repositoryManager.DeleteLabel(LabelId);
                    //return result;
                    if(result > 0)
                    {
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
            else
            {
                throw new Exception();
            }
        }
    }
}
