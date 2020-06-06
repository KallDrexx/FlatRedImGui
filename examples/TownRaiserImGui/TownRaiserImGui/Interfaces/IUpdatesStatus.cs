using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.CustomEvents;

namespace TownRaiserImGui.Interfaces
{ 
    public interface IUpdatesStatus
    {
        event EventHandler<UpdateStatusEventArgs> UpdateStatus;
        float GetHealthRatio();
        ICommonEntityData EntityData { get; }
        IEnumerable<string> ButtonDatas { get; }
        Dictionary<string, double> ProgressPercents { get; }
        Dictionary<string, int> ButtonCountDisplays { get; }
        bool IsConstructionComplete { get; }
    }
    
}
