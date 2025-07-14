using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Converters;
using P7CreateRestApi.DataTransferObject;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RuleNameController : ControllerBase
{
    private readonly IRuleRepository _repository;
    private readonly ILogger<RuleNameController> _logger;
    public RuleNameController(IRuleRepository repository, ILogger<RuleNameController> logger)
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
    public IActionResult AddRuleName([FromBody]RuleName trade)
    {
        return Ok();
    }

    [HttpGet]
    [Route("validate")]
    public async Task<IActionResult> ValidateAsync([FromBody]RuleName rule)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError("Les données reçues ne sont pas valides.");
            return BadRequest();
        }
           
        var isCreated = await _repository.CreateAsync(rule.Convert());
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
    public async Task<IActionResult> UpdateRuleNameAsync(int id, [FromBody] RuleName rule)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError("Les données reçues ne sont pas valides.");
            return BadRequest();
        }
        
        var entity = rule.Convert();
        entity.Id = id;
        
        var isUpdated = await _repository.UpdateAsync(entity);
        if (!isUpdated)
            return BadRequest();
        
        var list = await _repository.ReadResultAllAsync();
        return Ok(list);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteRuleNameAsync(int id)
    {
        var isDeleted = await _repository.DeleteAsync(id);
        if (!isDeleted)
            return NotFound();
        
        var list = await _repository.ReadResultAllAsync();
        return Ok(list);
    }
}