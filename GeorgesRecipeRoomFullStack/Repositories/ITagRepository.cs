using GeorgesRecipeRoomFullStack.Models;
using System.Collections.Generic;

namespace GeorgesRecipeRoomFullStack.Repositories
{
    public interface ITagRepository
    {
        List<Tag> GetAllTags();
        void ResetTags(int recipeId);
        List<Tag> GetTagsByRecipe(int id);
    }
}