using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Converters;
using P7CreateRestApi.Repositories;
using P7CreateRestApi.ViewModels;

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
    [Authorize]
    public async Task<IActionResult> Home()
    {
        var list = await _repository.ReadResultAllAsync();
        return Ok(list);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    [Route("add")]
    public IActionResult AddTrade([FromBody]Trade trade)
    {
        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("validate")]
    [ValidateAntiForgeryToken]
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

    [Authorize(Roles = "Admin")]
    [HttpGet]
    [Route("update/{id}")]
    public async Task<IActionResult> ShowUpdateFormAsync(int id)
    {
        var result = await _repository.ReadResultAsync(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("update/{id}")]
    [ValidateAntiForgeryToken]
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

    [Authorize(Roles = "Admin")]
    [HttpDelete]
    [Route("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteTradeAsync(int id)
    {
        var isDeleted = await _repository.DeleteAsync(id);
        if (!isDeleted)
            return NotFound();
        
        var list = await _repository.ReadResultAllAsync();
        return Ok(list);
    }
}