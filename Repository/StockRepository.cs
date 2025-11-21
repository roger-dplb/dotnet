using meta.Data;
using meta.Dtos.Stock;
using meta.Helpers;
using meta.Interfaces;
using meta.Models;
using Microsoft.EntityFrameworkCore;

namespace meta.Repository;

public class StockRepository(ApplicationDbContext context) : IStockRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<Stock>> GetAllStocksAsync(QueryObject query)
    {
        var stocks = _context.Stock.Include(c => c.Comments).AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.CompanyName))
        {
            stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
        }

        if (!string.IsNullOrWhiteSpace(query.Symbol))
        {
            stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
        }

        if (string.IsNullOrEmpty(query.SortBy)) return await stocks.ToListAsync();
        if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
        {
            stocks = query.IsDescending ? stocks.OrderByDescending(o => o.Symbol) : stocks.OrderBy(o => o.Symbol);
        }

        return await stocks.ToListAsync();
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
        existingStock.Divdend = updatedStock.Dividend;
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

    public Task<bool> StockExistsAsync(int id)
    {
        return _context.Stock.AnyAsync(s => s.Id == id);
    }
}