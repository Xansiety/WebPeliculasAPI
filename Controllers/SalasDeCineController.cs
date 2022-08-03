﻿using AutoMapper; 
using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.DTOs.Cine;
using PeliculasAPI.Models;

namespace PeliculasAPI.Controllers
{
    [Route("api/SalasDeCine")]
    [ApiController]
    public class SalasDeCineController : CustomBaseController
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public SalasDeCineController(ApplicationDbContext context,IMapper mapper ) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<SalaDeCineDTO>>> Get()
        {
            return await Get<SalaDeCine, SalaDeCineDTO>();
        }

        [HttpGet("{id:int}", Name = "ObtenerSalaDeCine")]
        public async Task<ActionResult<SalaDeCineDTO>> Get(int id)
        {
            return await Get<SalaDeCine, SalaDeCineDTO>(id);
        }

        [HttpPost]
        public async Task<ActionResult<SalaDeCineDTO>> Post([FromBody] SalaDeCineCreacionDTO salaDeCineCreacionDTO)
        {
            return await Post<SalaDeCineCreacionDTO, SalaDeCine, SalaDeCineDTO>(salaDeCineCreacionDTO, "ObtenerSalaDeCine");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SalaDeCineDTO>> Put(int id, [FromBody] SalaDeCineCreacionDTO salaDeCineCreacionDTO)
        {
            return await Put<SalaDeCineCreacionDTO, SalaDeCine>(id, salaDeCineCreacionDTO);
        }

        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<SalaDeCineDTO>> Delete(int id)
        {
            return await Delete<SalaDeCine>(id);
        }


    }
}
