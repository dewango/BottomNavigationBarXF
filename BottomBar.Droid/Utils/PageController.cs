using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace BottomBar.Droid
{
	public class PageController : IPageController
	{
		private ReflectedProxy<Page> _proxy;

		public static IPageController Create (Page page)
		{
			return new PageController (page);
		}

		PageController (Page page)
		{
			_proxy = new ReflectedProxy<Page> (page);
		}

		public Rectangle ContainerArea {
			get {
				return _proxy.GetPropertyValue<Rectangle> ();
			}

			set {
				_proxy.SetPropertyValue (value);
			}
		}

		public bool IgnoresContainerArea {
			get {
				return _proxy.GetPropertyValue<bool> ();
			}

			set {
				_proxy.SetPropertyValue (value);
			}
		}

		public ObservableCollection<Element> InternalChildren {
			get {
				return _proxy.GetPropertyValue<ObservableCollection<Element>> ();
			}

			set {
				_proxy.SetPropertyValue (value);
			}
		}

		public void SendAppearing ()
		{
			_proxy.Call ();
		}

		public void SendDisappearing ()
		{
			_proxy.Call ();
		}
	}
}

