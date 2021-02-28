using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        ICarImageService _carImageservice;

        public CarImageController(ICarImageService carImageservice)
        {
            _carImageservice = carImageservice;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _carImageservice.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        [HttpPost("add")]
        public IActionResult AddAsync([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageservice.Add(file,carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById([FromForm(Name =("Id"))] int Id)
        {
            var result = _carImageservice.GetById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPut("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int Id)
        {
            var carImage = _carImageservice.GetById(Id).Data;

            var result = _carImageservice.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int Id)
        {
            var carImage = _carImageservice.GetById(Id).Data;

            var result = _carImageservice.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
    }
}
