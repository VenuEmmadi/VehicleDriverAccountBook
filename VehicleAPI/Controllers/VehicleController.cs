﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using VehicleAPI.Interfaces;
using VehicleAPI.Models;

namespace VehicleAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _service;

        public VehicleController(IVehicleService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Vehicles()
        {
            VehiclesResponse response = new VehiclesResponse();
            response.IsSuccess = true;
            response.Vehicles = _service.Vehicles();
            return Ok(response);
        }

        [HttpGet]
        public IActionResult VehiclesByType(string vehicleType)
        {
            VehiclesResponse response = new VehiclesResponse();
            response.IsSuccess = true;
            response.Vehicles = _service.VehiclesByType(vehicleType);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult VehicleByRegistrationNo(string registrationNo)
        {
            VehicleByRegistrationNoResponse response = new VehicleByRegistrationNoResponse();
            response.IsSuccess = true;
            response.Vehicle = _service.VehicleByRegistrationNo(registrationNo);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateVehicle(Vehicle vehicle)
        {
            ResponseStatus response = new ResponseStatus();
            response.IsSuccess = _service.UpdateVehicle(vehicle);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddVehicle(Vehicle vehicle)
        {
            //_log.info("AddVehicle : Process Initiated");
            //if (!TryHandlerequestAuth(ControllerMethods.C))
            //{
            //    _log.Info("Add Vehicle : Process terminated with Message : Unauthorized Access.");
            //}
            //try
            //{
                ResponseStatus response = new ResponseStatus();
                response.IsSuccess = _service.AddVehicle(vehicle);
                return Ok(response);
            //}
            //catch(Exception exception)
            //{
            //    //_log.Info("Add vehicle : Process Terminated with Exception -", exception);
            //    return Conflict();
            //}
           
        }

        [HttpDelete]
        public IActionResult DeleteVehicle(string registrationNo)
        {
            ResponseStatus response = new ResponseStatus();
            response.IsSuccess = _service.DeleteVehicle(registrationNo);
            return Ok(response);
        }
    }
}
