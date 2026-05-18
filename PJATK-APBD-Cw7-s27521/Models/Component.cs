using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s27521.Models;

[Table("Components")]
public class Component
{
    [Key][Column(TypeName = "char(10)")]
    public string Code { get; set; } = null!;

    [MaxLength(300)]
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    public int ComponentManufacturersId { get; set; }
    
    [ForeignKey(nameof(ComponentManufacturersId))]
    public virtual ComponentManufacturer ComponentManufacturer { get; set; } = null!;
    
    public int ComponentTypesId { get; set; }
    
    [ForeignKey(nameof(ComponentTypesId))]
    public virtual ComponentType ComponentType { get; set; } = null!;
    
    public virtual ICollection<PCComponent> PCComponents { get; set; } = [];
    //ICollection extends IEnumerable and provides additional functionalities such as adding, removing, and counting elements in a collection, while IEnumerable is primarily used for iterating over a collection without modifying it. Essentially, use IEnumerable for read-only access and ICollection when you need to modify the collection.
}