using System;
using System.Collections.Generic;
using System.Text;

namespace Sota.Dashboard.Services.Models
{
	public class FilterBlockDto
	{
		public FilterBlockDto()
		{
			Filters = new List<FilterDto>();
		}
		public List<FilterDto> Filters { get; set; }
	}

	public class FilterDto
	{
		public FilterDto()
		{
			AllowedValues = new List<FilterValueDto>();
		}

		public long Id { get; set; }

		/// <summary>
		/// Тип фильтра
		/// </summary>
		public string Code { get; set; }
		/// <summary>
		/// Название фильтра
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Порядок фильтра
		/// </summary>
		public int Order { get; set; }

		/// <summary>
		/// Коллекция допустимых значений для фильтра
		/// </summary>
		public List<FilterValueDto> AllowedValues { get; set; }
	}

	public class FilterValueDto
	{
		/// <summary>
		/// Идентификатор значения
		/// </summary>
		public long Id { get; set; }
		/// <summary>
		/// Название значения
		/// </summary>
		public string Text { get; set; }

		public bool IsActive { get; set; }
	}

	public class SelectedFiltersBlockDto
	{
		public List<SelectedFilterValueDto> Values { get; set; }
	}

	public class SelectedFilterValueDto
	{
		public string FilterCode { get; set; }
		public List<long> SelectedValues { get; set; }
	}
}
