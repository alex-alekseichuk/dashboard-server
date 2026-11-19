using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sota.Dashboard.Services;

namespace Sota.Dashboard.Http.Controllers
{
  [Route("api/v1/[controller]")]
  [ApiController]
  public class EntityController : ControllerBase
  {
    private readonly IEntityService entityService;

    public EntityController(IEntityService entityService) {
      this.entityService = entityService;
    }

    // GET api/entity/5
    [HttpGet("{id}")]
    public ActionResult<Object> Get(int id)
    {
      return new {
        attrs = entityService.getEntityAttributes(id)
      };
    }
  }
}
