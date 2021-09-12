using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var temp = DateTime.Now;
			TimeText.Text = temp.Hour.ToString();
			TimeText.Text += ":";
			TimeText.Text += temp.Minute.ToString();

			DispatcherTimer timer= new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(30);
			timer.Tick += Timer_Tick;
			timer.Start();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			var temp=DateTime.Now;
			TimeText.Text = temp.Hour.ToString();
			TimeText.Text += ":";
			TimeText.Text += temp.Minute.ToString();
		}
		void TopGrid_MouseDown(object sender, MouseButtonEventArgs e)
		{
			//you must be change there Event useButtonState.Presse )
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				DragMove();
			}
		}

		private void ImageBrush_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton==MouseButtonState.Released)
			{

			}
		}
	}
}
