using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class EmpModel
    {
        [Required]
        [DataType(DataType.Upload)]
        [Display(Name="Select File")]
        public HttpPostedFileBase files { get; set; }
    }

    public class FileDetailsModel
    {
        public int Id { get; set; }
        [Dislay(Name="Uploaded File")]
        public String FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}