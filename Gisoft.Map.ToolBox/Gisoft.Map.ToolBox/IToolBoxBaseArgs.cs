using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map.ToolBox
{
    public interface IToolBoxBaseArgs:INotifyPropertyChanged
    {
        bool CanConfirm { get; }
    }
}
