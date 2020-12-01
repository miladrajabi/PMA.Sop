//using System;
//using Kendo.Mvc.UI;
//using Kendo.Mvc.UI.Fluent;

//namespace TelerikUI.Models.KendoConfig
//{
//    public static class KendoConfig<T> where T : class
//    {
//        public static readonly Action<GridSortableSettingsBuilder<T>> Sort =
//            (s => s.AllowUnsort(true).Enabled(true).SortMode(GridSortMode.MultipleColumn));
//        public static readonly Action<GridEditingSettingsBuilder<T>> Editable = (e => e.DisplayDeleteConfirmation("آیا مایل به حذف ردیف انتخابی هستید؟"));
//    }

//    public static class KendoConfig
//    {
//        public static readonly int PageSize = 10;

//        public static readonly Action<PageableBuilder> Page = (p => p.ButtonCount(3)
//            .Info(true)
//            .PageSizes(new[] { 10, 20, 100 })
//            .Refresh(true)
//            .Messages(
//                m => m
//                        .Refresh("بارگذاری مجدد")
//                        .Display("{0} - {1} از {2}")
//                        .Empty("آیتمی برای نمایش وجود ندارد")
//                        .First("صفحه اول")
//                        .ItemsPerPage("آیتم در هر صفحه")
//                        .Last("صفحه آخر")
//                        .MorePages("بیشتر")
//                        .Next("بعدی")
//                        .Of("{0} از")
//                        .Page("صفحه")
//                        .Previous("قبلی"))
//                        );

//        public static readonly Action<GridScrollSettingsBuilder> Scroll = (s => s.Enabled(true).Height("auto"));

//        //public static readonly Action<GridColumnMenuSettingsBuilder> ColumnMenu =
//        //    (m => m.Enabled(true));
//        //(m => m.Enabled(false).Columns(false).Filterable(false).Sortable(false)
//        //    .Messages(
//        //        ms =>
//        //            ms.ColumnSettings("تنظیمات ستون")
//        //                .Columns("ستون ها")
//        //                .Done("انجام")
//        //                .Filter("فیلتر")
//        //                .Lock("قفل")
//        //                .SortAscending("نزولی")
//        //                .SortDescending("صعودی")
//        //                .Unlock("رها سازی")));

//        public static readonly Action<GridResizingSettingsBuilder> Resize = (r => r.Columns(true));
//        public static readonly Action<GridReorderingSettingsBuilder> Reorder = (r => r.Columns(true));
//        //public static readonly Action<GridNavigatableSettingsBuilder> Navigate = (n => n.Enabled(true));

//        public static readonly Action<GridFilterableSettingsBuilder> Filter = (f => f.Enabled(false));
//        //(f => f.Enabled(false).Extra(false)
//        //.Messages(
//        //    m =>
//        //        m.And("و")
//        //            .Cancel("لغو")
//        //            .Clear("پاک کردن")
//        //            .Filter("فیلتر")
//        //            .Info("اطلاعات")
//        //            .IsFalse("نادرست")
//        //            .IsTrue("درست")
//        //            .Operator("عملگر")
//        //            .Or("یا")
//        //            .SelectValue("مقدار انتخاب شده")
//        //            .Value("مقدار")));
//        public static readonly Action<GridSelectionSettingsBuilder> Select = (s => s.Type(GridSelectionType.Row).Mode(GridSelectionMode.Single));
//        public static readonly Action<GridEventBuilder> Events = (e => e.DataBinding("onGridDataBinding"));


//        public const string Toolbar_SaveState = "<a onclick=\"SaveGridState('{0}')\" class=\"k-button k-button-icontext\" ><i class='icon-save'></i></a>";
//    }
//}