using System;

namespace XPTOMVC.Services.Exceptions
{
	public class IntegrityException : ApplicationException
	{
		public IntegrityException(string message) : base(message) { }
	}
}
