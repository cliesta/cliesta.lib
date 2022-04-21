#region copyright

// Copyright 2021 Cliesta Software
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Linq;
using System.Windows.Forms;
using Cliesta.Lib2.RecentlyUsed;
using Cliesta.Lib2.Themes;

namespace Cliesta.Lib5.WinForms
{
    public class RecentlyUsedMenu
    {
        private readonly ToolStripMenuItem _parentMenu;
        private readonly Action<string> _itemSelected;
        private readonly Theme _theme;
        private readonly Control _ownerControl;
        private readonly IRecentlyUsedList _recentlyUsedList;

        public RecentlyUsedMenu(
            ToolStripMenuItem parentMenu,
            Action<string> itemSelected,
            Theme theme,
            Control ownerControl,
            IRecentlyUsedList recentlyUsedList )
        {
            _parentMenu = parentMenu;
            _itemSelected = itemSelected;
            _theme = theme;
            _ownerControl = ownerControl;
            _recentlyUsedList = recentlyUsedList;

            _parentMenu.Enabled = false;

            FillMenu();
        }

        public void Add( string menuItemText )
        {
            if ( _ownerControl.InvokeRequired )
            {
                _ownerControl.Invoke( new MethodInvoker( () => Add( menuItemText ) ) );
            }
            else
            {
                _recentlyUsedList.Add( menuItemText );

                FillMenu();
            }
        }

        public void Remove( string menuItemText )
        {
            if ( _ownerControl.InvokeRequired )
            {
                _ownerControl.Invoke( new MethodInvoker( () => Remove( menuItemText ) ) );
            }
            else
            {
                _recentlyUsedList.Remove( menuItemText );

                FillMenu();
            }
        }

        private void FillMenu()
        {
            _parentMenu.DropDown.Items.Clear();
            foreach ( var item in _recentlyUsedList.Items )
            {
                var menuItem = new ToolStripMenuItem( item );
                menuItem.ForeColor = _theme.Text.ToColor();
                menuItem.Click += ( sender, args ) => _itemSelected( item );
                _parentMenu.DropDown.Items.Add( menuItem );
            }

            _parentMenu.Enabled = _recentlyUsedList.Items.Any();
        }

        public string LastUsed( string defaultValue ) =>
        _recentlyUsedList.Items.Any() ? _recentlyUsedList.Items.First() : defaultValue;
    }
}