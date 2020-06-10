using System;
using System.IO;

namespace Game_PanarinAlexander
{
	static class Log
	{
        /// <summary>
        /// Метод отображения всех записей на кого подписан текущий пользователь
        /// </summary>
        /// <param name="Msg">Содержание сообщения конкретного поста</param>
        static public void LogConsole(object sender, MessageArgs Msg)
        {
            var baseObj = sender as BaseObject;
            Console.WriteLine($"Стена >>> {baseObj.GetType()} опубликовал: {Msg.Message}\n");
        }

		static public void LogFile(object sender, MessageArgs Msg)
		{
			var baseObj = sender as BaseObject;
			File.AppendAllText("Log.txt", $"Стена >>> {baseObj.GetType()} опубликовал: {Msg.Message}\n");
		}

		static public void LogStreamWrite(object sender, MessageArgs Msg)
		{
			using (var sw = new StreamWriter($"{sender.GetType()}_wall.txt", true))
			{
				var baseObj = sender as BaseObject;
				sw.WriteLine($"Стена >>> {baseObj.GetType()} опубликовал: {Msg.Message}\n");
			}
		}
	}
}
