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
using System.Windows.Shapes;
using HospitalLibrary;

namespace Hospital.Windows
{
	/// <summary>
	/// Interaction logic for Card.xaml
	/// </summary>
	public partial class Card : Window
	{
		private WindowState _state;
		private int _modifyCardID;
		public Card()
		{
			InitializeComponent();
			_state = WindowState.Create;
		}

		public Card(HospitalLibrary.Card card, WindowState state) : this()
		{
			cardName.Text = card.Name;
			cardAge.Text = card.PatientAge.ToString();
			cardSex.SelectedIndex = card.PatientSex == "male" ? 0 : 1;
			cardAgain.SelectedIndex = card.IsAgain ? 1 : 0;
			cardNote.Text = card.NoteText;
			_modifyCardID = card.CardID;
			_state = state;
		}
		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(cardName.Text))
			{
				MessageBox.Show("Card name is empty");
				return;
			}
			if (string.IsNullOrEmpty(cardAge.Text))
			{
				MessageBox.Show("Card age is empty");
				return;
			}
			if (cardSex.SelectedItem == null)
			{
				MessageBox.Show("Card sex is empty");
				return;
			}
			if (cardAgain.SelectedItem == null)
			{
				MessageBox.Show("Card isagain is empty");
				return;
			}
			var entity = HospitalEntities.GetEntity();
			switch (_state)
			{
				case WindowState.Create:
					try
					{
						entity.cards.Add(new HospitalLibrary.Card()
						{
							Name = cardName.Text,
							PatientAge = int.Parse(cardAge.Text),
							PatientSex = cardSex.Text,
							IsAgain = cardAgain.Text == "New",
							NoteText = cardNote.Text
						});
					}
					catch (FormatException ex)
					{
						MessageBox.Show("Incorrect format");
						return;
					}
					break;
				case WindowState.Modify:
					var card = entity.cards.Find(_modifyCardID);
					card.Name = cardName.Text;
					card.PatientAge = int.Parse(cardAge.Text);
					card.PatientSex = cardSex.Text;
					card.IsAgain = cardAgain.Text == "New";
					card.NoteText = cardNote.Text;
					break;
				default:
					break;
			}
			entity.SaveChanges();
			this.Close();
		}

		public new enum WindowState
		{
			Create,Modify
		}
	}
}
