using System;
using System.Collections.Generic;
using System.Linq;
using Sota.Dashboard.DataAccess.Models;
using Sota.Dashboard.Services.Models;

namespace Sota.Dashboard.Services.Mappers
{
	public static class EntityMappers
	{
		public static Entity Map(this EntityDbo data)
		{
			if (data == null) return null;
			return new Entity
			{
				Name = data.Name,
				Value = data.Value,
				OrderNumber = data.OrderNumber,
				IsHeader = data.IsHeader,
        Lvl = data.Lvl
			};
		}

    public static IEnumerable<Entity> Map(this IEnumerable<EntityDbo> data)
		{
			return data?.Select(x => x.Map()).ToList();
		}
  }
}