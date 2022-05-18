using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GeorgesRecipeRoomFullStack.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [StringLength(28, MinimumLength = 28)]
        public string FirebaseUserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(255)]
        public string Email { get; set; }

        public DateTime CreateDateTime { get; set; }

        //[DataType(DataType.Url)]
        //[MaxLength(255)]
        //public string ImageLocation { get; set; }

        [Required]

        public string CreateDateTimeFormatted
        {
            get
            {
                return CreateDateTime.ToString("d");
            }
        }
    }
}
