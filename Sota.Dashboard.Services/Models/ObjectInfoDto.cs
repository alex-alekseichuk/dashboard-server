using System;
using System.Collections.Generic;
using System.Text;

namespace Sota.Dashboard.Services.Models
{
	public class ObjectInfoDto
	{
		public long Id { get; set; }
		public List<ObjectProp> Props { get; set; }
	}
}
