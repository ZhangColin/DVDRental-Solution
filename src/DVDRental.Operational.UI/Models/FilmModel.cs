using System.ComponentModel.DataAnnotations;

namespace DVDRental.Operational.UI.Models
{
    public class FilmModel
    {
        [Required]
        [Display(Name = "标题")]
        public string Title { get; set; }
    }
}