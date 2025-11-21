using meta.Data;
using meta.Dtos.Stock;
using meta.Interfaces;
using meta.Models;
using Microsoft.EntityFrameworkCore;

namespace meta.Repository;

public class StockRepository(ApplicationDbContext context) : IStockRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<Stock>> GetAllStocksAsync()
    {
        return await _context.Stock.Include(c => c.Comments).ToListAsync();
    }

    public async Task<Stock?> GetStockByIdAsync(int id)
    {
        return  await _context.Stock.FindAsync(id);
    }

    public async Task<Stock> CreateStockAsync(Stock stock)
    {
        await _context.Stock.AddAsync(stock);
        await _context.SaveChangesAsync();
        return stock;
    }

    public async Task<Stock?> UpdateStockAsync(int id, UpdateStockRequestDto updatedStock)
    {
        var existingStock = await _context.Stock.FirstOrDefaultAsync(s => s.Id == id);
        if (existingStock == null)
        {
            return null;
        }
        existingStock.Symbol = updatedStock.Symbol;
        existingStock.CompanyName = updatedStock.CompanyName;
        existingStock.Purchase = updatedStock.Purchase;
        existingStock.Divdend = updatedStock.Divdend;
        existingStock.LastDiv = updatedStock.LastDiv;
        existingStock.Industry = updatedStock.Industry;  
        await _context.SaveChangesAsync();
        return  existingStock;
}

    public async Task<Stock?> DeleteStock(int id)
    {
       var stock = await _context.Stock.FirstOrDefaultAsync(s => s.Id == id);
       if (stock == null)
       {
           return null;
       }
       _context.Stock.Remove(stock);
        await _context.SaveChangesAsync();
        return stock;
    }
}