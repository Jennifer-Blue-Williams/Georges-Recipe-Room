using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
        //public UserProfile Profile { get; set; }
        public List<int> SelectedTagIds { get; set; }
    }
}

