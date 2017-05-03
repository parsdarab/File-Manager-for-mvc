using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace FileManagerForMvc.DataAccess
{
    public class Product
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        [Display(Name = "عکس کالا")]
        public HttpPostedFileBase File { get; set; }

        public string FilePath { get; set; }
    }
}