/*
    Copyright 2007, Joe Davidson <joedavidson@gmail.com>

    This file is part of FFTPatcher.

    FFTPatcher is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    FFTPatcher is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with FFTPatcher.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FFTPatcher.TextEditor
{
    public partial class About : Form
    {

		#region Constructors (1) 

        public About()
        {
            InitializeComponent();
            textBox.Text =
@"Credits:
  Gomtuu: His page helped me understand the text compression algorithm and how the double-byte characters were processed. Check out his page at http://gomtuu.org/fft/
  Zodiac: Got me started with a list of text locations in the Playstation version.

Copyright 2007, Joe Davidson <joedavidson@gmail.com>

FFTPatcher is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

FFTPatcher is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with FFTPatcher.  If not, see <http://www.gnu.org/licenses/>.";
            versionLabel.Text = string.Format( "v0.{0}", Assembly.GetExecutingAssembly().GetName().Version.Revision.ToString() );
        }

		#endregion Constructors 

    }
}

