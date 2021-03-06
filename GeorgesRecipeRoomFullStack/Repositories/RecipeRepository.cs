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

        public List<Recipe> GetAllRecipes(string firebaseId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT r.Id AS recipeId, r.Title, r.Directions, r.ImageUrl, u.Name
                                        FROM Recipe r 
                                        LEFT JOIN UserProfile u on u.Id = r.UserProfileId
                                        Where u.firebaseUserId = @firebaseId";

                    cmd.Parameters.AddWithValue("@firebaseId", firebaseId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        List<Recipe> recipes = new List<Recipe>();
                        while (reader.Read())
                        {
                            recipes.Add(new Recipe()
                            {
                                Id = DbUtils.GetInt(reader, "recipeId"),
                                Title = DbUtils.GetString(reader, "Title"),
                                Directions = DbUtils.GetString(reader, "Directions"),
                                ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                                Tags = new List<Tag>(),                             
                            }) ;
                        }

                        return recipes;

                    }
                }
            }
        }
        public Recipe GetRecipe(int id)
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"SELECT r.Id, r.Title, r.Directions, r.ImageUrl
                                        FROM Recipe r 
                                        WHERE r.Id = @id";


                        DbUtils.AddParameter(cmd, "@id", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            Recipe recipe = null;
                            if (reader.Read())
                            {
                                recipe = new Recipe()
                                {
                                    Id = DbUtils.GetInt(reader, "Id"),
                                    Title = DbUtils.GetString(reader, "Title"),
                                    Directions = DbUtils.GetString(reader, "Directions"),
                                    ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                                    Tags = new List<Tag>(),
                                };
                            }
                            return recipe;
                        }
                    }
                }
            }
        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Recipe WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Add(Recipe recipe)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Recipe ([Title], Directions, ImageUrl, UserProfileId)
                                        OUTPUT INSERTED.ID
                                        VALUES (@title, @directions, @ImageUrl, @UserProfileId)";
                    DbUtils.AddParameter(cmd, "@title", recipe.Title);
                    DbUtils.AddParameter(cmd, "@directions", recipe.Directions);
                    DbUtils.AddParameter(cmd, "@imageUrl", recipe.ImageUrl);
                    DbUtils.AddParameter(cmd, "@UserProfileId", recipe.UserProfileId);
                    recipe.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void AddRecipeTags(int tagId, int recipeId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO RecipeTag (RecipeId, TagId)
                                        VALUES (@recipeId, @tagId)";
                    DbUtils.AddParameter(cmd, "@recipeId", recipeId);
                    DbUtils.AddParameter(cmd, "@tagId", tagId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Recipe recipe)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Recipe
                                        SET Title = @Title,
                                            Directions = @directions,
                                            ImageUrl = @imageUrl
                                        WHERE Id = @id";
                    DbUtils.AddParameter(cmd, "@id", recipe.Id);
                    DbUtils.AddParameter(cmd, "@title", recipe.Title);
                    DbUtils.AddParameter(cmd, "@directions", recipe.Directions);
                    DbUtils.AddParameter(cmd, "@imageUrl", recipe.ImageUrl);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Recipe GetToEdit(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT r.Id, r.Title, r.Directions, r.ImageUrl, t.TagId
                                        FROM Recipe r
                                        LEFT JOIN RecipeTag t ON t.RecipeId = r.Id
                                        WHERE r.Id = @id";

                    DbUtils.AddParameter(cmd, "@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        Recipe recipe = new();
                        while (reader.Read())
                        {
                            if (recipe.Id == 0)
                            {
                                recipe = new Recipe()
                                {
                                    Id = DbUtils.GetInt(reader, "Id"),
                                    Title = DbUtils.GetString(reader, "Title"),
                                    Directions = DbUtils.GetString(reader, "Directions"),
                                    ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                                    SelectedTagIds = new List<int>()
                                };
                            }
                            recipe.SelectedTagIds.Add(DbUtils.GetInt(reader, "TagId"));
                        }
                        return recipe;
                    }
                }
            }
        }
    }
}
 

      

