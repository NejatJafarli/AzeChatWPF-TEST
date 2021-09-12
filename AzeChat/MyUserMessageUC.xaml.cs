using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AzeChat
{
	/// <summary>
	/// Interaction logic for MyUserMessageUC.xaml
	/// </summary>
	public partial class MyUserMessageUC : UserControl
	{
		public MyUserMessageUC()
		{
			InitializeComponent();
		
			TimeText.Text =DateTime.Now.Hour.ToString();
			TimeText.Text += ":";
			TimeText.Text +=DateTime.Now.Minute.ToString();
		}


}
}
