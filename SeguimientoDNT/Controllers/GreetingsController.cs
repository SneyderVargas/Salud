﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SeguimientoDNT.Core.Interfaces.Repositories;

namespace SeguimientoDNT.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingsController : Controller
    {
        private readonly IGrertingsRepo _grertingsRepo;

        public GreetingsController(IGrertingsRepo grertingsRepo)
        {
            _grertingsRepo = grertingsRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetGreetings()
        {
            return Ok(await _grertingsRepo.GetGreetings());
        }
    }
}
