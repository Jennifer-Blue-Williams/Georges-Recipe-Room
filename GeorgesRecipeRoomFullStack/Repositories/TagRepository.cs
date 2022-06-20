using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using GeorgesRecipeRoomFullStack.Models;
using GeorgesRecipeRoomFullStack.Utils;

namespace GeorgesRecipeRoomFullStack.Repositories
{
    public class TagRepository : BaseRepository, ITagRepository
    {
        public TagRepository(IConfiguration configuration) : base(configuration) { }

        public List<Tag> GetAllTags()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Label
                                        FROM Tag";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Tag> tags = new List<Tag>();
                        while (reader.Read())
                        {
                            tags.Add(new Tag()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Label = DbUtils.GetString(reader, "Label")
                            });
                        }
                        return tags;
                    }
                }
            }
        }

        public void ResetTags(int recipeId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM RecipeTag WHERE RecipeId = @recipeId";

                    DbUtils.AddParameter(cmd, "@recipeId", recipeId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //public List<Tag> GetTagsByRecipe(int id)

        //{
        //    using (var conn = Connection)
        //    {
        //        conn.Open();
        //        using (var cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"SELECT t.Id, t.Label
        //                                FROM Tag t
        //                                JOIN RecipeTag r ON r.TagId = t.Id
        //                                WHERE r.RecipeId = @id";

        //            DbUtils.AddParameter(cmd, "@id", id);
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                List<Tag> tags = new List<Tag>();
        //                while (reader.Read())
        //                {
        //                    tags.Add(new Tag()
        //                    {
        //                        Id = DbUtils.GetInt(reader, "Id"),
        //                        Label = DbUtils.GetString(reader, "Label")
        //                    });
        //                }
        //                return tags;
        //            }
        //        }
        //    }
        //}

        //public List<Tag> GetTagsByUser(int id)
        //{
        //    using (var conn = Connection)
        //    {
        //        conn.Open();
        //        using (var cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"SELECT t.Id, t.Label
        //                                FROM Tag t
        //                                JOIN UserLikedTags u ON u.TagId = t.Id
        //                                WHERE u.UserId = @id";

        //            DbUtils.AddParameter(cmd, "@id", id);
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                List<Tag> tags = new List<Tag>();
        //                while (reader.Read())
        //                {
        //                    tags.Add(new Tag()
        //                    {
        //                        Id = DbUtils.GetInt(reader, "Id"),
        //                        Label = DbUtils.GetString(reader, "Label")
        //                    });
        //                }
        //                return tags;
        //            }
        //        }
        //    }
        //}
    }
}