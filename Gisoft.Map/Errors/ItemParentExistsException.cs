using System;
using System.Collections.Generic;
using System.Text;

namespace Gisoft.Map
{
    public class ItemParentExistsException:GException
    {
        public ItemParentExistsException():base(ExceptionCodes.ItemParentExistsCode,Languages.ExceptionDescriptions.ItemParentExistsDescription)
        {

        }
    }
}
