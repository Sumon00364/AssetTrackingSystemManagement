
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys
{
    public class Note
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AssetEntryId { get; set; }
        [ForeignKey("AssetEntryId")]
        public AssetEntry AssetEntry { get; set; }

        public string Notes { get; set; }
    }
}
