// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILabelRepositoryManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------
namespace RepositoryManager.Interface
{
    using CommanLayer.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// the ILabelRepositoryManager interface
    /// </summary>
    public interface ILabelRepositoryManager
    {
        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns></returns>
        Task<int> AddLabel(LabelModel labelModel);

        /// <summary>
        /// Gets all label.
        /// </summary>
        /// <returns></returns>
        IList<LabelModel> GetAllLabel();

        /// <summary>
        /// Gets the label by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IList<LabelModel> GetLabelById(string userId);

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <param name="labeld">The label identifier.</param>
        /// <returns></returns>
        Task<int> UpdateLabel(LabelModel labelModel, int labelId);

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="labeld">The labe Id.</param>
        /// <returns></returns>
        Task<int> DeleteLabel(int labeld);
    }
}
