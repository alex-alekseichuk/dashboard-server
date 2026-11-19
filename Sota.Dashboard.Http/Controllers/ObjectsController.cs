using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sota.Dashboard.Services;
using Sota.Dashboard.Services.Models;

namespace Sota.Dashboard.Http.Controllers
{
	[Produces("application/json")]
	[Route("api/Objects")]
	public class ObjectsController : Controller
	{
		private readonly IObjectService _objService;

		public ObjectsController(IObjectService objService)
		{
			_objService = objService;
		}

		[HttpGet]
		public ObjectInfoDto Get(long id)
		{
			return _objService.GetObjectInfo(id);
		}

		public List<ObjectShortInfoDto> GetObjectsByFilter(List<long> filterIds)
		{
			// возможно этот метод не нужен будет
			return _objService.GetObjectsShortInfo(filterIds);
		}

		[HttpPost]
		[Route("getObjectsByFilterForTab")]
		public List<ObjectTabInfoDto> GetObjectsByFilterForTab([FromBody]SelectedFiltersBlockDto selectedFilters)
		{
			return _objService.GetObjectsForTab(selectedFilters);
		}
	}
}