using System.ComponentModel.DataAnnotations;

namespace PJATK_APBD_Cw7_s27521.DTOs;

public record UpdatePCDto
(
    [MaxLength(50)] string Name,
    [Range(0.0f, 10000.0f)] float Weight, 
    int Warranty,
    DateTime CreatedAt,
    int Stock
);
