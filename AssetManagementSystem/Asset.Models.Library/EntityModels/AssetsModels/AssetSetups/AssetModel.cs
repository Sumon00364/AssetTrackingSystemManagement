
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset.Models.Library.EntityModels.AssetsModels.AssetSetups
{
    public class AssetModel
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AssetGroupId { get; set; }
        [ForeignKey("AssetGroupId")]
        public virtual AssetGroup AssetGroup { get; set; }

        public int AssetManufacurerId { get; set; }
        [ForeignKey("AssetManufacurerId")]
        public virtual AssetManufacurer AssetManufacurer { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
