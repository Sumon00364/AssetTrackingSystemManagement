using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.OrganizationModels;

namespace Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys
{
    public class AssetEntry
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        public int AssetLocationId { get; set; }
        [ForeignKey("AssetLocationId")]
        public virtual AssetLocation AssetLocation { get; set; }

        public int AssetTypeId { get; set; }
        [ForeignKey("AssetTypeId")]
        public virtual AssetType AssetType { get; set; }

        public int AssetGroupId { get; set; }
        [ForeignKey("AssetGroupId")]
        public virtual AssetGroup AssetGroup { get; set; }

        public int AssetManufacurerId { get; set; }
        [ForeignKey("AssetManufacurerId")]
        public AssetManufacurer AssetManufacurer { get; set; }

        public int AssetModelId { get; set; }
        [ForeignKey("AssetModelId")]
        public AssetModel AssetModel { get; set; }

        public string AssetId { get; set; }
        public string Name { get; set; }
        public string SerialNo { get; set; }
        public bool Status { get; set; }
        public byte[] Attachment { get; set; }
    }
}
