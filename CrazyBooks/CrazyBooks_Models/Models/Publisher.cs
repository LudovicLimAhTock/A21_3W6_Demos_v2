using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyBooks_Models.Models
{
  public class Publisher
  {
    [Key]
    public int Id { get; set; }

    [Display(Name = "Name")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
    [MaxLength(50, ErrorMessage = "MaxCaractersValidation")]
    public string Name { get; set; }

    [Display(Name = "Speciality")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredValidation")]
    [MaxLength(50, ErrorMessage = "MaxCaractersValidation")]
    public string Speciality { get; set; }

    [Display(Name = "PublisherSite")]
    [DataType(DataType.Url)] //Mettre aussi type input URL
    public string PublisherSite { get; set; }

    //Propriété de navigation 1 à plusieurs, côté plusieurs
    public List<Book> Books { get; set; }
  }
}
