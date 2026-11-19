using System;
using System.Collections.Generic;
using System.Text;

namespace Sota.Dashboard.DataAccess.Models
{
	public class FilterValue
	{
		public long Id { get; set; }
		public string Text { get; set; }
		public bool IsActive { get; set; }
	}
}
