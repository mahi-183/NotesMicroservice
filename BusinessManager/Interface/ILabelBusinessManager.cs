// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILabelBusinessManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------
namespace BusinessManager.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CommanLayer.Model;

    /// <summary>
    /// Interface of label business manager
    /// </summary>
    public interface ILabelBusinessManager
    {
        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>return result.</returns>
        Task<int> AddLabel(LabelModel labelModel);

        /// <summary>
        /// Gets all label.
        /// </summary>
        /// <returns>return result.</returns>
        IList<LabelModel> GetAllLabel();

        /// <summary>
        /// Gets the label by identifier.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <returns>return result.</returns>
        IList<LabelModel> GetLabelById(string userID);

        /// <summary>
        /// update the label by its id.
        /// </summary>
        /// <param name="labelModel">label model data.</param>
        /// <param name="labelId">label id.</param>
        /// <returns>return result.</returns>
        Task<int> UpdateLabel(LabelModel labelModel, int labelId);

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <returns>return result.</returns>
        Task<int> DeleteLabel(int labelId);
    }
}
