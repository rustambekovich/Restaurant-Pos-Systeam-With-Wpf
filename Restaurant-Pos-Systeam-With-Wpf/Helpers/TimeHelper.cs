using System;

namespace Restaurant_Pos_Systeam_With_Wpf.Helpers
{
    public class TimeHelper
    {
        public static DateTime GetDateTime()
        {
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Tashkent");

            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, timeZone);
            return localTime;




            /*var DbTime = DateTime.UtcNow;
            DbTime.AddHours(TimeConstans.UTC);
            return DbTime;*/
        }

    }
}
