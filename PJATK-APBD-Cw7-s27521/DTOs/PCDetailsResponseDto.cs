namespace PJATK_APBD_Cw7_s27521.DTOs;

public record PCDetailsResponseDto
(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    List<PCComponentDto> Components
);