using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PMA.Sop.Web.Common.TagHelper
{
    [HtmlTargetElement("label", Attributes = ForAttributeName)]
    public class RequiredTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        private const string ForAttributeName = "asp-for";

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            if (For.Metadata.IsRequired)
            {
                var existingClass = output.Attributes.FirstOrDefault(f => f.Name == "class");
                var cssClass = string.Empty;
                if (existingClass != null)
                {
                    cssClass = $"{existingClass.Value} ";
                }

                cssClass += "required";
                output.Attributes.SetAttribute("class", cssClass);
            }
        }
    }
}