using Gisoft.Map.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map
{
    public class GeometryNotSupportException:GException
    {
        public GeometryNotSupportException() : base(ExceptionCodes.GeometryNotSupport, ExceptionLanguageResources.GeometryNotSupport)
        {

        }
    }
}
