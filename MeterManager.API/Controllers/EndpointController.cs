using EnergyEndpointManager.API.Interfaces;
using EnergyEndpointManager.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnergyEndpointManager.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class EndpointController : ControllerBase
    {
        private readonly IEndpointService _meterService;

        public EndpointController(IEndpointService meterService)
        {
            _meterService = meterService;
        }

        [HttpGet]
        [Route("meters/recover")]
        public async Task<IActionResult> GetAllMeters()
        {
            try
            {
                var meters = await _meterService.GetAllAsync();

                if(meters == null)
                    return NotFound("No meter were found in the database");

                return Ok(meters);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while trying to get the list of meters from the database:" + ex.Message);
            }
        }

        [HttpGet("meters/recover/{serialNumber}")]
        public async Task<IActionResult> GetBySerialNumberAsync(string serialNumber)
        {
            try
            {
                var meterModel = await _meterService.GetBySerialNumberAsync(serialNumber);

                if (meterModel == null)
                    return NotFound("The meter sought was not found in the database.");

                return Ok(meterModel);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error ocurred while trying to recover the meter {serialNumber}:" + ex.Message);
            }
        }

        [HttpPost("meters/create")]
        public async Task<IActionResult> Create([FromBody]EnergyEndpoint endpoint)
        {
            try
            {
                var createdMeter = await _meterService.CreateAsync(endpoint);

                if (createdMeter == null)
                    return BadRequest("The attempt to create the meter was canceled because it already exists in the database.");

                return Ok(createdMeter);
            }
            catch(Exception ex)
            {
                return BadRequest($"An error ocurred while trying to create the meter {endpoint.SerialNumber}:" + ex.Message);
            }
        }

        [HttpPost("meters/update")]
        public async Task<IActionResult> Update([FromBody]EnergyEndpoint endpoint)
        {
            try
            {
                   var updatedMeter = await _meterService.UpdateAsync(endpoint);

                if (updatedMeter == null)
                    return NotFound("The meter being updated was not found in the database.");

                return Ok(updatedMeter);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error ocurred while trying to update the meter {endpoint.SerialNumber}:" + ex.Message);
            }
        }

        [HttpDelete("meters/delete/{serialNumber}")]
        public async Task<IActionResult> Delete(string serialNumber)
        {
            try
            {
                var meterToDelete = _meterService.GetMeterModelToDelete(serialNumber);

                if (meterToDelete == null)
                    return NotFound("The meter being deleted was not found in the database.");

                await _meterService.DeleteAsync(serialNumber);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"An error ocurred while trying to delete the meter {serialNumber}:" + ex.Message);
            }
        }

        
    }
}
