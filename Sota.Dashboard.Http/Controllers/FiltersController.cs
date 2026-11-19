using Microsoft.AspNetCore.Mvc;
using Sota.Dashboard.Services;
using Sota.Dashboard.Services.Models;

namespace Sota.Dashboard.Http.Controllers
{
	[Produces("application/json")]
	[Route("api/Filter")]
	public class FiltersController : Controller
	{
		private readonly IFilterService _filterService;

		public FiltersController(IFilterService filterService)
		{
			_filterService = filterService;
		}

		[HttpPost]
		[Route("getFilters")]
		public FilterBlockDto GetFilters([FromBody] SelectedFiltersBlockDto selectedFilters)
		{
			return _filterService.GetFilters(selectedFilters);
		}
	}
}