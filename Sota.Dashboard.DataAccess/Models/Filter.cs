using System;
using System.Collections.Generic;
using System.Text;

namespace Sota.Dashboard.DataAccess.Models
{
	public class Filter
	{
		public long Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public int Order { get; set; }
		public List<FilterValue> AllowedValues { get; set; }
	}
}
