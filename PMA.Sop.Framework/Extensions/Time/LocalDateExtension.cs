using System;
using SHPA.Common.Localization;

namespace SHPA.Common.Extension
{
    public static class LocalDateExtension
    {
        public static LocalDate EnglishToLocalPersian(this DateTime inputDate)
        {
            DateTime? dt = inputDate;
            return EnglishToLocalPersian(dt);
        }
        public static LocalDate EnglishToLocalPersian(this DateTime? inputDate)
        {
            return inputDate.HasValue ? (new LocalDate(inputDate.Value)) : null;
        }
        #region EnglishToPersian
        public static string EnglishToPersian(this DateTime inputDate)
        {
            DateTime? dt = inputDate;
            return EnglishToPersian(dt);
        }
        public static string EnglishToPersian(this DateTime inputDate, string format)
        {
            DateTime? dt = inputDate;
            return EnglishToPersian(dt, format);
        }
        public static string EnglishToPersian(this DateTime? inputDate)
        {
            return EnglishToPersian(inputDate, "$dddd, $d $MMMM $yyyy $HH:$mm:$ss");
        }
        public static string EnglishToPersian(this DateTime? inputDate, string format)
        {
            if (inputDate.HasValue && inputDate.Value != DateTime.MinValue)
                return (new LocalDate(inputDate.Value)).ToString(format);
            return string.Empty;
        }
        #endregion
        #region EnglishToPersianNo
        public static string EnglishToPersianNo(this DateTime inputDate)
        {
            return EnglishToPersian(inputDate);
        }
        public static string EnglishToPersianNo(this DateTime inputDate, string format)
        {
            return EnglishToPersian(inputDate, format);
        }
        public static string EnglishToPersianNo(this DateTime? inputDate)
        {
            return EnglishToPersian(inputDate);
        }
        public static string EnglishToPersianNo(this DateTime? inputDate, string format)
        {
            return EnglishToPersian(inputDate, format);
        }
        #endregion
        #region PersianToEnglish
        public static DateTime PersianToEnglish(this DateTime input, string format = "$yyyy/$MM/$dd $hh:$mm:$ss")
        {
            LocalDate outpdate;
            bool result = LocalDate.TryParse(input.ToString(format), out outpdate);
            if (result)
            {
                input = outpdate.ToDateTime();
            }
            return input;
        }
        public static DateTime PersianToEnglish(this LocalDate input, string format = "$yyyy/$MM/$dd $hh:$mm:$ss")
        {
            LocalDate outpdate;
            DateTime r = DateTime.Now;
            bool result = LocalDate.TryParse(input.ToString(format), out outpdate);
            if (result)
            {
                r = outpdate.ToDateTime();
            }
            return r;
        }
        #endregion
        public static DateTime ConvertFromUnixTimestamp(this double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }


        public static double ConvertToUnixTimestamp(this DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime().Subtract(origin);
            return Math.Floor(diff.TotalSeconds);
        }

        public static DateTime LastDayOfYear(int persianYear)
        {
            var nextYear = $"{persianYear + 1}/1/1";
            LocalDate dt;
            LocalDate.TryParse(nextYear, out dt);


            var firstDayOfNextYear = dt.PersianToEnglish();
            var lastDayOfCurrentYear = firstDayOfNextYear.Subtract(new TimeSpan(1, 0, 0, 0));
            return lastDayOfCurrentYear;
        }
        public static DateTime FirstDayOfYear(int persianYear)
        {
            var nextYear = $"{persianYear}/1/1";
            LocalDate dt;
            LocalDate.TryParse(nextYear, out dt);


            var firstDayOfNextYear = dt.PersianToEnglish();
            return firstDayOfNextYear;
        }

        public static DateTime LastDayOfYear(this DateTime date)
        {
            var persianDate = date.EnglishToLocalPersian();
            return LastDayOfYear(persianDate.Year);
        }
        public static DateTime FirstDayOfYear(this DateTime date)
        {
            var persianDate = date.EnglishToLocalPersian();
            return FirstDayOfYear(persianDate.Year);
        }

        /// <summary>
        /// تاریخ آخرین روز سال گذشته
        /// </summary>
        /// <param name="date">تاریخ مورد نظر</param>
        /// <param name="step">تعداد سال قبل</param>
        /// <returns>آخرین روز از سال گذشت</returns>
        public static DateTime LastDayOfLastYear(this DateTime date, int step = 1)
        {
            var persianDate = date.EnglishToLocalPersian();
            return LastDayOfYear(persianDate.Year - step);
        }
        public static bool IsLastDayOfYear(this DateTime date)
        {
            var lastDayOfCurrentYear = date.LastDayOfYear();
            return lastDayOfCurrentYear.Year == date.Year &&
                   lastDayOfCurrentYear.Month == date.Month &&
                   lastDayOfCurrentYear.Day == date.Day;
        }

        public static bool IsToday(this DateTime date)
        {
            var today = DateTime.Today;
            return date.Year == today.Year &&
                   date.Month == today.Month &&
                   date.Day == today.Day;
        }


        public static int GetPersianYear(this DateTime date)
        {
            var persianDate = date.EnglishToLocalPersian();
            return persianDate.Year;
        }
        public static int GetPersianMonth(this DateTime date)
        {
            var persianDate = date.EnglishToLocalPersian();
            return persianDate.Month;
        }
        public static int GetPersianDay(this DateTime date)
        {
            var persianDate = date.EnglishToLocalPersian();
            return persianDate.Day;
        }
        /// <summary>
        /// اضافه کردن ساعت لحظه ای به تاریخ مورد نظر برای جلوگیری از تکراری شدن
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime SetTimeNow(this DateTime date)
        {
            var now = DateTime.Now;
            DateTime dateWithTimeNow = new DateTime(date.Year, date.Month, date.Day, now.Hour, now.Minute, now.Second, now.Millisecond);

            return dateWithTimeNow;
        }
    }
}
