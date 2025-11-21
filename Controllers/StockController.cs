using meta.Dtos.Stock;
using meta.Interfaces;
using meta.Mappers;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace meta.Controllers

{
    [Route("api/stock")]
    [ApiController]
    public class StockController( IStockRepository repo, IMapper mapper) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;  
        private readonly IStockRepository _repo = repo;
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            var stocks = await _repo.GetAllStocksAsync();
            var stocksDto = _mapper.Map<IEnumerable<StockDto>>(stocks);
            return Ok(stocksDto);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _repo.GetStockByIdAsync(id);
            if (stock == null)
            {
                return NotFound();

            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task <IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDto();
            await  _repo.CreateStockAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>Update([FromRoute] int id, [FromBody] UpdateStockRequestDto stockDto)
        {
            var stockModel = await _repo.GetStockByIdAsync(id);
            if (stockModel == null)
            {
                return NotFound();

            }
            var newStock = await _repo.UpdateStockAsync(id, stockDto);
            return Ok(newStock.ToStockDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _repo.DeleteStock(id);
            if (stockModel == null)
            {
                return NotFound();
            }
           
            return NoContent();
    }
}
}  
