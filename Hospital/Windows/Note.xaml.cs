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
	/// Interaction logic for Note.xaml
	/// </summary>
	public partial class Note : Window
	{
		private HospitalLibrary.Card _card;
		private int _userId;
		private Windows.Card.WindowState _state;
		private HospitalLibrary.Note _note;
		public Note()
		{
			InitializeComponent();
		}

		public Note(HospitalLibrary.Card card, int userId):this()
		{
			_card = card;
			_userId = userId;
			_state = Windows.Card.WindowState.Create;
		}

		public Note(HospitalLibrary.Note note):this()
		{
			_card = note.card;
			_userId = note.UserID;
			cardNote.Text = note.NoteText;
			_note = note;
			_state = Windows.Card.WindowState.Modify;
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(cardNote.Text))
			{
				MessageBox.Show("Text of note is empty");
				return;
			}
			var context = HospitalEntities.GetEntity();
			switch (_state)
			{
				case Card.WindowState.Create:
					context.notes.Add(new HospitalLibrary.Note()
					{
						CardID = _card.CardID,
						Date = DateTime.Now,
						IsHidden = false,
						NoteText = cardNote.Text,
						UserID = _userId
					});
					break;
				case Card.WindowState.Modify:
					_note.NoteText = cardNote.Text;
					_note.Date = DateTime.Now;
					break;
			}
			context.SaveChanges();
			this.Close();
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
