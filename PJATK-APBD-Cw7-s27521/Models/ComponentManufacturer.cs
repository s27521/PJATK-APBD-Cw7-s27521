using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s27521.Models;

[Table("ComponentManufacturers")]
public class ComponentManufacturer
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(30)]
    public string Abbreviation { get; set; } = null!;
    
    [MaxLength(300)]
    public string FullName { get; set; } = null!;
    
    [Column(TypeName = "date")]
    public DateTime FoundationDate { get; set; }

    public virtual ICollection<Component> Components { get; set; } = null!;
}