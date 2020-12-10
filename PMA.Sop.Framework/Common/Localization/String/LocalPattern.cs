namespace PMA.Sop.Framework.Common.Localization.String
{
    public class LocalPattern
    {
        public const string Date = "\\A(\\d{4})[\\\\/\\-](\\d{1,2})[\\\\/\\-](\\d{1,2})\\z";
        public const string DateTime = "\\A(\\d{4})[\\\\/\\-](\\d{1,2})[\\\\/\\-](\\d{1,2})\\s(\\d{1,2}):(\\d{1,2}):(\\d{1,2})\\z";
        public const string DateTimeFactor = "\\A(\\d{4})\\/(\\d{1,2})\\/(\\d{1,2})\\-(\\d{1,2}):(\\d{1,2})\\z";
        public const string Time = "\\A(\\d{1,2}):(\\d{1,2}):(\\d{1,2})\\Z";
        public const string Email = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
        public const string Url = "\\Ahttp(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&amp;=]*)?\\z";
        public const string LatinCharAndNum = "\\A[\\sa-zA-Z0-9\\.]*\\z";
        public const string Number = "\\A(?:-?(?:\\d+|\\d{1,3}(?:,\\d{3})+)(?:\\.\\d+)?)\\z";
        public const string Digit = "\\A\\d*\\z";
        public const string LatinChar = "\\A[\\sa-zA-Z]*\\z";
        public const string FarsiChar = "\\A[\\sگوکذىىلآدءٍفإجژچپشذزیثبلاهتنمئدخحضقسفعرصطغظ]*\\z";

        public const string LocalIP = @"^localhost$|^172(?:\.[0-9]+){0,2}\.[0-9]+$|^(?:0*\:)*?:?0*1$|^192(?:\.[0-9]+){0,2}\.[0-9]+$|^(?:0*\:)*?:?0*1$";
        public const string PublicIP = @"10(?:\.[0-9]+){0,2}\.[0-9]+$";


        public const string PasswordStrength = @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})";
    }
}
