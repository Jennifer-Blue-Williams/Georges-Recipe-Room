using GeorgesRecipeRoomFullStack.Models;
using System.Collections.Generic;

namespace GeorgesRecipeRoomFullStack.Repositories
{
    public interface IRecipeRepository
    {
        List<Recipe> GetAllRecipes(string firebaseId);
        Recipe GetRecipe(int id);
        void Delete(int id);
        void Add(Recipe recipe);
        void Update(Recipe recipe);
        void AddRecipeTags(int tagId, int recipeId);
        //Recipe GetToEdit(int id);
    }
}