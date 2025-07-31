namespace TestTask.Service.Helpers
{
    public class TimeFormatHelper
    {
        public static string FormatTime(int totalSeconds)
        {
            var hours = totalSeconds / 3600;
            var minutes = (totalSeconds % 3600) / 60;
            var seconds = totalSeconds % 60;

            return hours > 0 ? 
                $"{hours:D2}:{minutes:D2}:{seconds:D2}" : 
                $"{minutes:D2}:{seconds:D2}";
        }
    }
}