using CarRental.Business.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallcarsdetails")]
        public IActionResult GetAllCarsDetails()
        {
            var result = _carService.GetAllCarsDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("GetCarsDetailsWithImages")]
        public IActionResult GetCarsDetailsWithImages()
        {
            var result = _carService.GetCarsDetailsWithImages();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllCarsDetailByBrand")]
        public IActionResult GetAllCarsDetailByBrand(int brandId)
        {
            var result = _carService.GetAllCarsDetailByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllCarsDetailByColor")]
        public IActionResult GetAllCarsDetailByColor(int colorId)
        {
            var result = _carService.GetAllCarsDetailByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllCarsDetailByCarType")]
        public IActionResult GetAllCarsDetailByCarType(int carTypeId)
        {
            var result = _carService.GetAllCarsDetailByCarTypeId(carTypeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetCarsAvailable")]
        public IActionResult GetCarsAvailable(DateTime rentDate, DateTime? returnDate)
        {
            var result = _carService.GetAllAvailableCarsDetails(rentDate, returnDate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpGet("GetAllCarsDetailsByFilters")]
        //public IActionResult GetAllCarsDetailsByFilters(int? colorId, int? brandId, int? carTypeId)
        //{
        //    var result = _carService.GetCarsDetailsByFilter(brandId, colorId, carTypeId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CarDetailsWithImagesDto car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarDetailsWithImagesDto car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CarDetailsWithImagesDto car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
