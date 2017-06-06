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
using Xamarin.Forms;

namespace BottomBar.XamarinForms
{
    public static class BottomBarPageExtensions
    {
        #region TabColorProperty

        public static readonly BindableProperty TabColorProperty = BindableProperty.CreateAttached(
                "TabColor",
                typeof(Color),
                typeof(BottomBarPageExtensions),
                Color.Transparent);

        public static readonly BindableProperty BadgeCountProperty = BindableProperty.CreateAttached(
            "BadgeCount",
            typeof(int),
            typeof(BottomBarPageExtensions),
            0);

        public static readonly BindableProperty BadgeColorProperty = BindableProperty.CreateAttached(
            "BadgeColor",
            typeof(Color),
            typeof(BottomBarPageExtensions),
            Color.Red);

        public static void SetTabColor(BindableObject bindable, Color color)
        {
            bindable.SetValue(TabColorProperty, color);
        }

        public static Color GetTabColor(BindableObject bindable)
        {
            return (Color)bindable.GetValue(TabColorProperty);
        }

        public static void SetBadgeCount(BindableObject bindable, int badgeCount)
        {
            bindable.SetValue(BadgeCountProperty, badgeCount);
        }

        public static int GetBadgeCount(BindableObject bindable)
        {
            return (int)bindable.GetValue(BadgeCountProperty);
        }

        public static void SetBadgeColor(BindableObject bindable, Color color)
        {
            bindable.SetValue(BadgeColorProperty, color);
        }

        public static Color GetBadgeColor(BindableObject bindable)
        {
            return (Color)bindable.GetValue(BadgeColorProperty);
        }

        #endregion
    }
}