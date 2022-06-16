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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepo;
        //private readonly ITagRepository _tagRepo;
        private readonly IUserProfileRepository _userRepo;

        public RecipeController(IRecipeRepository recipeRepository, IUserProfileRepository userProfileRepository)
          //Add above ITagRepository tagRepository
        {
            _recipeRepo = recipeRepository;
            //_tagRepo = tagRepository;
            _userRepo = userProfileRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Recipe> recipes = _recipeRepo.GetAllRecipes();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Recipe recipe = _recipeRepo.GetRecipe(id);
            //List<Tag> tags = _tagRepo.GetTagsByRecipe(id);
            //recipe.Tags = tags;
            return Ok(recipe);
        }
    }
}