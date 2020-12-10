using System;
using System.Globalization;
using System.Text.RegularExpressions;
using PMA.Sop.Framework.Common.Localization;
using PMA.Sop.Framework.Common.Localization.String;
using SHPA.Common.Localization.String;

namespace SHPA.Common.Localization
{
    public class LocalDate
    {
        private int _year, _day, _month, _hour, _minute, _seconds, _milisecond, _dayofWeek;
        private int _maxYear, _maxMonth, _maxDay;
        private int _minYear, _minMonth, _minDay;
        public DateInfo DInfo;

        public Calendar DateCalendar { get; set; }

        private void ResetCalendar()
        {
            DateTime dt;
            dt = DateCalendar.MaxSupportedDateTime;
            _maxYear = DateCalendar.GetYear(dt);
            _maxMonth = DateCalendar.GetMonth(dt);
            _maxDay = DateCalendar.GetDayOfMonth(dt);

            dt = DateCalendar.MinSupportedDateTime;
            if (DateCalendar.GetType() == typeof(HijriCalendar))
            {
                dt = dt.AddYears(1);
            }
            _minYear = DateCalendar.GetYear(dt);
            _minMonth = DateCalendar.GetMonth(dt);
            _minDay = DateCalendar.GetDayOfMonth(dt);
        }

        private void SetDate(DateTime dt)
        {
            _year = DateCalendar.GetYear(dt);
            _month = DateCalendar.GetMonth(dt);
            _day = DateCalendar.GetDayOfMonth(dt);
            _dayofWeek = (int)DateCalendar.GetDayOfWeek(dt);
            _hour = dt.Hour;
            _minute = dt.Minute;
            _seconds = dt.Second;
            MiliSeconds = dt.Millisecond;
        }

        public int MonthLength => DateCalendar.GetDaysInMonth(Year, Month);

        private void FixOne(ref int one, int unit, ref int next)
        {
            if (one >= 0 && one < unit) return;
            if (one < 0)
            {
                while (one < 0)
                {
                    one += unit;
                    next--;
                }
            }
            else
            {
                while (one >= unit)
                {
                    one -= unit;
                    next++;
                }
            }
        }

        private void FixMonthYear(ref int year, ref int month)
        {
            if (year > _maxYear || year < _minYear)
            {
                throw new Exception("مقدار سال نا معتبر است");
            }
            var maxMonth = DateCalendar.GetMonthsInYear(year);
            if (month < 1 || month > maxMonth)
            {
                if (month < 1)
                {
                    while (month < 1)
                    {
                        year--;
                        maxMonth = DateCalendar.GetMonthsInYear(year);
                        month += maxMonth;
                    }
                }
                else
                {
                    while (month > maxMonth)
                    {
                        year++;
                        maxMonth = DateCalendar.GetMonthsInYear(year);
                        month -= maxMonth;
                    }
                }
            }
            if (year > _maxYear || year < _minYear)
            {
                throw new Exception("مقادیر سال و ماه نامعتبر است");
            }
        }

        private void FixAll(ref int year, ref int month, ref int day, ref int hour, ref int minute, ref int second, ref int milisecond)
        {
            FixOne(ref milisecond, 1000, ref second);
            FixOne(ref second, 60, ref minute);
            FixOne(ref minute, 60, ref hour);
            FixOne(ref hour, 24, ref day);
            FixMonthYear(ref year, ref month);
            var maxDay = DateCalendar.GetDaysInMonth(year, month);
            if (day < 1 || day > maxDay)
            {
                if (day < 1)
                {
                    while (day < 1)
                    {
                        month--;
                        FixMonthYear(ref year, ref month);
                        day += maxDay;
                        maxDay = DateCalendar.GetDaysInMonth(year, month);
                    }
                }
                else
                {
                    while (day > maxDay)
                    {
                        month++;
                        FixMonthYear(ref year, ref month);
                        day -= maxDay;
                        maxDay = DateCalendar.GetDaysInMonth(year, month);
                    }
                }
            }
            FixMonthYear(ref year, ref month);
        }

        private static string TwoDigit(int input)
        {
            string twoDj = "";
            int len = input.ToString().Length;
            if (len == 1)
                twoDj = input.ToString().Insert(0, "0");
            else if (len == 2)
                twoDj = input.ToString();
            else if (len > 2)
            {

            }
            return twoDj;
        }

        private string Format(string expression)
        {
            switch (expression)
            {
                case "F":
                case "f":
                    expression = Format("$dddd, $d $MMMM $yyyy $HH:$mm:$ss $g");
                    break;
                case "S":
                case "s":
                    expression = Format("$yyyy/$MM/$dd $HH:$mm:$ss $g");
                    break;
                case "Fd":
                case "fd":
                    expression = Format("$dddd, $d $MMMM $yyyy");
                    break;
                case "Sd":
                case "sd":
                    expression = Format("$yyyy/$MM/$dd");
                    break;
                default:
                    expression = Regex.Replace(expression, "\\$d{4}", DInfo.Days[DayOfWeek]);
                    expression = Regex.Replace(expression, "\\$d{2}", TwoDigit(Day));
                    expression = Regex.Replace(expression, "\\$d{1}", Day.ToString());

                    expression = Regex.Replace(expression, "\\$M{4}", DInfo.Months[(Month - 1)]);
                    expression = Regex.Replace(expression, "\\$M{2}", TwoDigit(Month));
                    expression = Regex.Replace(expression, "\\$M{1}", Month.ToString());

                    expression = Regex.Replace(expression, "\\$y{4}", Year.ToString());
                    expression = Regex.Replace(expression, "\\$y{2}", TwoDigitYear.ToString());

                    expression = Regex.Replace(expression, "\\$H{2}", TwoDigit(Hour));
                    expression = Regex.Replace(expression, "\\$H{1}", Hour.ToString());

                    expression = Regex.Replace(expression, "\\$h{2}", TwoDigit(Hour12));
                    expression = Regex.Replace(expression, "\\$h{1}", Hour12.ToString());

                    expression = Regex.Replace(expression, "\\$m{2}", TwoDigit(Minute));
                    expression = Regex.Replace(expression, "\\$m{1}", Minute.ToString());

                    expression = Regex.Replace(expression, "\\$s{2}", TwoDigit(Seconds));
                    expression = Regex.Replace(expression, "\\$s{1}", Seconds.ToString());

                    expression = Regex.Replace(expression, "\\$g{1}", Daylight);
                    break;
            }
            return expression;
        }

        public LocalDate(int year, int month, int day)
            : this(year, month, day, 0, 0, 0, 0, new PersianCalendar(), DateInfo.Persian)
        {
        }

        public LocalDate(int year, int month, int day, Calendar cal, DateInfo dInfo)
            : this(year, month, day, 0, 0, 0, 0, cal, dInfo)
        {
        }

        public LocalDate(int year, int month, int day, int hour, int minute, int second, int milisecond)
            : this(year, month, day, hour, minute, second, milisecond, new PersianCalendar(), DateInfo.Persian)
        {
        }

        public LocalDate(int year, int month, int day, int hour, int minute, int second, int milisecond, Calendar cal, DateInfo dInfo)
        {
            DateCalendar = cal;
            DInfo = dInfo;
            ResetCalendar();

            _year = year;
            _month = month;
            _day = day;
            _hour = hour;
            _minute = minute;
            _seconds = second;
            MiliSeconds = milisecond;
            _dayofWeek = (int)DateCalendar.GetDayOfWeek(ToDateTime());
        }

        public LocalDate()
            : this(new PersianCalendar(), DateInfo.Persian, DateTime.Now)
        {
        }

        public LocalDate(DateTime dt)
            : this(new PersianCalendar(), DateInfo.Persian, dt)
        {
        }

        public LocalDate(Calendar cal, DateInfo dInfo)
            : this(cal, dInfo, DateTime.Now)
        {
        }

        public LocalDate(Calendar cal, DateInfo dInfo, DateTime dt)
        {
            DateCalendar = cal;
            DInfo = dInfo;
            ResetCalendar();

            SetDate(dt);
        }

        public int Day
        {
            get => _day;
            set
            {
                _day = value;
                FixAll(ref _year, ref _month, ref _day, ref _hour, ref _minute, ref _seconds, ref _milisecond);
            }
        }

        public int DayOfWeek => _dayofWeek;

        public int Month
        {
            get => _month;
            set
            {
                _month = value;
                FixAll(ref _year, ref _month, ref _day, ref _hour, ref _minute, ref _seconds, ref _milisecond);
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                _year = value;
                FixAll(ref _year, ref _month, ref _day, ref _hour, ref _minute, ref _seconds, ref _milisecond);
            }
        }

        public int HijriAdjust
        {
            set
            {
                if (DateCalendar.GetType() == typeof(HijriCalendar))
                {
                    HijriCalendar cal = (HijriCalendar)DateCalendar;
                    cal.HijriAdjustment = value;
                    DateCalendar = cal;
                    ResetCalendar();
                }
            }
        }

        public int Hour
        {
            get => _hour;
            set
            {
                _hour = value;
                FixAll(ref _year, ref _month, ref _day, ref _hour, ref _minute, ref _seconds, ref _milisecond);
            }
        }

        public int Hour12
        {
            get
            {
                if (_hour > 12)
                    return _hour - 12;
                return _hour;
            }
        }

        public int Minute
        {
            get => _minute;
            set
            {
                _minute = value;
                FixAll(ref _year, ref _month, ref _day, ref _hour, ref _minute, ref _seconds, ref _milisecond);
            }
        }

        public int Seconds
        {
            get => _seconds;
            set
            {
                _seconds = value;
                FixAll(ref _year, ref _month, ref _day, ref _hour, ref _minute, ref _seconds, ref _milisecond);
            }
        }

        public int MiliSeconds
        {
            get => _milisecond;
            set
            {
                _milisecond = value;
                FixAll(ref _year, ref _month, ref _day, ref _hour, ref _minute, ref _seconds, ref _milisecond);
            }
        }

        public bool IsLeapYear => DateCalendar.IsLeapYear(Year);

        public bool IsLeapMonth => DateCalendar.IsLeapMonth(Year, Month);

        public bool IsLeapDay => DateCalendar.IsLeapDay(Year, Month, Day);

        public int TwoDigitYear
        {
            get
            {
                if (Year.ToString().Length > 2)
                    return Convert.ToInt32(Year.ToString().Substring(2, 2));
                return Year;
            }
        }

        public string Daylight
        {
            get
            {
                if (Hour > 12)
                    return DInfo.Pm;
                return DInfo.Am;
            }
        }

        public DateTime ToDateTime()
        {
            return DateCalendar.ToDateTime(Year, Month, Day, Hour, Minute, Seconds, MiliSeconds);
        }

        public new string ToString()
        {
            return Format("s");
        }

        public string ToString(string format)
        {
            return Format(format);
        }

        public override int GetHashCode()
        {
            return ToDateTime().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return ToDateTime().Equals(obj);
        }

        public static LocalDate Now => new LocalDate();

        public static bool TryParse(string dt, out LocalDate result)
        {
            bool hasResult = false;
            result = null;
            try
            {
                if (IsDate(dt))
                {
                    Regex rg = new Regex(LocalPattern.Date);
                    int y, m, d;
                    Match r = rg.Match(dt);
                    y = Convert.ToInt32(r.Groups[1].Value);
                    m = Convert.ToInt32(r.Groups[2].Value);
                    d = Convert.ToInt32(r.Groups[3].Value);
                    result = new LocalDate(y, m, d);
                    hasResult = true;
                }
                else if (IsDatetime(dt))
                {
                    Regex rg = new Regex(LocalPattern.DateTime);
                    int y, m, d, h, min, s;

                    Match r = rg.Match(dt);
                    y = Convert.ToInt32(r.Groups[1].Value);
                    m = Convert.ToInt32(r.Groups[2].Value);
                    d = Convert.ToInt32(r.Groups[3].Value);
                    h = Convert.ToInt32(r.Groups[4].Value);
                    min = Convert.ToInt32(r.Groups[5].Value);
                    s = Convert.ToInt32(r.Groups[6].Value);
                    result = new LocalDate(y, m, d, h, min, s, 0);
                    hasResult = true;
                }
                else if (IsDateTimeFactor(dt))
                {
                    Regex rg = new Regex(LocalPattern.DateTimeFactor);
                    int y, m, d, h, min, s;

                    Match r = rg.Match(dt);
                    y = Convert.ToInt32(r.Groups[1].Value);
                    m = Convert.ToInt32(r.Groups[2].Value);
                    d = Convert.ToInt32(r.Groups[3].Value);
                    h = Convert.ToInt32(r.Groups[4].Value);
                    min = Convert.ToInt32(r.Groups[5].Value);
                    s = 0;
                    result = new LocalDate(y, m, d, h, min, s, 0);
                    hasResult = true;
                }
            }
            catch (Exception)
            {
                hasResult = false;
            }

            return hasResult;
        }
        public static bool IsDate(string input)
        {
            return Regex.IsMatch(input, LocalPattern.Date);
        }
        public static bool IsDatetime(string input)
        {
            return Regex.IsMatch(input, LocalPattern.DateTime);
        }
        public static bool IsDateTimeFactor(string input)
        {
            return Regex.IsMatch(input, LocalPattern.DateTimeFactor);
        }
    }
}
