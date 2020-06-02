//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.Users = new HashSet<User>();
        }
    
        public string Link { get; set; }
        public string Meta { get; set; }
        public Nullable<bool> Hide { get; set; }
        public Nullable<System.DateTime> Datebegin { get; set; }
        public string Images { get; set; }
        public string Name { get; set; }
        public int CourseID { get; set; }
        public string Descriptions { get; set; }
        public string Level { get; set; }
        public Nullable<int> Order { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
