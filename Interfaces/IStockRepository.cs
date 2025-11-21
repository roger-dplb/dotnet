using meta.Dtos.Stock;
using meta.Models;

namespace meta.Interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetAllStocksAsync();
    Task<Stock?> GetStockByIdAsync(int id);
    Task<Stock> CreateStockAsync(Stock stock);
    Task<Stock?> UpdateStockAsync(int id, UpdateStockRequestDto updatedStock);
    Task<Stock?> DeleteStock(int id);
}