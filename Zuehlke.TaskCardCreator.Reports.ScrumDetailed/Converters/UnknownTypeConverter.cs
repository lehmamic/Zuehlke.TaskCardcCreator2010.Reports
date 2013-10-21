using System;
using System.Globalization;
using System.Windows.Data;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Zuehlke.TaskCardCreator.Reports.ScrumDetailed.Converters
{
    public class UnknownTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var workItem = value as WorkItem;
                if (workItem != null)
                {
                    string header = string.Empty;
                    if (workItem.Type.Name != null)
                    {
                        header += workItem.Type.Name.ToString(CultureInfo.InvariantCulture);
                        header += " ";
                        header += workItem.Id.ToString(CultureInfo.InvariantCulture);
                        return header;
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
