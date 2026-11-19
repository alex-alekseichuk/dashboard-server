using System;
using System.Collections.Generic;
using System.Text;

namespace Sota.Dashboard.Common.Exceptions
{
	public class CommonException : ApplicationException
	{
		public CommonException() : base() { }
		public CommonException(string message) : base(message) { }
		public CommonException(string message, Exception innerException) : base(message, innerException) { }
	}
}
