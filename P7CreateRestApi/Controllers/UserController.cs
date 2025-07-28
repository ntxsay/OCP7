using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Converters;
using P7CreateRestApi.Repositories;
using P7CreateRestApi.ViewModels;

namespace P7CreateRestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;
    private readonly ILogger<UserController> _logger;
    public UserController(IUserRepository repository, ILogger<UserController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [Authorize(Roles = "Admin")]
    [Route("list")]
    public async Task<IActionResult> Home()
    {
        var list = await _repository.ReadResultAllAsync();
        return Ok(list);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    [Route("add")]
    public IActionResult AddUser([FromBody]User user)
    {
        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("validate")]
    public async Task<IActionResult> ValidateAsync([FromBody]User user)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError("Les données reçues ne sont pas valides.");
            return BadRequest();
        }
           
        var isCreated = await _repository.CreateAsync(user.Convert());
        if (!isCreated)
            return BadRequest();

        var list = await _repository.ReadResultAllAsync();
        return Ok(list);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    [Route("update/{id}")]
    public async Task<IActionResult> ShowUpdateForm(int id)
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
    public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError("Les données reçues ne sont pas valides.");
            return BadRequest();
        }
        
        var entity = user.Convert();
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
    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        var isDeleted = await _repository.DeleteAsync(id);
        if (!isDeleted)
            return NotFound();
        
        var list = await _repository.ReadResultAllAsync();
        return Ok(list);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    [Route("/secure/article-details")]
    public async Task<ActionResult<List<User>>> GetAllUserArticles()
    {
        return Ok();
    }
}