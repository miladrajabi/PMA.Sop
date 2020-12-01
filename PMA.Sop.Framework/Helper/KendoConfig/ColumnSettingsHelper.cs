//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Reflection;
//using Kendo.Mvc.UI;
//using Microsoft.AspNetCore.Http;

//namespace TelerikUI.Models.KendoConfig
//{
//    public static class ColumnSettingsHelper
//    {
//        public static List<GridColumnSettings> GetColumns<TModel>(IEnumerable<string> selectedFields)
//        {
//            var type = typeof(TModel);
//            return GetColumns(selectedFields, type);
//        }
//        public static List<GridColumnSettings> GetColumns(IEnumerable<string> selectedFields, Type type)
//        {
//            var result = new List<GridColumnSettings>();

//            foreach (var item in selectedFields)
//            {
//                var pi = type.GetProperty(item);
//                if (pi != null)
//                {
//                    var gridAttribute = (GridAttribute)pi.GetCustomAttributes(typeof(GridAttribute), true).FirstOrDefault() ?? new GridAttribute();
//                    var displayNameAttribute = (DisplayNameAttribute)pi.GetCustomAttributes(typeof(DisplayNameAttribute), true).FirstOrDefault() ?? new DisplayNameAttribute(pi.Name);

//                    var setting = new GridColumnSettings
//                    {
//                        Member = pi.Name,
//                        MemberType = pi.PropertyType,
//                        Title = string.IsNullOrEmpty(gridAttribute.Title) ? displayNameAttribute.DisplayName : gridAttribute.Title,
//                        Format = gridAttribute.Format,
//                        Visible = gridAttribute.Visible,
//                        Hidden = gridAttribute.Hidden,
//                        IncludeInMenu = gridAttribute.IncludeInMenu,
//                        ReadOnly = gridAttribute.ReadOnly,
//                        Filterable = gridAttribute.Filterable,
//                        Sortable = gridAttribute.Sortable,
//                        Width = gridAttribute.Width,
//                        ClientTemplate = gridAttribute.ClientTemplate,
//                        Groupable = gridAttribute.Groupable,
//                        Lockable = gridAttribute.Lockable,
//                        Locked = gridAttribute.Locked,
//                        ClientFooterTemplate = gridAttribute.ClientFooterTemplate

//                    };
//                    //if ((pi.PropertyType == typeof(DateTime) || pi.PropertyType == typeof(DateTime?)) && string.IsNullOrEmpty(gridAttribute.ClientTemplate))
//                    //{
//                    //    setting.ClientTemplate = $"#= GregorianToShamsi({pi.Name}) #";
//                    //}
//                    //else if ((pi.PropertyType == typeof(bool) || pi.PropertyType == typeof(bool?)) && string.IsNullOrEmpty(gridAttribute.ClientTemplate))
//                    //{
//                    //    setting.ClientTemplate = $"#= CreateBooleanCell({pi.Name}) #";
//                    //}
//                    //if (pi.PropertyType == typeof(string) && gridAttribute.MaxChar > 0)
//                    //{
//                    //    setting.ClientTemplate = $"#= CreateMaxCharCell({pi.Name},{gridAttribute.MaxChar}) #";
//                    //}
//                    //if ((pi.PropertyType == typeof(string) && string.IsNullOrEmpty(setting.ClientTemplate)) || gridAttribute.ToPersianNo)//
//                    //{
//                    //    setting.ClientTemplate = $"#= english2PersianNumbers({pi.Name}) #";
//                    //    if(!gridAttribute.Rtl)
//                    //        setting.ClientTemplate = $"#= setLtrDirection(english2PersianNumbers({pi.Name})) #";
//                    //}
//                    //if (string.IsNullOrEmpty(setting.ClientTemplate) && !gridAttribute.Rtl)//
//                    //{
//                    //    setting.ClientTemplate = $"#= setLtrDirection({pi.Name}) #";
//                    //}
//                    //if (gridAttribute.I18N)
//                    //{
//                    //    setting = setting.I18N();
//                    //}
//                    result.Add(setting);
//                }
//            }
//            return result;
//        }
//        public static List<GridColumnSettings> GetColumns<TModel>()
//        {
//            var selectedFields = GetColumnName<TModel>();
//            return GetColumns<TModel>(selectedFields);
//        }
//        public static List<GridColumnSettings> GetColumns(Type type, bool requiredFields = false, bool invisibleFields = false)
//        {
//            var selectedFields = GetColumnName(type, requiredFields, invisibleFields);
//            return GetColumns(selectedFields, type);
//        }
//        public static IEnumerable<string> GetColumnName<TModel>(bool requiredFields = false)
//        {
//            var type = typeof(TModel);
//            return GetColumnName(type, requiredFields);
//        }
//        public static IEnumerable<string> GetColumnName(Type type, bool requiredFields = false, bool invisibleFields = false)
//        {
//            var selectedFields = new Dictionary<string, int>();
//            foreach (var pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
//            {
//                if (!requiredFields && pi.Name.Equals("RequiredFields"))
//                    continue;
//                var gridAttribute = (GridAttribute)pi.GetCustomAttributes(typeof(GridAttribute), true).FirstOrDefault() ?? new GridAttribute();
//                if (gridAttribute.Visible || invisibleFields)
//                    selectedFields.Add(pi.Name, gridAttribute.Order);
//            }
//            return selectedFields.OrderBy(o => o.Value).Select(s => s.Key);
//        }
//        public static GridColumnSettings Copy(this GridColumnSettings input, string prefix = "")
//        {
//            var model = new GridColumnSettings
//            {
//                Member = prefix + input.Member,
//                Title = input.Title,
//                MemberType = input.MemberType,
//                ClientFooterTemplate = input.ClientFooterTemplate,
//                ClientGroupFooterTemplate = input.ClientGroupFooterTemplate,
//                ClientGroupHeaderTemplate = input.ClientGroupHeaderTemplate,
//                ClientTemplate = input.ClientTemplate,
//                Encoded = input.Encoded,
//                Filterable = input.Filterable,
//                FilterUIRole = input.FilterUIRole,
//                Format = input.Format,
//                // FooterHtmlAttributes = input.FooterHtmlAttributes,
//                //FooterTemplate = input.FooterTemplate,
//                Groupable = input.Groupable,
//                //HeaderHtmlAttributes = input.HeaderHtmlAttributes,
//                //HeaderTemplate = input.HeaderTemplate,
//                Hidden = input.Hidden,
//                //HtmlAttributes = input.HtmlAttributes,
//                IncludeInMenu = input.IncludeInMenu,
//                Lockable = input.Lockable,
//                Locked = input.Locked,
//                ReadOnly = input.ReadOnly,
//                Sortable = input.Sortable,
//                Visible = input.Visible,
//                Width = input.Width,

//            };
//            return model;
//        }
//        //public static GridColumnSettings I18N(this GridColumnSettings columnSettings)
//        //{
//        //    var lang = HttpContext.Current.GetPrincipalAppLanguageForRequest()?.GetLanguage();
//        //    columnSettings.Member = $"{columnSettings.Member}{lang}";
//        //    return columnSettings;
//        //}
//    }
//}