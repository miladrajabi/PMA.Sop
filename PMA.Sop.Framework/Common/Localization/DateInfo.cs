namespace PMA.Sop.Framework.Common.Localization
{
    public class DateInfo
    {
        private static readonly DateInfo _persian = new DateInfo(new[] { "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" },
            new[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" }, "ق.ظ", "ب.ظ");
        private static readonly DateInfo _english = new DateInfo(new [] { "اِلأَحَّد", "اِلأِثنین", "اِثَّلاثا", "اِلأَربِعا", "اِلخَمیس", "اِجُّمعَة", "اِسَّبِت" },
            new[] { "محرم", "صفر", "ربیع الاول", "ربیع الثانی", "جمادی الاول", "جمادی الثانی", "رجب", "شعبان", "رمضان", "شوال", "ذی القعدة", "ذی الحجة" }, "ص", "م");
        private static readonly DateInfo _arabic = new DateInfo(new [] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" },
            new [] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" }, "AM", "PM");

        public static DateInfo Persian
        {
            get { return _persian; }
        }
        public static DateInfo English
        {
            get { return _english; }
        }
        public static DateInfo Arabic
        {
            get { return _arabic; }
        }

        public string[] Days { get; private set; }
        public string[] Months { get; private set; }
        public string Am { get; private set; }
        public string Pm { get; private set; }

        private DateInfo(string[] days, string[] months, string am, string pm)
        {
            Days = days;
            Months = months;
            Am = am;
            Pm = pm;
        }
    }
}
