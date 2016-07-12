using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BottomBarXFExample
{
	public partial class TabPage : ContentPage
	{
		public TabPage ()
		{
			InitializeComponent ();
		}

		public void UpdateLabel ()
		{
			Label.Text = string.Format (Label.Text, Title);
		}
	}
}

