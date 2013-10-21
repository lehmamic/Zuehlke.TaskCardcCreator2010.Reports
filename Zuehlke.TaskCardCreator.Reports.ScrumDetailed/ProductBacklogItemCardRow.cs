using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Zuehlke.TaskCardCreator.Reports.ScrumDetailed
{
    public class ProductBacklogItemCardRow
    {
        public ProductBacklogItemCardRow(WorkItem workItem)
        {
            this.WorkItem = workItem;
        }

        public WorkItem WorkItem { get; private set; }
    }
}