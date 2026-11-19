using System;
using System.Collections.Generic;
using System.Text;

namespace Sota.Dashboard.DataAccess.Models
{
	public class TransportType
	{
		//CODE - код фильтра;
		//ORD - порядковый номер фильтра;
		//DIMENTION_ID - идентификатор справочника источника для фильтра;
		//ID - поле справочника - идентификатор;
		//TEXT - поле справочника - текст для отображения;


		/// <summary>
		/// Код фильтра
		/// </summary>
		public string Code { get; set; }
		/// <summary>
		/// Порядковый номер фильтра
		/// </summary>
		public int Order { get; set; }
		/// <summary>
		/// Идентификатор справочника источника для фильтра
		/// </summary>
		public long DimentionId { get; set; }
		/// <summary>
		/// Поле справочника - идентификатор
		/// </summary>
		public long ReferenceId { get; set; }
		/// <summary>
		/// Поле справочника - текст для отображения
		/// </summary>
		public string ReferenceText { get; set; }
	}
}
