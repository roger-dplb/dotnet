using AutoMapper;

namespace meta.Mappers;

public class StocksProfile: Profile
{
    public StocksProfile()
    {
        CreateMap<Models.Stock, Dtos.Stock.StockDto>();
        CreateMap<Dtos.Stock.CreateStockRequestDto, Models.Stock>();
        CreateMap<Dtos.Stock.UpdateStockRequestDto, Models.Stock>();
    }
    
}