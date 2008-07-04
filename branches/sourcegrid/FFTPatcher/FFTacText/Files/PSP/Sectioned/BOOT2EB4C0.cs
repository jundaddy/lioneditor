﻿/*
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
using System.Collections.Generic;

namespace FFTPatcher.TextEditor.Files.PSP
{
    /// <summary>
    /// Text for the BOOT.BIN file at location 0x2EB4C0.
    /// </summary>
    public class BOOT2EB4C0 : AbstractBootBinFile
    {

		#region Static Fields (1) 

        private static Dictionary<int, long> locations;

		#endregion Static Fields 

		#region Fields (1) 

        private const string filename = "BOOT.BIN[0x2EB4C0]";

		#endregion Fields 

		#region Properties (4) 


        /// <summary>
        /// Gets the number of sections.
        /// </summary>
        /// <value>The number of sections.</value>
        protected override int NumberOfSections
        {
            get { return 31; }
        }

        /// <summary>
        /// Gets the filename.
        /// </summary>
        /// <value></value>
        public override string Filename { get { return filename; } }

        /// <summary>
        /// Gets the filenames and locations for this file.
        /// </summary>
        /// <value></value>
        public override IDictionary<int, long> Locations
        {
            get
            {
                if( locations == null )
                {
                    locations = new Dictionary<int, long>();
                    locations.Add( 0, 0x2EB4C0 );
                }
                return locations;
            }
        }

        /// <summary>
        /// Gets the maximum length of this file as a byte array.
        /// </summary>
        /// <value></value>
        public override int MaxLength
        {
            get { return 0x286F; }
        }


		#endregion Properties 

		#region Constructors (2) 

        private BOOT2EB4C0()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BOOT2EB4C0"/> class.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        public BOOT2EB4C0( IList<byte> bytes )
            : base( bytes )
        {
        }

		#endregion Constructors 

		#region Methods (1) 


        /// <summary>
        /// Gets a list of indices for named sections.
        /// </summary>
        public override IList<NamedSection> GetNamedSections()
        {
            var result = base.GetNamedSections();
            result.Add( new NamedSection( this, SectionType.JobNames, 2 ) );
            return result;
        }


		#endregion Methods 

    }
}