//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NamesDays.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Name
    {
        public int NameId { get; set; }
        public string Name1 { get; set; }
        public int DayId { get; set; }
    
        public virtual NamesDay NamesDay { get; set; }
    }
}
