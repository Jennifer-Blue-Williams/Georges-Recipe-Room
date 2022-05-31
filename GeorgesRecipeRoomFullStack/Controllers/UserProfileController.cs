using Microsoft.AspNetCore.Http;
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
        //private readonly ITagRepository _tagRepository;

        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
            //_tagRepository = tagRepository;
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

        [HttpGet("Profile/{userName}")]
        public IActionResult Get(string userName)
        {
            var user = _userProfileRepository.GetUser(userName);
            //List<Tag> tags = _tagRepository.GetTagsByUser(user.Id);
            //user.Tags = tags;
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("Profile/Register/{userName}")]
        public IActionResult Verify(string userName)
        {
            var user = _userProfileRepository.GetUser(userName);
            if (user == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("MyProfile")]
        public IActionResult GetMyProfile()
        {
            var user = _userProfileRepository.GetByFirebaseUserId(GetCurrentUserProfileId());
            //List<Tag> tags = _tagRepository.GetTagsByUser(user.Id);
            //user.Tags = tags;
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(UserProfile userProfile)
        {
            UserProfile newUser = userProfile;
            newUser.CreateDateTime = DateTime.Now;
            _userProfileRepository.Add(newUser);
            return CreatedAtAction("Get", new { userName = userProfile.Name }, userProfile);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserProfile userProfile)
        {
            if (id != userProfile.Id)
            {
                return BadRequest();
            }

            _userProfileRepository.Update(userProfile);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userProfileRepository.Delete(id);
            return NoContent();
        }
        private string GetCurrentUserProfileId()
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return id;
        }
    }
}