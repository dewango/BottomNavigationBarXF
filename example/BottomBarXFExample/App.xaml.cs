using System;
using System.Collections.Generic;
using System.Linq;
using BottomBar.XamarinForms;
using Xamarin.Forms;

namespace BottomBarXFExample
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent ();

			BottomBarPage bottomBarPage = new BottomBarPage ();
			bottomBarPage.BarBackgroundColor = Color.Pink;

			string [] tabTitles = { "Favorites", "Friends", "Nearby", "Recents", "Restaurants" };
			string [] tabColors = { null, "#5D4037", "#7B1FA2", "#FF5252", "#FF9800" };

			for (int i = 0; i < tabTitles.Length; ++i) {
				string title = tabTitles [i];
				string tabColor = tabColors [i];

				FileImageSource icon = (FileImageSource) FileImageSource.FromFile (string.Format ("ic_{0}.png", title.ToLowerInvariant ()));

				// create tab page
				var tabPage = new TabPage () {
					Title = title,
					Icon = icon
				};

				// set tab color
				if (tabColor != null) {
					tabPage.SetTabColor (Color.FromHex (tabColor));
				}

				// set label based on title
				tabPage.UpdateLabel ();

				// add tab pag to tab control
				bottomBarPage.Children.Add (tabPage);
			}

			MainPage = bottomBarPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

