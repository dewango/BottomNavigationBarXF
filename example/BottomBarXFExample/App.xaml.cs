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


			// You can only define the color for the active icon if you set the Bottombar to fixed mode
			// So if you want to try this, just uncomment the next two lines

			//bottomBarPage.BarTextColor = Color.Blue; // Setting Color of selected Text and Icon
			//bottomBarPage.FixedMode = true;

			// Whith BarTheme you can select between light and dark theming when using FixedMode
			// When using DarkTheme you can set the Background Color by adding a colors.xml to you Android.Resources.Values
			// with content
			//
			//  <color name="white">#ffffff</color>
			//  < color name = "bb_darkBackgroundColor" >#000000</color>
			//
			// by setting "white" you can select the color of the non selected items and texts in dark theme
			// The Difference between DarkThemeWithAlpha and DarkThemeWithoutAlpha is that WithAlpha will draw not selected items with halfe the 
			// intensity instaed of solid "white" value
			//
			// Uncomment next line to use Dark Theme
			// bottomBarPage.BarTheme = BottomBarPage.BarThemeTypes.DarkWithAlpha; 

			string[] tabTitles = { "Favorites", "Friends", "Nearby", "Recents", "Restaurants" };
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
                    BottomBarPageExtensions.SetTabColor(tabPage, Color.FromHex(tabColor));
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

