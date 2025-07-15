using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Abstractions;
using P7CreateRestApi.Converters;
using P7CreateRestApi.DataTransferObject;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CurveController : ControllerBase
{
    private readonly ICurvePointRepository _repository;
    private readonly ILogger<CurveController> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CurveController(ICurvePointRepository repository, ILogger<CurveController> logger, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> Home()
    {
        var list = await _repository.ReadResultAllAsync();
        return Ok(list);
    }

    [Authorize]
    [HttpGet]
    [Route("add")]
    public IActionResult AddCurvePoint([FromBody]CurvePoint curvePoint)
    {
        return Ok();
    }

    [Authorize]
    [HttpPost]
    [Route("validate")]
    public async Task<IActionResult> ValidateAsync([FromBody]CurvePoint curvePoint)
    {
        if (_httpContextAccessor.HttpContext != null && 
            !_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            _logger.LogWarning("Tentative d'accès non autorisée.");
            return Unauthorized();
        }
        if (!ModelState.IsValid)
        {
            _logger.LogError("Les données reçues ne sont pas valides.");
            return BadRequest();
        }
           
        var isCreated = await _repository.CreateAsync(curvePoint.Convert());
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
    public async Task<IActionResult> UpdateCurvePointAsync(int id, [FromBody] CurvePoint curvePoint)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError("Les données reçues ne sont pas valides.");
            return BadRequest();
        }
        
        var entity = curvePoint.Convert();
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
    public async Task<IActionResult> DeleteCurvePointAsync(int id)
    {
        var isDeleted = await _repository.DeleteAsync(id);
        if (!isDeleted)
            return NotFound();
        
        var list = await _repository.ReadResultAllAsync();
        return Ok(list);
    }
}