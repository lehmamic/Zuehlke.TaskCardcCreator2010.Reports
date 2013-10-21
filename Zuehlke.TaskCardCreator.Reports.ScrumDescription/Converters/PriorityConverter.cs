using System;
using System.Globalization;
using System.Windows.Data;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Zuhlke.TaskCardCreator.Reports.ScrumDescription.Converters
{
    public class PriorityConverter : IValueConverter
    {
        private const string FieldName = "Priority";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var workItem = value as WorkItem;
                if (workItem != null)
                {
                    if (workItem.Fields[FieldName].Value != null)
                    {
                        return workItem.Fields[FieldName].Value.ToString();
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