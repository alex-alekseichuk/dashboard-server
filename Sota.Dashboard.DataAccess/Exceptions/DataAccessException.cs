using System;
using System.Collections.Generic;
using System.Text;
using Sota.Dashboard.Common.Exceptions;

namespace Sota.Dashboard.DataAccess.Exceptions
{
	public class DataAccessException : CommonException
	{
		public DataAccessException() : base() { }
		public DataAccessException(string message) : base(message) { }
		public DataAccessException(string message, Exception innerException) : base(message, innerException) { }
	}
}
