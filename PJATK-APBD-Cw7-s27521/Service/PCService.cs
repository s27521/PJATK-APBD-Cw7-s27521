using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s27521.DTOs;
using PJATK_APBD_Cw7_s27521.Exceptions;
using PJATK_APBD_Cw7_s27521.Infrastructure;
using PJATK_APBD_Cw7_s27521.Models;

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

    public async Task<PCDetailsResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.PCs
            .Where(e => e.Id == id)
            .Select(pc => new PCDetailsResponseDto(
                pc.Id,
                pc.Name,
                pc.Weight,
                pc.Warranty,
                pc.CreatedAt,
                pc.Stock,
                pc.PCComponents.Select(pcc => new PCComponentDto(
                    pcc.ComponentCode, pcc.Component.Name, pcc.Amount)).ToList()
            )).FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException($"PC with id {id} not found");
    }

    public async Task<PCResponseDto> AddAsync(CreatePCRequestDto request, CancellationToken cancellationToken)
    {
        var pc = new PC
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock =  request.Stock
        };
        
        ctx.Add(pc);
        await ctx.SaveChangesAsync(cancellationToken);
        
        return new PCResponseDto(pc.Id, pc.Name, pc.Weight, pc.Warranty, pc.CreatedAt, pc.Stock);
    }

    public async Task UpdateAsync(int id, UpdatePCDto request, CancellationToken cancellationToken)
    {
        /*var pc = await ctx.PCs.FirstOrDefaultAsync(e => e.Id == id, cancellationToken); // mało optymalne, dwie operacje
        if (pc is null)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
        
        pc.Name = request.Name;
        pc.Weight = request.Weight;
        pc.Warranty = request.Warranty;
        pc.CreatedAt = request.CreatedAt;
        pc.Stock = request.Stock;*/

        int affectedRows = await ctx.PCs.Where(e => e.Id == id)
            .ExecuteUpdateAsync(setters => setters
                    .SetProperty(e => e.Name, request.Name)
                    .SetProperty(e => e.Weight, request.Weight)
                    .SetProperty(e => e.Warranty, request.Warranty)
                    .SetProperty(e => e.CreatedAt, request.CreatedAt)
                    .SetProperty(e => e.Stock, request.Stock),
                cancellationToken
            );

        if (affectedRows == 0)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        /*var pc = await ctx.PCs.FirstOrDefaultAsync(e => e.Id == id, cancellationToken); // mało optymalne, dwie operacje
        if (pc is null)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }

        ctx.PCs.Remove(pc);
        await ctx.SaveChangesAsync(cancellationToken);*/
        
        int affectedRows = await ctx.PCs
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync(cancellationToken);

        if (affectedRows == 0)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
    }
}