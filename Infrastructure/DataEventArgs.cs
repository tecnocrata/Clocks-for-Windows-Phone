using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Modulo6.Actividad1
{
	public class DataEventArgs<T>: EventArgs
	{
		public T Data { get; set; }

		public DataEventArgs(T data)
		{
			Data = data;
		}
	}
}
