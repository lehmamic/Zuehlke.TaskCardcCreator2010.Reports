using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Documents;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using ReportingFramework;
using WorkItemReportInterface;

namespace Zuehlke.TaskCardCreator.Reports.ScrumDetailed
{
    /// <summary>
    /// Interaction logic for Template.xaml
    /// </summary>
    [Export(typeof(IWorkItemReport))]
    public partial class Template : Report, IWorkItemReport
    {
        public Template()
        {
            this.InitializeComponent();
        }

        public string Description
        {
            get { return "Zühlke Scrum Detailed Report"; }
        }

        public Size PaperSize
        {
            get { return new Size(8.27, 11.69); }
        }

        public bool TeamCustomized
        {
            get { return false; }
        }

        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        public bool IsSupported(WorkItemTypeCollection wiTypeCollection)
        {
            if (wiTypeCollection == null)
            {
                return false;
            }

            if (wiTypeCollection.Count == 0)
            {
                return false;
            }

            // Only the Scrum process template has this type
            return wiTypeCollection.Contains("Product Backlog Item");
        }

        public FixedDocument Create(IEnumerable<WorkItem> data)
        {
            var rows = new List<object>();
            foreach (var workItem in data)
            {
                switch (workItem.Type.Name)
                {
                    case "Product Backlog Item":
                        rows.Add(new ProductBacklogItemCardRow(workItem));
                        break;
                    case "Task":
                        rows.Add(new TaskCardRow(workItem));
                        break;
                    case "Bug":
                        rows.Add(new BugCardRow(workItem));
                        break;
                    case "Impediment":
                        rows.Add(new ImpedimentCardRow(workItem));
                        break;
                    case "Test Case":
                        rows.Add(new TestCaseCardRow(workItem));
                        break;
                    case "Shared Steps":
                        rows.Add(new SharedStepsCardRow(workItem));
                        break;
                    case "Sprint":
                        rows.Add(new SprintCardRow(workItem));
                        break;
                    default:
                        rows.Add(new UnknownCardRow(workItem));
                        break;
                }
            }

            return this.GenerateReport(
                page => new PageInfo(page, DateTime.Now),
                this.PaperSize,
                rows);
        }

        /// <summary>
        /// This class becomes the data context for every page. It gives the page 
        /// access to the page number.
        /// </summary>
        public class PageInfo
        {
            public PageInfo(int pageNumber, DateTime reportDate)
            {
                this.PageNumber = pageNumber;
                this.ReportDate = reportDate;
            }

            public bool IsFirstPage
            {
                get { return this.PageNumber == 1; }
            }

            public int PageNumber { get; set; }

            public DateTime ReportDate { get; set; }
        }
    }
}