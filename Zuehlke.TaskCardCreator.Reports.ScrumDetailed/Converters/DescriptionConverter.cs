using System;
using System.Globalization;
using System.Windows.Data;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Zuehlke.TaskCardCreator.Reports.ScrumDetailed.Converters
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
                    if (workItem.Description == string.Empty)
                    {
                        try
                        {
                            var r = workItem.Fields["Description HTML"];
                            return HtmlRemoval.StripTagsRegex((string)r.Value);
                        }
                        catch
                        {
                            /*Do nothing, because instead of showing a possible TFS error on the card
                             * we will display an empty string.  This should handle more work item types
                             * without additional code changes.  In the future, a similar implementation
                             * can combine all description type fields into one converter.
                             */
                        }
                    }

                    return workItem.Description.ToString(CultureInfo.InvariantCulture);
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