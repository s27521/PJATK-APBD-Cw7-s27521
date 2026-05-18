using PJATK_APBD_Cw7_s27521.DTOs;

namespace PJATK_APBD_Cw7_s27521.Service;

public interface IPCService
{
    Task<IEnumerable<PCResponseDto>> GetAllAsync(CancellationToken cancellationToken);
}