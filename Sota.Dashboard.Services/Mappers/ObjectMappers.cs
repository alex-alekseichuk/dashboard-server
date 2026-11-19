using System;
using System.Collections.Generic;
using System.Linq;
using Sota.Dashboard.DataAccess.Models.Raw;
using Sota.Dashboard.Services.Models;

namespace Sota.Dashboard.Services.Mappers
{
	public static class ObjectMappers
	{
		public static ObjectShortInfoDto Map(this DbObjectShortInfo data)
		{
			if (data == null) return null;
			return new ObjectShortInfoDto
			{
				Id = data.EntityId,
				Text = data.Text
			};
		}

		public static List<ObjectShortInfoDto> Map(this List<DbObjectShortInfo> data)
		{
			return data?.Select(x => x.Map()).ToList();
		}


		public static ObjectProp Map(this DbObjectProp data)
		{
			if (data == null) return null;
			return new ObjectProp
			{
				Name = data.Name,
				Order = data.OrderNumber,
				IsHeader = !string.IsNullOrEmpty(data.IsHeader) && data.IsHeader.Equals("Y", StringComparison.InvariantCultureIgnoreCase),
				Level = data.Lvl,
				Value = data.Value
			};
		}

		public static List<ObjectProp> Map(this List<DbObjectProp> data)
		{
			return data?.Select(x => x.Map()).ToList();
		}

		public static ObjectTabInfoDto Map(this DbObjectTabInfo data)
		{
			if (data == null) return null;
			return new ObjectTabInfoDto
			{
				Id = data.EntityId,
				ShortName = data.ShortName,
				FullName = data.FullName,
				Region = data.Region
			};
		}

		public static List<ObjectTabInfoDto> Map(this List<DbObjectTabInfo> data)
		{
			return data?.Select(x => x.Map()).ToList();
		}
	}
}