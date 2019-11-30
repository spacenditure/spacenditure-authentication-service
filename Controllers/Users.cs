using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpacenditureAuthentication.Models;
using SpacenditureAuthentication.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace SpacenditureAuthentication.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class Userscontroller : ControllerBase
  {
    private readonly UserDetailDbContext _context;

    public Userscontroller(UserDetailDbContext context)
    {
      _context = context;
    }

    [SwaggerOperation(
      Summary = "Creates a new user",
      Description = "Requires admin privileges",
      OperationId = "CreateUser"
    )]
    [HttpPost]
    public IActionResult Post(UserDetail userDetail)
    {
      byte[] salt = new byte[128 / 8];
      ComputeSha256Hash compute = new ComputeSha256Hash(userDetail.Password, salt);
      string hashedPassword = compute.hashedString;
      userDetail.Password = hashedPassword;
      _context.Users.Add(userDetail);
      _context.SaveChanges();
      return Ok(userDetail);
    }

    [HttpGet]
    public ActionResult<List<UserDetail>> Get()
    {
      List<UserDetail> userDetails = _context.Users.ToList();
      return Ok(userDetails);
    }
  }
}