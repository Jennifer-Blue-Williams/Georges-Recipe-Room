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
        private readonly ITagRepository _tagRepo;
        private readonly IUserProfileRepository _userRepo;

        public RecipeController(IRecipeRepository recipeRepository, ITagRepository tagRepository, IUserProfileRepository userProfileRepository)
        {
            _recipeRepo = recipeRepository;
            _tagRepo = tagRepository;
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
            List<Tag> tags = _tagRepo.GetTagsByRecipe(id);
            recipe.Tags = tags;
            return Ok(recipe);
        }

        [HttpGet("Edit/{id}")]
        public IActionResult GetRecipeToEdit(int id)
        {
            return Ok(_recipeRepo.GetToEdit(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _recipeRepo.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Post(Recipe recipe)
        {
            UserProfile currentUser = GetCurrentUserProfile();
            recipe.UserProfileId = currentUser.Id;
            _recipeRepo.Add(recipe);
            int newRecipeId = recipe.Id;
            foreach (int tagId in recipe.SelectedTagIds)
            {
                _recipeRepo.AddRecipeTags(tagId, newRecipeId);
            }

            return Ok(recipe);
        }

        [HttpPut]
        public IActionResult Update(Recipe recipe)
        {
            _recipeRepo.Update(recipe);
            int recipeId = recipe.Id;
            _tagRepo.ResetTags(recipeId);
            foreach (int tagId in recipe.SelectedTagIds)
            {
                _recipeRepo.AddRecipeTags(tagId, recipeId);
            }
            return Ok(recipe);
        }
        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userRepo.GetByFirebaseUserId(firebaseUserId);
        }
    }
}