//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Låtar
    {
        public int LåtId { get; set; }
        public string Titel { get; set; }
        public int KompositörId { get; set; }
        public string Kompositör { get; set; }
        public string Blog_url { get; set; }
    
        public virtual Kompositörer Kompositörer { get; set; }
    }
}
