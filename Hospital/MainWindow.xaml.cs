using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
using HospitalLibrary;

namespace Hospital
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private HospitalEntities context;
		public MainWindow()
		{
			InitializeComponent();
			context = new HospitalEntities();
			context.users.Load();
			context.notes.Load();
			context.cards.Load();
			context.sessions.Load();
			context.diagnosis.Load();
			context.groups.Load();
			DataGrid_Users.ItemsSource = context.users.Local.ToBindingList();
			DataGrid_Notes.ItemsSource = context.notes.Local.ToBindingList();
			DataGrid_Cards.ItemsSource = context.cards.Local.ToBindingList();
			DataGrid_Sessions.ItemsSource = context.sessions.Local.ToBindingList();
			DataGrid_Diagnosis.ItemsSource = context.diagnosis.Local.ToBindingList();
			DataGrid_Groups.ItemsSource = context.groups.Local.ToBindingList();
		}
	}
}
