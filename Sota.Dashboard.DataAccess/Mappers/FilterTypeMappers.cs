using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using Sota.Dashboard.DataAccess.Exceptions;
using Sota.Dashboard.DataAccess.Models;
using Sota.Dashboard.DataAccess.Models.Raw;
using Sota.Dashboard.Common.Constants;

namespace Sota.Dashboard.DataAccess.Mappers
{
	public static class FilterTypeMappers
	{
		public static string MapTypeToName(this string filterType)
		{
			switch (filterType)
			{
				case FilterTypeConstants.TRANS_TYPE: return "Вид транспорта";
				case FilterTypeConstants.RAILWAY: return "Ж/д дороги";
				case FilterTypeConstants.ROAD: return "Регионы";
				case FilterTypeConstants.SEA: return "Порты";
				case FilterTypeConstants.AVIA: return "Аэропорты";
				default: return String.Empty;
			}
		}

		public static Filter Map(this List<DbFilter> data)
		{
			var first = data.First();
			var filterCode = first.FilterCode;
			var order = first.Ord;
			var filterName = first.FilterName;

			var res = new Filter()
			{
				Id = first.Id,
				Code = filterCode,
				Name = filterName,
				Order = order,
				AllowedValues = data.Where(x => x.FilterCode == filterCode).Select(x => new FilterValue()
				{
					Id = Convert.ToInt64(x.Id),
					Text = x.Text,
					IsActive = x.IsActualRow
				}).OrderBy(x => x.Text).ToList()
			};
			return res;
		}
	}
}
