using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;
using HospitalLibrary;

namespace Hospital
{
	/// <summary>
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		public LoginWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var context = HospitalEntities.GetEntity();
//			context.users.Load();
			var users = context.GetUsersByName(username.Text);
			if (!users.Any())
			{
				MessageBox.Show("Incorrect username or password");
				return;
			}
			var user = users.First();
			if (user.Password != password.Password)
			{
				MessageBox.Show("Incorrect username or password");
			return;
			}
			var window = new MainWindow(user.Name);
			window.Show();
			this.Hide();
		}
	}
}
