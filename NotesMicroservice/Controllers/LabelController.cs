using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommanLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryManager.Interface;

namespace NotesMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private ILabelRepositoryManager businessManager;

        public LabelController(ILabelRepositoryManager businessManager)
        {
            this.businessManager = businessManager;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddLabel(LabelModel labelModel)
        {
            try
            {
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

        [HttpGet]
        [Route("Display")]
        public IList<LabelModel> GetAllLabel()
        {
            try
            {
                var result = this.businessManager.GetAllLabel();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("DisplayAll")]
        public IActionResult GetLabelById(int LabelId)
        {
            try
            {
                IList<LabelModel> result = this.businessManager.GetLabelById(LabelId);
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

        [HttpPost]
        [Route("Update")]
        public async Task<int> UpdateLabel(LabelModel labelModel, int UserId)
        {
            try
            {
                var result = await this.businessManager.UpdateLabel(labelModel, UserId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<int> DeleteLabel(int LabelId)
        {
            try
            {
                var result = await this.businessManager.DeleteLabel(LabelId);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}