//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.AttendanceTables = new HashSet<AttendanceTable>();
        }
    
        public int StudentID { get; set; }
        public int LevelID { get; set; }
        public int ClassID { get; set; }
        public string StudentName { get; set; }
        public string StudentMobile { get; set; }
        public string StudentEmail { get; set; }
        public string StudentDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Photo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> TeacherID { get; set; }
        public Nullable<int> AttendanceID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttendanceTable> AttendanceTables { get; set; }
        public virtual AttendanceTable AttendanceTable { get; set; }
        public virtual Class Class { get; set; }
        public virtual Level Level { get; set; }
        public virtual TeacherTable TeacherTable { get; set; }
    }
}
