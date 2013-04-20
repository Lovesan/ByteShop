using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ByteShop.ViewModels
{
    public class EntityListViewModel : ViewModelBase
    {
        public override string Title
        {
            get { return "Entities"; }
        }

        public IEnumerable<EntityViewModel> Entities { get; set; }
    }
}