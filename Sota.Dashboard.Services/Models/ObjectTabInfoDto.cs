using System;
using System.Collections.Generic;
using System.Text;

namespace Sota.Dashboard.Services.Models
{
	public class ObjectTabInfoDto
	{
		public long Id { get; set; }
		public string ShortName { get; set; }
		public string FullName { get; set; }
		public string Region { get; set; }
	}
}
