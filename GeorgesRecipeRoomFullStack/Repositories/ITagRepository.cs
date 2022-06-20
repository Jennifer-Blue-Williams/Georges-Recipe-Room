using GeorgesRecipeRoomFullStack.Models;
using System.Collections.Generic;

namespace GeorgesRecipeRoomFullStack.Repositories
{
    public interface ITagRepository
    {
        //List<Tag> GetTagsByRecipe(int id);
        //List<Tag> GetTagsByUser(int id);
        List<Tag> GetAllTags();
        void ResetTags(int recipeId);
    }
}