using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMA.Sop.Resources.Resources;

namespace PMA.Sop.Domain.DTOs.Products.Categories
{
    public class CreateCategoryDto : BaseModelDto<long>
    {
        [MaxLength(200, ErrorMessage = SharedResource.MaxLength_200)]
        [Required(ErrorMessage = SharedResource.Required)]
        [DisplayName(SharedResource.Title)]
        public string Title { get; set; }

        [DisplayName(SharedResource.Parent)]
        public long? ParentId { get; set; }

        [DisplayName(SharedResource.Icon)]
        public string Icon { get; set; }

        public List<SelectListItem> Parent { get; set; }
        public List<SelectListItem> Icons { get; set; }

    }
}