using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s27521.Models;

[Table("ComponentTypes")]
public class ComponentType
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(30)]
    public string Abbreviation { get; set; } = null!;
    
    [MaxLength(150)]
    public string Name { get; set; }  = null!;
    
    public virtual ICollection<Component> Components { get; set; } = null!;
}