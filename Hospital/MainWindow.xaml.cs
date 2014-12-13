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
using Hospital.Pages;
using HospitalLibrary;

namespace Hospital
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private HospitalEntities context;
		private HospitalLibrary.Card _card;
		public HospitalLibrary.Card Card
		{
			get { return _card; }
			private set
			{
				_card = value;
				UserName = value.Name;
				UserAge = value.PatientAge;
				UserAgain = value.IsAgain ? "Again" : "New";
				UserNote = value.NoteText;
			}
		}

		public MainWindow()
		{
			InitializeComponent();
			context = new HospitalEntities();
			context.cards.Load();
			var cards = context.cards.ToList();
			foreach (var card in cards)
			{
				var UIcard = new Hospital.Pages.Card(card);
				UIcard.MouseLeftButtonDown += (sender, args) => 
					Card = ((Hospital.Pages.Card) sender).UserCard;
				CardContainer.Children.Add(UIcard);
			}
		}

		#region Dependendency prop

		public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register(
			"UserName", typeof (String), typeof (MainWindow), new PropertyMetadata(default(String)));

		public String UserName
		{
			get { return (String) GetValue(UserNameProperty); }
			set { SetValue(UserNameProperty, value); }
		}

		public static readonly DependencyProperty UserAgeProperty = DependencyProperty.Register(
			"UserAge", typeof (int), typeof (MainWindow), new PropertyMetadata(default(int)));

		public int UserAge
		{
			get { return (int) GetValue(UserAgeProperty); }
			set { SetValue(UserAgeProperty, value); }
		}

		public static readonly DependencyProperty UserSexProperty = DependencyProperty.Register(
			"UserSex", typeof (string), typeof (MainWindow), new PropertyMetadata(default(string)));

		public string UserSex
		{
			get { return (string) GetValue(UserSexProperty); }
			set { SetValue(UserSexProperty, value); }
		}

		public static readonly DependencyProperty UserAgainProperty = DependencyProperty.Register(
			"UserAgain", typeof (string), typeof (MainWindow), new PropertyMetadata(default(string)));

		public string UserAgain
		{
			get { return (string) GetValue(UserAgainProperty); }
			set { SetValue(UserAgainProperty, value); }
		}

		public static readonly DependencyProperty UserNoteProperty = DependencyProperty.Register(
			"UserNote", typeof (string), typeof (MainWindow), new PropertyMetadata(default(string)));

		public string UserNote
		{
			get { return (string) GetValue(UserNoteProperty); }
			set { SetValue(UserNoteProperty, value); }
		}
		#endregion
	}
}
