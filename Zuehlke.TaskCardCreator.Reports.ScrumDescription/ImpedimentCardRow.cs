using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Zuhlke.TaskCardCreator.Reports.ScrumDescription
{
    public class ImpedimentCardRow
    {
        public ImpedimentCardRow(WorkItem workItem)
        {
            this.WorkItem = workItem;
        }

        public WorkItem WorkItem { get; private set; }
    }
}