using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys
{
    public class ServiceOrRepairing
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AssetEntryId { get; set; }
        [ForeignKey("AssetEntryId")]
        public virtual AssetEntry AssetEntry { get; set; }

        public string Description { get; set; }
        public DateTime? ServiceDate { get; set; }
        public decimal ServiceingCostDecimal { get; set; }
        public decimal PartsCostDecimal { get; set; }
        public decimal TaxDecimal { get; set; }
        public string ServiceBy { get; set; }
    }
}
