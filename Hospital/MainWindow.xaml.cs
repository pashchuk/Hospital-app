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
		private Hospital.Pages.Card _prevCard;
		private HospitalEntities context;
		private HospitalLibrary.Card _card;
		public HospitalLibrary.Card Card
		{
			get { return _card; }
			private set
			{
				_card = value;
				UserName = value.Name;
				UserSex = value.PatientSex;
				UserAge = value.PatientAge;
				UserAgain = value.IsAgain ? "Again" : "New";
				UserNote = value.NoteText;
				Notes = value.notes.ToList();
				Sessions = value.sessions.ToList();
			}
		}

		public MainWindow(string userName)
		{
			InitializeComponent();
			this.userName.Text = userName;
			context = new HospitalEntities();
			context.cards.Load();
			var cards = context.cards.ToList();
			var list = new List<Hospital.Pages.Card>();
			foreach (var card in cards)
			{
				var UIcard = new Hospital.Pages.Card(card);
				UIcard.MouseLeftButtonDown += (sender, args) =>
				{
					var activeCard = (Hospital.Pages.Card) sender;
					Card = activeCard.UserCard;
					activeCard.Rectangle.Fill = new SolidColorBrush(Color.FromArgb(255, 110, 130, 130));
					activeCard.MouseLeave -= UIcard_MouseLeave;
					if (_prevCard != null)
					{
						_prevCard.Rectangle.Fill = new SolidColorBrush(Color.FromArgb(255, 47, 79, 79));
						_prevCard.MouseLeave += UIcard_MouseLeave;
					}
					_prevCard = activeCard;
				}; 
				UIcard.MouseEnter += (sender, args) =>
					((Hospital.Pages.Card) sender).Rectangle.Fill = new SolidColorBrush(Color.FromArgb(255, 80, 100, 100));
				UIcard.MouseLeave += UIcard_MouseLeave;
				list.Add(UIcard);
			}
			Cards = list;
			this.Closed += (sender, args) => Application.Current.Shutdown();
		}

		private void UIcard_MouseLeave(object sender, MouseEventArgs e)
		{
			((Hospital.Pages.Card) sender).Rectangle.Fill = new SolidColorBrush(Color.FromArgb(255, 47, 79, 79));
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

		public static readonly DependencyProperty CardsProperty = DependencyProperty.Register(
			"Cards", typeof (List<Hospital.Pages.Card>), typeof (MainWindow), new PropertyMetadata(default(List<Hospital.Pages.Card>)));

		public List<Hospital.Pages.Card> Cards
		{
			get { return (List<Hospital.Pages.Card>) GetValue(CardsProperty); }
			set { SetValue(CardsProperty, value); }
		}

		public static readonly DependencyProperty NotesProperty = DependencyProperty.Register(
			"Notes", typeof (List<HospitalLibrary.Note>), typeof (MainWindow), new PropertyMetadata(default(List<HospitalLibrary.Note>)));

		public List<HospitalLibrary.Note> Notes
		{
			get { return (List<HospitalLibrary.Note>) GetValue(NotesProperty); }
			set { SetValue(NotesProperty, value); }
		}

		public static readonly DependencyProperty SessionsProperty = DependencyProperty.Register(
			"Sessions", typeof (List<HospitalLibrary.Session>), typeof (MainWindow), new PropertyMetadata(default(List<HospitalLibrary.Session>)));

		public List<HospitalLibrary.Session> Sessions
		{
			get { return (List<HospitalLibrary.Session>) GetValue(SessionsProperty); }
			set { SetValue(SessionsProperty, value); }
		}
		#endregion
	}
}
