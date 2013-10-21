using System;
using System.Globalization;
using System.Windows.Data;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Zuehlke.TaskCardCreator.Reports.ScrumDetailed.Converters
{
    public class StartConverter : IValueConverter
    {
        private const string FieldName = "Start Date";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var workItem = value as WorkItem;
                if (workItem != null)
                {
                    if (workItem.Fields[FieldName].Value != null)
                    {
                        var fieldValue = (DateTime)workItem.Fields[FieldName].Value;
                        string date = string.Empty;
                        date += fieldValue.Month.ToString();
                        date += "/";
                        date += fieldValue.Day.ToString();
                        date += "/";
                        date += fieldValue.Year.ToString();
                        return date;
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