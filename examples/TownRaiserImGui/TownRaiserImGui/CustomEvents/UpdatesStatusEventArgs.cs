using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownRaiserImGui.CustomEvents
{
    public class UpdateStatusEventArgs : EventArgs
    {
        public bool WasEntityDestroyed { get; set; }
    }
}
