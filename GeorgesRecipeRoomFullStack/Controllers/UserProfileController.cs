
using Microsoft.AspNetCore.Mvc;
using GeorgesRecipeRoomFullStack.Repositories;
using GeorgesRecipeRoomFullStack.Models;


namespace GeorgesRecipeRoomFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;
       

        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
           
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
                return NotFound(false);
            }
            return Ok(true);
        }

        [HttpPost]
        public IActionResult Post(UserProfile userProfile)
        {
            
            _userProfileRepository.Add(userProfile);
            return Ok(userProfile);
        }

    }
}