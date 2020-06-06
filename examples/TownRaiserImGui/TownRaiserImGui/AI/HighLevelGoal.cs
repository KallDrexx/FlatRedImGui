using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownRaiserImGui.AI
{
    public abstract class HighLevelGoal
    {
        public abstract bool GetIfDone();

        public abstract void DecideWhatToDo();
    }
}
