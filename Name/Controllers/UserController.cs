using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using IACSD.DAL;
using IACSD.Model;

namespace Name.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [EnableCors()]
    public IEnumerable<User> GetAllUsers()
    {
        List<User> users = UserDataAcess.GetAllUsers();
        return users;
    }

    [Route("{id}")]
    [HttpGet]
    [EnableCors()]
    public ActionResult<User> GetOneUser(int id)
    {
        User user = UserDataAcess.GetUserById(id);
        return user;
    }

    [Route("/name/  {name}")]
    [HttpGet]
    [EnableCors()]
    public ActionResult<User> GetOneUserbyName(string name)
    {
        User user = UserDataAcess.GetUserByName(name);
        return user;
    }

    [HttpPost]
    [EnableCors()]
    public ActionResult<User> InsertOneUser(User user)
    {
        UserDataAcess.InsertUser(user);
        return Ok(new {message = "User Inserted"});
    }

    [Route("{id}")]
    [HttpPut]
    [EnableCors()]
    public ActionResult<User> UpdateOneUser(User user, int id)
    {
        User res = UserDataAcess.UpdateUser(user, id);
        return res;
    }

    [Route("{id}")]
    [HttpDelete]
    [EnableCors()]
    public ActionResult<User> DeleteOneUser(int id)
    {
        UserDataAcess.DeleteUser(id);
        return Ok(new {message = "User deleted"});
    }
}
