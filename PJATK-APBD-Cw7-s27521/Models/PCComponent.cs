using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PJATK_APBD_Cw7_s27521.Models;

[Table("PCComponents"), PrimaryKey(nameof(PCId), nameof(ComponentCode))]
public class PCComponent
{
    public int PCId { get; set; }
    
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; } = null!;
    
    public int Amount { get; set; }

    [ForeignKey("PCId")]
    public virtual PC PC { get; set; } = null!;
    
    [ForeignKey("ComponentCode")]
    public virtual Component Component { get; set; } = null!;
}