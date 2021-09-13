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

			DataText.Focus();


			var temp = DateTime.Now;
			TimeText.Text = temp.Hour.ToString();
			TimeText.Text += ":";
			TimeText.Text += temp.Minute.ToString();

			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(30);
			timer.Tick += Timer_Tick;
			timer.Start();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			var temp = DateTime.Now;
			TimeText.Text = temp.Hour.ToString();
			TimeText.Text += ":";
			TimeText.Text += temp.Minute.ToString();
		}
		private void TopGrid_MouseDown(object sender, MouseButtonEventArgs e)
		{
			//you must be change there Event useButtonState.Presse )
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				DragMove();
			}
		}

		private void ImageBrush_MouseDown(object sender, MouseButtonEventArgs e)
		{
			MyUserMessageUC UserMessage = new MyUserMessageUC();
			UserMessage.DataText.Text = DataText.Text;
			UserMessage.DataText.FontSize = 20;
			UserMessage.HorizontalAlignment = HorizontalAlignment.Right;
			UserMessage.Margin = new Thickness(10, 8, 5, 0);
			MessagesPanel.Items.Add(UserMessage);

			MyUserMessageUC ReMessage = new MyUserMessageUC();

			ReMessage.MainBorder.Background = Brushes.LightGray;
			ReMessage.DataText.Foreground = Brushes.Black;
			ReMessage.DataText.Text = DataText.Text;
			ReMessage.DataText.FontSize = 20;
			ReMessage.HorizontalAlignment = HorizontalAlignment.Left;
			ReMessage.Margin = new Thickness(0, 0, 0, 10);
			MessagesPanel.Items.Add(ReMessage);


			MessagesPanel.Items.MoveCurrentToLast();
			MessagesPanel.ScrollIntoView(MessagesPanel.Items.CurrentItem);

			DataText.Text = "";
			DataText.Focus();
		}

		private void Image_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Application.Current.Shutdown();
		}


		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				ImageBrush_MouseDown(sender, null);
			}
		}
	}
}
