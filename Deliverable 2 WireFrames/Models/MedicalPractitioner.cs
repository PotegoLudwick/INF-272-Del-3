//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Deliverable_2_WireFrames.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MedicalPractitioner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MedicalPractitioner()
        {
            this.Consultations = new HashSet<Consultation>();
        }
    
        public int MedicalPractitioner_ID { get; set; }
        public Nullable<int> Doctor_ID { get; set; }
        public int Nurse_ID { get; set; }
        public string MedicalPractitioner_Name { get; set; }
        public string MedicalPractitioner_Surname { get; set; }
        public string MedicalPractitioner_Title { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Consultation> Consultations { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Nurse Nurse { get; set; }
    }
}