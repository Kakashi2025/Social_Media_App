﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplicationSocialMediaApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API is working!");
        }


    }
}