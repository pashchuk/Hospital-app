using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary
{
	partial class HospitalEntities
	{
		#region Async methods

		#endregion

		#region Non-async methods

		public Note GetNoteById(int id)
		{
			return this.notes.Find(id);
		}

		public User GetNotesUser(int id)
		{
			return GetNoteById(id).user;
		}

		public Card GetNotesGard(int id)
		{
			return GetNoteById(id).card;
		}

		public bool GetNotesHiddenProperty(int id)
		{
			return GetNoteById(id).IsHidden;
		}

		public DateTime GetNotesDate(int id)
		{
			return GetNoteById(id).Date;
		}

		public string GetNotesText(int id)
		{
			return GetNoteById(id).NoteText;
		}

		#endregion
	}
}
