using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s27521.DTOs;
using PJATK_APBD_Cw7_s27521.Infrastructure;

namespace PJATK_APBD_Cw7_s27521.Service;

public class PCService(DatabaseContext ctx) : IPCService
{
    public async Task<IEnumerable<PCResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await ctx.PCs.Select(pc => new PCResponseDto(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
        )).ToListAsync(cancellationToken);
    }
}