/*
 * BottomNavigationBar for Xamarin Forms
 * Copyright (c) 2016 Thrive GmbH and others (http://github.com/thrive-now).
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
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

