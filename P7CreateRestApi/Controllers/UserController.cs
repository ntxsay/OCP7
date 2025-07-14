using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Converters;
using P7CreateRestApi.DataTransferObject;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserController> _logger;
    public UserController(IUserRepository userRepository, ILogger<UserController> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    [HttpGet]
    [Route("list")]
    public IActionResult Home()
    {
        return Ok();
    }

    [HttpGet]
    [Route("add")]
    public IActionResult AddUser([FromBody]User user)
    {
        return Ok();
    }

    [HttpGet]
    [Route("validate")]
    public async Task<IActionResult> ValidateAsync([FromBody]User user)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError("Les données reçues ne sont pas valides.");
            return BadRequest();
        }
           
        var isCreated = await _userRepository.CreateAsync(user.Convert());
        if (!isCreated)
            return BadRequest();

        return Ok();
    }

    [HttpGet]
    [Route("update/{id}")]
    public async Task<IActionResult> ShowUpdateForm(int id)
    {
        var user = await _userRepository.ReadAsync(id);
        if (user == null)
            return NotFound();

        return Ok();
    }

    [HttpPost]
    [Route("update/{id}")]
    public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError("Les données reçues ne sont pas valides.");
            return BadRequest();
        }
        
        var entity = user.Convert();
        entity.Id = id;
        
        var isUpdated = await _userRepository.UpdateAsync(entity);
        if (!isUpdated)
            return BadRequest();
        
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        var isDeleted = await _userRepository.DeleteAsync(id);
        if (!isDeleted)
            return NotFound();
        return Ok();
    }

    [HttpGet]
    [Route("/secure/article-details")]
    public async Task<ActionResult<List<User>>> GetAllUserArticles()
    {
        return Ok();
    }
}