using System;
using System.Configuration;
using System.Globalization;

namespace MatrixTest.Security.Implementation
{
    /// <summary>Handle settings from config</summary>
    internal static class SettingsManager
    {
        // randomly generated GUID for each project - you can change this to whatever you want
        public static string AppPrefix => "{B0076425-8211-4396-9E28-1E9A156E6A3F}";

        private static int? _ticketDurationMin;
        private static TimeSpan? _ticketDurationTimeSpan;
        public static TimeSpan? TicketDurationTimeSpan
        {
            get
            {
                if (_ticketDurationMin == default)
                {
                    _ticketDurationMin = int.Parse(ConfigurationManager.AppSettings["TicketDurationMin"], CultureInfo.InvariantCulture);
                    if (_ticketDurationMin.Value != 0)
                    {
                        _ticketDurationTimeSpan = TimeSpan.FromMinutes(_ticketDurationMin.Value);
                    }
                }
                return _ticketDurationTimeSpan;
            }
        }
    }
}
