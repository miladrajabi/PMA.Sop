using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMA.Sop.Resources.Resources;

namespace PMA.Sop.Domain.DTOs.Products.Categories
{
    public class CreateCategoryDto : BaseModelDto<long>
    {
        [MaxLength(200, ErrorMessage = SharedResource.MaxLength_256)]
        [Required(ErrorMessage = SharedResource.Required)]
        [DisplayName(SharedResource.Title)]
        public string Title { get; set; }

        [DisplayName(SharedResource.Title)]
        public long? ParentId { get; set; }
        public string Icon { get; set; }

        public List<SelectListItem> Parent { get; set; }
        public List<SelectListItem> Icons { get; set; }

    }
}