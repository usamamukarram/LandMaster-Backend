using Deals.Dto.PlotSize;
using Deals.Dto.Role;
using Deals.Dto.Society;
using Deals.Interface;
using Deals.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlotSizeController : ControllerBase
    {
        private readonly IPlotSize _plotSize;

        public PlotSizeController(IPlotSize plotSize)
        {
            _plotSize = plotSize;
        }
        [HttpGet("AllPlotSizes")]
        public async Task<ActionResult<ServiceResponse<PlotSize>>> GetAllPlotSizeList()
        {

            var Sizes = await _plotSize.GetAllSize();
            return Ok(Sizes);

        }
        [HttpPost("AddPlotSize")]
        public async Task<ActionResult<ServiceResponse<PlotSize>>> AddSociety(AddPlotSizeDto AddPlotRequest)
        {

            var response = await _plotSize.AddPlotSize(
                new PlotSize
                {
                    PlotSizeName = AddPlotRequest.PlotSizeName
                });
            ;


            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("UpdateStatus")]
        public async Task<ActionResult<ServiceResponse<PlotSize>>> UpdateStatus([FromQuery] int PlotSizeId, [FromQuery] bool status)
        {
            var plotSize = await _plotSize.UpdatePlotSizeStatus(PlotSizeId, status);
            return Ok(plotSize);
        }
        [HttpPut("UpdateSociety")]
        public async Task<ActionResult<ServiceResponse<PlotSize>>> UpdatePlotSize(PlotSize UpdatePlotSIzeDtoRequest)
        {
            var PlotSIze = await _plotSize.UpdatePlotSize(UpdatePlotSIzeDtoRequest);
            return Ok(PlotSIze);
        }
        [HttpGet("getPlotSIzeById/{PlotSizeID}")]
        public async Task<ActionResult<ServiceResponse<PlotSize>>> societyById(int PlotSizeID)
        {
            var plotSIze = await _plotSize.GetPlotSizeById(PlotSizeID);
            return Ok(plotSIze);
        }
    }
}
