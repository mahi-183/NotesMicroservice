﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelController.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------
namespace NotesMicroservice.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CommanLayer.Model;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RepositoryManager.Interface;
    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        /// <summary>
        /// the ILabelRepositoryManager reference created.
        /// </summary>
        private ILabelRepositoryManager businessManager;

        /// <summary>
        /// the instance initialize.
        /// </summary>
        /// <param name="businessManager">initialize the ILabelRepositoryManager reference</param>
        public LabelController(ILabelRepositoryManager businessManager)
        {
            this.businessManager = businessManager;
        }

        /// <summary>
        /// the add Label controller api
        /// </summary>
        /// <param name="labelModel">label model data.</param>
        /// <returns>return result.</returns>
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddLabel(LabelModel labelModel)
        {
            try
            {
                ////businessManager Layer method called.
                var result = await this.businessManager.AddLabel(labelModel);
                if (!result.Equals(null))
                {
                    return this.Ok(new { result });
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
        /// the get label api.
        /// </summary>
        /// <returns>return the all label data.</returns>
        [HttpGet]
        [Route("Display")]
        public IList<LabelModel> GetAllLabel()
        {
            try
            {
                ////the business manager layer method call.
                var result = this.businessManager.GetAllLabel();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// get the label by it id.
        /// </summary>
        /// <param name="UserId">user id.</param>
        /// <returns>return result.</returns>
        [HttpGet]
        [Route("DisplayById")]
        public IActionResult GetLabelById(string UserId)
        {
            try
            {
                IList<LabelModel> result = this.businessManager.GetLabelById(UserId);
                if (!result.Equals(null))
                {
                    return this.Ok(new { result });
                }
                else
                {
                    return this.NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// the update Label
        /// </summary>
        /// <param name="labelModel">Label model.</param>
        /// <param name="UserId">user id.</param>
        /// <returns>return result.</returns>
        [HttpPost]
        [Route("Update")]
        public async Task<int> UpdateLabel(LabelModel labelModel, int UserId)
        {
            try
            {
                ////businessManager Layer method call.
                var result = await this.businessManager.UpdateLabel(labelModel, UserId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// the delete label api.
        /// </summary>
        /// <param name="LabelId">label id.</param>
        /// <returns>return result.</returns>
        [HttpPost]
        [Route("Delete")]
        public async Task<int> DeleteLabel(int LabelId)
        {
            try
            {
                ////businessManager Layer method call.
                var result = await this.businessManager.DeleteLabel(LabelId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}