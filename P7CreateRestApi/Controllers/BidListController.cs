using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Converters;
using P7CreateRestApi.DataTransferObject;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BidListController : ControllerBase
{
    private readonly IBidRepository _repository;
    private readonly ILogger<BidListController> _logger;
    public BidListController(IBidRepository repository, ILogger<BidListController> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    
    [Authorize]
    [HttpPost]
    [Route("validate")]
    public async Task<IActionResult> ValidateAsync([FromBody] BidList bidList)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError("Les données reçues ne sont pas valides.");
            return BadRequest();
        }
           
        var isCreated = await _repository.CreateAsync(bidList.Convert());
        if (!isCreated)
            return BadRequest();

        var list = await _repository.ReadResultAllAsync();
        return Ok(list);
    }

    [Authorize]
    [HttpGet]
    [Route("update/{id}")]
    public async Task<IActionResult> ShowUpdateFormAsync(int id)
    {
        var result = await _repository.ReadResultAsync(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    [Route("update/{id}")]
    public async Task<IActionResult> UpdateBidAsync(int id, [FromBody] BidList bidList)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError("Les données reçues ne sont pas valides.");
            return BadRequest();
        }
        
        var entity = bidList.Convert();
        entity.Id = id;
        
        var isUpdated = await _repository.UpdateAsync(entity);
        if (!isUpdated)
            return BadRequest();
        
        var list = await _repository.ReadResultAllAsync();
        return Ok(list);
    }

    [Authorize]
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteBidAsync(int id)
    {
        var isDeleted = await _repository.DeleteAsync(id);
        if (!isDeleted)
            return NotFound();
        return Ok();
    }
}