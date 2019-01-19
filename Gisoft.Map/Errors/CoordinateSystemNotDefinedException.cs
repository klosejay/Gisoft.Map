using Gisoft.Map.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map
{
    public class CoordinateSystemNotDefinedException:GException
    {
        public CoordinateSystemNotDefinedException() : base(ExceptionCodes.CoordinateSystemNotDefinedCode, ExceptionLanguageResources.CoordinateSystemNotDefined)
        {

        }
    }
}
