using System;
using System.Collections.Generic;
using System.Text;

namespace Sota.Dashboard.DataAccess.Models.Raw
{
	public class DbObjectProp
	{
		public string Name { get; set; }
		public string Value { get; set; }
		public int OrderNumber { get; set; }
		public string IsHeader { get; set; }
		public int Lvl { get; set; }
	}
}
