using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pmonapi.Domains.Services;
using pmonapi.Extensions;
using pmonapi.Resources;

namespace pmonapi.Controllers {
  [Route ("/[controller]")]
  public class MasterUserController : ControllerBase {

    private readonly IServiceMasterUser _serviceMasterUser;
    public MasterUserController (IServiceMasterUser serviceMasterUser) {
      _serviceMasterUser = serviceMasterUser;
    }

    // detail user
    [HttpGet ("{id}")]
    public async Task<IActionResult> Detail (int id) {
      var response = await _serviceMasterUser.Detail (id);

      if (!response._rs) return BadRequest (response._rt);

      return Ok (response);
    }

    // buat user
    [HttpPost]
    public async Task<IActionResult> Create ([FromBody] ResourceMasterUser.Create data) {
      if (!ModelState.IsValid) return BadRequest (ModelState.GetErrorMessages ());

      var response = await _serviceMasterUser.Create (data, "");

      if (!response._rs) return BadRequest (response._rt);

      return Ok (response);
    }

  }

}