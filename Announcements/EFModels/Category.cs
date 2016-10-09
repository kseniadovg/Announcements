using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFModels
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        //[Required]
        public byte[] Image { get; set; }

        public List<Announcement> Announcements { get; set; }

        public Category()
        {
            Announcements = new List<Announcement>();
        }
    }
}
