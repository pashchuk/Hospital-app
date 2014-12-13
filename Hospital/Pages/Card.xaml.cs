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
using HospitalLibrary;

namespace Hospital.Pages
{
	/// <summary>
	/// Interaction logic for Card.xaml
	/// </summary>
	public partial class Card : UserControl
	{
		public HospitalLibrary.Card UserCard { get; set; }

		public Card(HospitalLibrary.Card userCard)
		{
			InitializeComponent();
			UserCard = userCard;
			UserName = UserCard.Name;
			UserAge = UserCard.PatientAge;
			UserSex = UserCard.PatientSex.ToLower() == "male" ? "Man" : "Woman";
		}

		public Card()
		{ }

	public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register(
			"UserName", typeof (String), typeof (Card), new PropertyMetadata(default(String)));

		public String UserName
		{
			get { return (String) GetValue(UserNameProperty); }
			set { SetValue(UserNameProperty, value); }
		}

		public static readonly DependencyProperty UserAgeProperty = DependencyProperty.Register(
			"UserAge", typeof (int), typeof (Card), new PropertyMetadata(default(int)));

		public int UserAge
		{
			get { return (int) GetValue(UserAgeProperty); }
			set { SetValue(UserAgeProperty, value); }
		}

		public static readonly DependencyProperty UserSexProperty = DependencyProperty.Register(
			"UserSex", typeof (String), typeof (Card), new PropertyMetadata(default(String)));

		public String UserSex
		{
			get { return (String) GetValue(UserSexProperty); }
			set { SetValue(UserSexProperty, value); }
		}
	}
}