using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Converters;
using P7CreateRestApi.Repositories;
using P7CreateRestApi.ViewModels;

namespace P7CreateRestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RatingController : ControllerBase
{
    private readonly IRatingRepository _repository;
    private readonly ILogger<RatingController> _logger;
    public RatingController(IRatingRepository repository, ILogger<RatingController> logger)
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

    [Authorize(Roles = "Admin")]
    [HttpGet]
    [Route("add")]
    public IActionResult AddRatingForm([FromBody]Rating rating)
    {
        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("validate")]
    public async Task<IActionResult> ValidateAsync([FromBody]Rating rating)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError("Les données reçues ne sont pas valides.");
            return BadRequest();
        }
           
        var isCreated = await _repository.CreateAsync(rating.Convert());
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
    public async Task<IActionResult> UpdateRatingAsync(int id, [FromBody] Rating rating)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError("Les données reçues ne sont pas valides.");
            return BadRequest();
        }
        
        var entity = rating.Convert();
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
    public async Task<IActionResult> DeleteRatingAsync(int id)
    {
        var isDeleted = await _repository.DeleteAsync(id);
        if (!isDeleted)
            return NotFound();
        
        var list = await _repository.ReadResultAllAsync();
        return Ok(list);
    }
}