using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using RemoteController.Application.Interfaces;
using RemoteController.Application.ViewModels;
using RemoteController.Domain.Interfaces;

namespace RemoteController.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        
        private readonly IMachineService _machineService;
        private readonly IUnitOfWork _uof;

        public MachinesController(IMachineService machineService, IUnitOfWork uof)
        {
            _machineService = machineService;
            _uof = uof;
        }

        // GET: api/Machines
        [HttpGet]
        public IEnumerable<MachineViewModel> GetMachines()
        {
            return _machineService.GetAll();
        }

        // GET: api/Machines/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMachine([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var machine = await _machineService.GetByIdAsync(id);

            if (machine == null)
            {
                return NotFound();
            }

            return Ok(machine);
        }

        // PUT: api/Machines/5
        [HttpPut("{id}")]
        public IActionResult PutMachine([FromRoute] Guid id, [FromBody] MachineViewModel machine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != machine.Id)
            {
                return BadRequest();
            }

            try
            {
                _machineService.Update(machine);
                _uof.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Machines
        [HttpPost]
        public async Task<IActionResult> PostMachine([FromBody] MachineViewModel machine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _machineService.Add(machine);
            _uof.Commit();

            return Ok(machine);
        }

        // DELETE: api/Machines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachine([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var machine = await _machineService.GetByIdAsync(id);
            if (machine == null)
            {
                return NotFound();
            }

            _machineService.Remove(id);
            _uof.Commit();

            return Ok(machine);
        }

        private bool MachineExists(Guid id)
        {
            return _machineService.Any(e => e.Id == id);
        }
    }
}