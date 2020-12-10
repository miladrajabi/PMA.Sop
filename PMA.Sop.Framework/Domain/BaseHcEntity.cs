using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMA.Sop.Framework.Domain
{
    public class BaseHcEntity<TKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public TKey Id { get; set; }

        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Required]
        public string Title { get; set; }

        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string EnglishTitle { get; set; }

        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string Remarks { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }

    }
}