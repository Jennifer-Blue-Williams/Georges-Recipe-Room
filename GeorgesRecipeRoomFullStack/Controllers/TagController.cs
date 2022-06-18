using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using GeorgesRecipeRoomFullStack.Repositories;
using GeorgesRecipeRoomFullStack.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace GeorgesRecipeRoomFullStack.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagRepository _tagRepo;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepo = tagRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Tag> tags = _tagRepo.GetAllTags();
            return Ok(tags);
        }
    }
}