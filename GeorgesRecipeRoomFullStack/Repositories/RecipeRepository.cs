using Microsoft.Extensions.Configuration;
using GeorgesRecipeRoomFullStack.Models;
using GeorgesRecipeRoomFullStack.Utils;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GeorgesRecipeRoomFullStack.Repositories
{
    public class RecipeRepository : BaseRepository, IRecipeRepository
    {
        public RecipeRepository(IConfiguration configuration) : base(configuration) { }

        public List<Recipe> GetAllRecipes()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT r.Id, r.Title, r.Directions, r.ImageUrl, r.UserProfileId
                                        FROM Recipe r 
                                        LEFT JOIN UserProfile u on u.Id = r.UserProfileId";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        List<Recipe> recipes = new List<Recipe>();
                        while (reader.Read())
                        {
                            recipes.Add(new Recipe()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Title = DbUtils.GetString(reader, "Title"),
                                Directions = DbUtils.GetString(reader, "Directions"),
                                ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                                Profile = new UserProfile()
                                {
                                    Name = DbUtils.GetString(reader, "UserName"),
                                }
                            });
                        }

                        return recipes;
                   
                    }
                }
            }
        }
    }
}
