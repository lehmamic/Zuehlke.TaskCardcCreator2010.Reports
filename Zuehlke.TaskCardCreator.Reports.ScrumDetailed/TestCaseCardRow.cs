using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Zuehlke.TaskCardCreator.Reports.ScrumDetailed
{
    public class TestCaseCardRow
    {
        public TestCaseCardRow(WorkItem workItem)
        {
            this.WorkItem = workItem;
        }

        public WorkItem WorkItem { get; private set; }
    }
}