using GeorgesRecipeRoomFullStack.Models;
using System.Collections.Generic;

namespace GeorgesRecipeRoomFullStack.Repositories
{
    public interface IRecipeRepository
    {
        List<Recipe> GetAllRecipes();
        Recipe GetRecipe(int id);
        //List<Recipe> HomepageRecipes();
        void Delete(int id);
        void Add(Recipe recipe);
        void Update(Recipe recipe);
        void AddRecipeTags(int tagId, int recipeId);
        Recipe GetToEdit(int id);
    }
}