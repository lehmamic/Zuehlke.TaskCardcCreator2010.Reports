using System;
using System.Globalization;
using System.Windows.Data;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Zuehlke.TaskCardCreator.Reports.ScrumDetailed.Converters
{
  public class ParentIdConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      try
      {
        var workItem = value as WorkItem;
        if (workItem != null)
        {
          foreach (var link in workItem.Links)
          {
            var relatedLink = link as RelatedLink;
            if (relatedLink != null)
            {
                if (relatedLink.LinkTypeEnd.Name == "Parent")
                {
                    return relatedLink.RelatedWorkItemId.ToString();
                }
            }
          }

          return "-";
        }

        return "Error: Incorrect type";
      }
      catch (Exception exception)
      {
        return string.Format("Error: {0}", exception.Message);
      }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}