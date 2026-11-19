using System;
using System.Collections.Generic;
using System.Text;

namespace Sota.Dashboard.DataAccess.Exceptions
{
	public class DataAccessMappingException : DataAccessException
	{
		public DataAccessMappingException() : base() { }
		public DataAccessMappingException(string message) : base(message) { }
		public DataAccessMappingException(string message, Exception innerException) : base(message, innerException) { }
	}
}
