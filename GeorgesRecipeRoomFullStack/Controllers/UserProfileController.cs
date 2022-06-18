﻿using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using GeorgesRecipeRoomFullStack.Repositories;
using GeorgesRecipeRoomFullStack.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace GeorgesRecipeRoomFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly ITagRepository _tagRepository;

        public UserProfileController(IUserProfileRepository userProfileRepository, ITagRepository tagRepository)
        {
            _userProfileRepository = userProfileRepository;
            _tagRepository = tagRepository;
        }

        [HttpGet("{firebaseUserId}")]
        public IActionResult GetUserProfile(string firebaseUserId)
        {
            return Ok(_userProfileRepository.GetByFirebaseUserId(firebaseUserId));
        }

        [HttpGet("DoesUserExist/{firebaseUserId}")]
        public IActionResult DoesUserExist(string firebaseUserId)
        {
            var userProfile = _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok();
        }

        //[HttpGet("Profile/{userName}")]
        //public IActionResult Get(string userName)
        //{
        //    var user = _userProfileRepository.GetUser(userName);
        //    List<Tag> tags = _tagRepository.GetTagsByUser(user.Id);
        //    user.Tags = tags;
        //    if (user == null)
        //    {

        //        return NotFound();
        //    }
        //    return Ok(user);
        //}


        //[HttpGet("MyProfile")]
        //public IActionResult GetMyProfile()
        //{
        //    var user = _userProfileRepository.GetByFirebaseUserId(GetCurrentUserProfileId());
        //    //List<Tag> tags = _tagRepository.GetTagsByUser(user.Id);
        //    //user.Tags = tags;
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(user);
        //}

        [HttpPost]
        public IActionResult Post(UserProfile userProfile)
        {
            
            _userProfileRepository.Add(userProfile);
            return Ok(userProfile);
        }

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, UserProfile userProfile)
        //{
        //    if (id != userProfile.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _userProfileRepository.Update(userProfile);
        //    return NoContent();
        //}

    }
}