using System;
using System.Collections.Generic;
using System.Text;

namespace Sota.Dashboard.DataAccess.Models.Raw
{
	public class DbFilterValue
	{
		public long Id { get; set; }
		public string FilterCode { get; set; }
		public string Text { get; set; }
		public long? GroupId { get; set; }
	}
}
