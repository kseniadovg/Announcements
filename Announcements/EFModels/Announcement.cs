using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFModels
{
    public class Announcement
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Body { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid E-mail Address")]
        public string Email { get; set; }

        [Display(Name = "Phone Number 1")]
        public string PhoneNumber1 { get; set; }

        [Display(Name = "Phone Number 2")]
        public string PhoneNumber2 { get; set; }

        [Display(Name = "Phone Number 3")]
        public string PhoneNumber3 { get; set; }

        public DateTime CreatedTime { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [NotMapped]
        public string AuthorPicture { get; set; }
        
        public string Tags { get; set; }
    }
}