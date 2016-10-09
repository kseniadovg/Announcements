using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EFModels
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<Announcement> Announcements { get; set; }

        public Tag()
        {
            Announcements = new List<Announcement>();
        }
    }
}
