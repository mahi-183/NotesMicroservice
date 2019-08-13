// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILabelRepositoryManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------
namespace RepositoryManager.Interface
{
    using CommanLayer.Model;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

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
        /// <param name="LabelId">The label identifier.</param>
        /// <returns></returns>
        IList<LabelModel> GetLabelById(string UserId);

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <param name="NoteId">The note identifier.</param>
        /// <returns></returns>
        Task<int> UpdateLabel(LabelModel labelModel, int LabelId);

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="Labeld">The labeld.</param>
        /// <returns></returns>
        Task<int> DeleteLabel(int Labeld);
    }
}
