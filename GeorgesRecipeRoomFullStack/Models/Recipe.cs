using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace GeorgesRecipeRoomFullStack.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Directions { get; set; }

        [DisplayName("Food Image")]
        public string ImageUrl { get; set; }

        public List<Tag> Tags { get; set; }
        public int UserProfileId { get; set; }
        public List<int> SelectedTagIds { get; set; }
        public Tag Tag { get; internal set; }
       
    }
}

