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
using System.IO;
using System.Linq;
using System.Reflection;

namespace BottomBar.Droid.Utils
{
	internal static class ResourceManagerEx
	{
		internal static int IdFromTitle (string title, Type type)
		{
			string name = Path.GetFileNameWithoutExtension (title);
			int id = GetId (type, name);
			return id; // Resources.System.GetDrawable (Resource.Drawable.dashboard);
		}

		static int GetId (Type type, string propertyName)
		{
			FieldInfo [] props = type.GetFields ();
			FieldInfo prop = props.Select (p => p).FirstOrDefault (p => p.Name == propertyName);
			if (prop != null)
				return (int)prop.GetValue (type);
			return 0;
		}
	}
}

