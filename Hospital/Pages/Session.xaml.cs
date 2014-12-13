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
	/// Interaction logic for Session.xaml
	/// </summary>
	public partial class Session : UserControl
	{
		public Session()
		{
			InitializeComponent();
		}

		#region Dependency prop

		public static readonly DependencyProperty DiagnosisProperty = DependencyProperty.Register(
			"Diagnosis", typeof (string), typeof (Session), new PropertyMetadata(default(string)));

		public string Diagnosis
		{
			get { return (string) GetValue(DiagnosisProperty); }
			set { SetValue(DiagnosisProperty, value); }
		}

		public static readonly DependencyProperty ResultProperty = DependencyProperty.Register(
			"Result", typeof (string), typeof (Session), new PropertyMetadata(default(string)));

		public string Result
		{
			get { return (string) GetValue(ResultProperty); }
			set { SetValue(ResultProperty, value); }
		}
		#endregion
	}
}
