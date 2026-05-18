using PJATK_APBD_Cw7_s27521.DTOs;

namespace PJATK_APBD_Cw7_s27521.Service;

public interface IPCService
{
    Task<IEnumerable<PCResponseDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<PCDetailsResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<PCResponseDto> AddAsync(CreatePCRequestDto request, CancellationToken cancellationToken);
    Task UpdateAsync(int id, UpdatePCDto request, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}