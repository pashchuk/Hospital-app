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
		public Card()
		{
			InitializeComponent();
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
			entity.cards.Add(new HospitalLibrary.Card()
			{
				Name = cardName.Text,
				PatientAge = int.Parse(cardAge.Text),
				PatientSex = cardSex.Text,
				IsAgain = cardAgain.Text == "New",
				NoteText = cardNote.Text
			});
			entity.SaveChanges();
			this.Close();
		}
	}
}
