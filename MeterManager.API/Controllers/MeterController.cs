using MeterManager.API.Interfaces;
using MeterManager.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeterManager.API.Controllers
{
    [Route("api")]
    public class MeterController : Controller
    {
        private readonly IMeterService _meterService;

        public MeterController(IMeterService meterService)
        {
            _meterService = meterService;
        }
    
        // GET: MeterController
        [Route("teste")]
        public ActionResult Teste()
        {
            return Ok("Funcionando!");
        }

        // GET: MeterController/Details/5
        public ActionResult GetAllMeters()
        {
            try
            {
                var meters = _meterService.GetAllAsync();

                if(meters == null)
                    return NotFound("No meter was found in database");

                return Ok(meters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: MeterController/Create
        [HttpPost]
        public async Task<IActionResult> Create(MeterModel meter)
        {
            try
            {
                var createdMeter = await _meterService.CreateAsync(meter);

                if (createdMeter == null)
                    return BadRequest("The meter already exists in Database");

                return Ok(createdMeter);
            }
            catch(Exception ex)
            {
                return BadRequest("An error ocurred while trying to create the meter. Error log:" + ex.Message);
            }
        }

        // GET: MeterController/Edit/5
        public async Task<IActionResult> Update(MeterModel meter)
        {
            try
            {
                var updatedMeter = _meterService.UpdateAsync(meter);

                if (updatedMeter == null)
                    return NotFound("The meter was not found on our database");

                return Ok(updatedMeter);
            }
            catch (Exception)
            {

                throw;
            }
        }
        // GET: MeterController/Delete/5
        public async Task<IActionResult> Delete(string serialNumber)
        {
            var meterToDelete = _meterService.GetMeterModelToDelete(serialNumber);

            if (meterToDelete == null)
                return NotFound("The meter was not found");

            await _meterService.DeleteAsync(serialNumber);
            return NoContent();
        }

        public async Task<IActionResult> GetBySerialNumberAsync(string serialNumber)
        {
            var meterModel = await _meterService.GetBySerialNumberAsync(serialNumber);

            if (meterModel == null)
                return NotFound("The meter was not found");

            return Ok(meterModel);
        }
    }
}
