using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ByteShop.ViewModels
{
    public class EntityViewModel : ViewModelBase
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please set description")]
        public string Description { get; set; }

        public override string Title
        {
            get { return "Entity " + Id; }
        }
    }
}