using System;
using System.Globalization;
using System.Windows.Data;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Zuhlke.TaskCardCreator.Reports.ScrumDescription.Converters
{
    public class DescriptionConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      try
      {
        var workItem = value as WorkItem;
        if (workItem != null)
        {
          var r = workItem.Fields["Description HTML"];
          return HtmlRemoval.StripTagsRegex((string)r.Value);
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