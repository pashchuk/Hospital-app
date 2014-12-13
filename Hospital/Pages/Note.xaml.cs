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

namespace Hospital.Pages
{
	/// <summary>
	/// Interaction logic for Note.xaml
	/// </summary>
	public partial class Note : UserControl
	{
		public Note()
		{
			InitializeComponent();
		}

		#region DependencyProperty

		public static readonly DependencyProperty AuthorNameProperty = DependencyProperty.Register(
			"AuthorName", typeof (String), typeof (Note), new PropertyMetadata(default(String)));

		public String AuthorName
		{
			get { return (String) GetValue(AuthorNameProperty); }
			set { SetValue(AuthorNameProperty, value); }
		}

		public static readonly DependencyProperty DateTimeProperty = DependencyProperty.Register(
			"DateTime", typeof (DateTime), typeof (Note), new PropertyMetadata(default(DateTime)));

		public DateTime DateTime
		{
			get { return (DateTime) GetValue(DateTimeProperty); }
			set { SetValue(DateTimeProperty, value); }
		}

		public static readonly DependencyProperty NoteTextProperty = DependencyProperty.Register(
			"NoteText", typeof (string), typeof (Note), new PropertyMetadata(default(string)));

		public string NoteText
		{
			get { return (string) GetValue(NoteTextProperty); }
			set { SetValue(NoteTextProperty, value); }
		}

		#endregion
	}
}
