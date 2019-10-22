using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Deliverable_2_WireFrames.Models;
namespace Deliverable_2_WireFrames.ViewModels
{
    public class CollectionsVM
    {
        public int CollectionsID { get; set; }
        public System.DateTime Date { get; set; }
        public int NoOfItemsCollected { get; set; }
        public int Location_ID { get; set; }
        public Nullable<int> LocationType_ID { get; set; }
        public virtual ICollection<CollectionsLocation> CollectionsLocations { get; set; }

     
    
    }
}
