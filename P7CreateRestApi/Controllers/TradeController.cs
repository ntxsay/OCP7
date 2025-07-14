using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Converters;
using P7CreateRestApi.DataTransferObject;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TradeController : ControllerBase
{
    private readonly ITradeRepository _repository;
    private readonly ILogger<TradeController> _logger;
    public TradeController(ITradeRepository repository, ILogger<TradeController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> Home()
    {
        var list = await _repository.ReadResultAllAsync();
        return Ok(list);
    }

    [HttpGet]
    [Route("add")]
    public IActionResult AddTrade([FromBody]Trade trade)
    {
        return Ok();
    }

    [HttpGet]
    [Route("validate")]
    public async Task<IActionResult> ValidateAsync([FromBody]Trade trade)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError("Les données reçues ne sont pas valides.");
            return BadRequest();
        }
           
        var isCreated = await _repository.CreateAsync(trade.Convert());
        if (!isCreated)
            return BadRequest();

        var list = await _repository.ReadResultAllAsync();
        return Ok(list);
    }

    [HttpGet]
    [Route("update/{id}")]
    public async Task<IActionResult> ShowUpdateFormAsync(int id)
    {
        var result = await _repository.ReadResultAsync(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    [Route("update/{id}")]
    public async Task<IActionResult> UpdateTradeAsync(int id, [FromBody] Trade trade)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError("Les données reçues ne sont pas valides.");
            return BadRequest();
        }
        
        var entity = trade.Convert();
        entity.Id = id;
        
        var isUpdated = await _repository.UpdateAsync(entity);
        if (!isUpdated)
            return BadRequest();
        
        var list = await _repository.ReadResultAllAsync();
        return Ok(list);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteTradeAsync(int id)
    {
        var isDeleted = await _repository.DeleteAsync(id);
        if (!isDeleted)
            return NotFound();
        
        var list = await _repository.ReadResultAllAsync();
        return Ok(list);
    }
}