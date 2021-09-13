using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
		List<string> Cavablar= new List<string>();
		Random random = new Random();
		public MainWindow()
		{
			InitializeComponent();

			DataText.Focus();

			Cavablar.Add("Goresen Biz Ha Vaxt Isleyeceyik?");
			Cavablar.Add("Sabah Derse Gelecem");
			Cavablar.Add("Valorant Gelirsiz?");
			Cavablar.Add("Usaqlar Mene Kodu Atinda Geride Qaldim");

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
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				DragMove();
			}
		}

		private void ImageBrush_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (DataText.Text.Length > 0)
			{
				MyUserMessageUC UserMessage = new MyUserMessageUC();
				UserMessage.DataText.Text = DataText.Text;
				UserMessage.DataText.FontSize = 20;
				UserMessage.HorizontalAlignment = HorizontalAlignment.Right;
				UserMessage.Margin = new Thickness(10, 8, 5, 0);
				MessagesPanel.Items.Add(UserMessage);

				MyUserMessageUC ReMessage = new MyUserMessageUC();

				Task.Run(() =>
				{
					Thread.Sleep(500);

					Application.Current.Dispatcher.Invoke(() =>
					{
						ReMessage.DataText.Foreground = Brushes.Black;
						ReMessage.DataText.Text = Cavablar[random.Next(0,Cavablar.Count)];
						ReMessage.DataText.FontSize = 20;
						ReMessage.HorizontalAlignment = HorizontalAlignment.Left;
						ReMessage.Margin = new Thickness(0, 0, 0, 10);
						ReMessage.MainBorder.Background = Brushes.LightGray;
						MessagesPanel.Items.Add(ReMessage);
						MessagesPanel.Items.MoveCurrentToLast();
						MessagesPanel.ScrollIntoView(MessagesPanel.Items.CurrentItem);
					});
				});
				DataText.Text = "";


				MessagesPanel.Items.MoveCurrentToLast();
				MessagesPanel.ScrollIntoView(MessagesPanel.Items.CurrentItem);

				DataText.Focus();
			}
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
