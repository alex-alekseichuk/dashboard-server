using System.Collections.Generic;
using System.Linq;
using Sota.Dashboard.DataAccess.Models;
using Sota.Dashboard.Services.Models;

namespace Sota.Dashboard.Services.Mappers
{
	public static class FilterMappers
	{
		public static FilterDto Map(this Filter filter)
		{
			return new FilterDto
			{
				Id = filter.Id,
				Code = filter.Code,
				Name = filter.Name,
				Order = filter.Order,
				AllowedValues = filter.AllowedValues.Select(x => x.Map()).ToList()
			};
		}

		public static List<FilterDto> Map(this List<Filter> filter)
		{
			return filter.Select(x => x.Map()).ToList();
		}

		public static FilterValueDto Map(this FilterValue value)
		{
			return new FilterValueDto
			{
				Id = value.Id,
				Text = value.Text,
				IsActive = value.IsActive
			};
		}
	}
}