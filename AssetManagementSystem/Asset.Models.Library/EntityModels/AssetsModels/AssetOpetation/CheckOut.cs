using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.HrModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;

namespace Asset.Models.Library.EntityModels.AssetsModels.AssetOpetation
{
    public class CheckOut
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }


        public DateTime EntryDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public int AssetLocationId { get; set; }
        [ForeignKey("AssetLocationId")]
        public virtual AssetLocation AssetLocation { get; set; }

        public string Commants { get; set; }

        public int AssetEntrysId { get; set; }
        public virtual IEnumerable<AssetEntry> AssetEntries { get; set; }
    }
}
