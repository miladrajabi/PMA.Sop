namespace PMA.Sop.Domain.Product.Commands.Brands
{
    public class ProductImagesCommand
    {
        public bool? IsShow { get; set; } = true;
        public bool? IsBaseImage { get; set; }
        public string Src { get; set; }
    }
}