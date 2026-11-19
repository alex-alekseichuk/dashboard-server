using System.Collections.Generic;
using System.Linq;
using Sota.Dashboard.Services.Mappers;
using Sota.Dashboard.DataAccess;
using Sota.Dashboard.Services.Models;
using Sota.Dashboard.Common.Constants;
// using Serilog;
// using Serilog.Core;

namespace Sota.Dashboard.Services
{
  public interface IFilterService
	{
		FilterBlockDto GetFilters(SelectedFiltersBlockDto selectedFilters);
	}

	public class FilterService : IFilterService
	{
		private readonly IFilterRepository _fRepo;

		public FilterService(IFilterRepository fRepo)
		{
			_fRepo = fRepo;
		}

		public FilterBlockDto GetFilters(SelectedFiltersBlockDto selectedFilters)
		{
			var targetSelectedValues = selectedFilters?.Values != null && selectedFilters.Values.Any()
										   ? selectedFilters.Values.SelectMany(x => x.SelectedValues).ToList()
										   : new List<long>();

			var filters = _fRepo.GetFilters(targetSelectedValues).Map();
			return new FilterBlockDto
			{
				Filters = filters
			};
		}
		private FilterBlockDto GetFakeFilters(SelectedFiltersBlockDto selectedFilters)
		{
			return null;
		}
	}
}