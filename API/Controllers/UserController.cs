using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

public class UsersController : BaseApiController
{
    private readonly DataContext _dataContext;

    public UsersController(DataContext dataContext) {
        _dataContext = dataContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers() {
        var users = await _dataContext.Users.ToListAsync();

        return this.Ok(users);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetUser(int id) {
        var user = await _dataContext.Users.FindAsync(id);

        return this.Ok(user);
    }
}
