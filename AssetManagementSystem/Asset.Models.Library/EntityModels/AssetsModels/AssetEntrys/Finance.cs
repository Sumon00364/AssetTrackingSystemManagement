using Asset.Models.Library.EntityModels.Purchases;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys
{
    public class Finance
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AssetEntryId { get; set; }
        [ForeignKey("AssetEntryId")]
        public AssetEntry AssetEntry { get; set; }

        public int VendorId { get; set; }
        [ForeignKey("VendorId")]
        public Vendor Vendor { get; set; }

        public decimal ParchasePrice { get; set; }
        public string ParchaseOrderNo { get; set; }
        public DateTime? PurchaseDate { get; set; }
    }
}
