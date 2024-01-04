using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountBundle.Model
{
    public class BundlePartEntity
    {
        public int BundlePartEntityId { get; set; }
        public string Name { get; set; }

        public bool IsPairExist { get; set; } = false;
        public int InventoryCount { get; set; }

        public List<BundlePartSubEntity> SubParts { get; set; }
    }
}
