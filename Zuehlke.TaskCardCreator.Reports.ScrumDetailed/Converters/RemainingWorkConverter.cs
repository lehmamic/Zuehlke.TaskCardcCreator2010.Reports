using System;
using System.Globalization;
using System.Windows.Data;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Zuehlke.TaskCardCreator.Reports.ScrumDetailed.Converters
{
    public class RemainingWorkConverter : IValueConverter
    {
        private const string RemainingWork = "Remaining Work";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var workItem = value as WorkItem;
                if (workItem != null)
                {
                    object estimate = workItem.Fields[RemainingWork].Value;
                    if (estimate != null)
                    {
                        object estimateString = workItem.Fields[RemainingWork].Value.ToString();
                        decimal estimateValue = System.Convert.ToDecimal(estimateString);

                        return estimateValue / 8;
                    }
                }

                return "-";
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