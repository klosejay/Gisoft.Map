// Copyright 2005, 2006 - Morten Nielsen (www.iter.dk)
//
// This file is part of Gisoft.SharpMap.
// Gisoft.SharpMap is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// Gisoft.SharpMap is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.

// You should have received a copy of the GNU Lesser General Public License
// along with Gisoft.SharpMap; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 

using System.Reflection;

namespace Gisoft.SharpMap.Utilities
{
    /// <summary>
    /// Version information helper class
    /// </summary>
    public class Version
    {
        /// <summary>
        /// Returns the current build version of Gisoft.SharpMap
        /// </summary>
        /// <returns></returns>
        public static System.Version GetCurrentVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version;
        }
    }
}