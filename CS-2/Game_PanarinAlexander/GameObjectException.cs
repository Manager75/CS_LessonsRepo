using System;
using System.Runtime.Serialization;

namespace Game_PanarinAlexander
{
	class GameObjectException : Exception
	{
		public GameObjectException()
		{
		}

		public GameObjectException(string message) : base(message)
		{
			Console.WriteLine(message);
		}

		public GameObjectException(string message, Exception innerException) : base(message, innerException)
		{
			Console.WriteLine($"{message}, {innerException.Message}.");
		}

		protected GameObjectException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
