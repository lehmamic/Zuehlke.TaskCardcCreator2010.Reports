using System;
using System.Globalization;
using System.Windows.Data;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Zuehlke.TaskCardCreator.Reports.ScrumDetailed.Converters
{
    public class FinishConverter : IValueConverter
    {
        private const string FinishDate = "Finish Date";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var workItem = value as WorkItem;
                if (workItem != null)
                {
                    if (workItem.Fields[FinishDate].Value != null)
                    {
                        var fieldValue = (DateTime)workItem.Fields[FinishDate].Value;
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