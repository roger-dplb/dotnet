using meta.Dtos.Stock;
using meta.Models;

namespace meta.Mappers;

public static class StockMappers
{
    public static StockDto ToStockDto(this Stock stockModel)
    {
        return new StockDto
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Purchase = stockModel.Purchase,
            Divdend = stockModel.Divdend,
            LastDiv = stockModel.LastDiv,
            Industry = stockModel.Industry,
            MarketCap = stockModel.MarketCap

        };
    }

    public static Stock ToStockFromCreateDto(this CreateStockRequestDto createStockRequestDto)
    {
        return new Stock
        {
            Symbol = createStockRequestDto.Symbol,
            CompanyName = createStockRequestDto.CompanyName,
            Purchase = createStockRequestDto.Purchase,
            Divdend = createStockRequestDto.Divdend,
            LastDiv = createStockRequestDto.LastDiv,
            Industry = createStockRequestDto.Industry,
            MarketCap = createStockRequestDto.MarketCap
        };
    }
}


