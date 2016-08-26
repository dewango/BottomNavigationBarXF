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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace BottomBar.Droid
{
	public class ReflectedProxy<T> where T : class
	{
		private object _target;

		private readonly Dictionary<string, PropertyInfo> _cachedPropertyInfo;
		private readonly Dictionary<string, MethodInfo> _cachedMethodInfo;

		private readonly IEnumerable<PropertyInfo> _targetPropertyInfoList;
		private readonly IEnumerable<MethodInfo> _targetMethodInfoList;

		public ReflectedProxy(T target)
		{
			_target = target;

			_cachedPropertyInfo = new Dictionary<string, PropertyInfo>();
			_cachedMethodInfo = new Dictionary<string, MethodInfo>();

			TypeInfo typeInfo = typeof(T).GetTypeInfo();
			_targetPropertyInfoList = typeInfo.GetRuntimeProperties();
			_targetMethodInfoList = typeInfo.GetRuntimeMethods();
		}

		public void SetPropertyValue(object value, [CallerMemberName] string propertyName = "")
		{
			GetPropertyInfo(propertyName).SetValue(_target, value);
		}

		public TPropertyValue GetPropertyValue<TPropertyValue>([CallerMemberName] string propertyName = "")
		{
			return (TPropertyValue)GetPropertyInfo(propertyName).GetValue(_target);
		}

		public object Call([CallerMemberName] string methodName = "", object[] parameters = null)
		{

			if (!_cachedMethodInfo.ContainsKey(methodName))
			{
				_cachedMethodInfo[methodName] = _targetMethodInfoList.Single(mi => mi.Name == methodName || mi.Name.Contains("." + methodName));
			}

			return _cachedMethodInfo[methodName].Invoke(_target, parameters);
		}

		PropertyInfo GetPropertyInfo(string propertyName)
		{
			if (!_cachedPropertyInfo.ContainsKey(propertyName))
			{
				_cachedPropertyInfo[propertyName] = _targetPropertyInfoList.Single(pi => pi.Name == propertyName || pi.Name.Contains("." + propertyName));
			}

			return _cachedPropertyInfo[propertyName];
		}
	}
}

