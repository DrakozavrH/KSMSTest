
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace MarathonSkills
{

using System;
    using System.Collections.Generic;
    
public partial class Runner
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Runner()
    {

        this.Registration = new HashSet<Registration>();

    }


    public int RunnerId { get; set; }

    public string Email { get; set; }

    public string Gender { get; set; }

    public Nullable<System.DateTime> DateOfBirth { get; set; }

    public string CountryCode { get; set; }



    public virtual Country Country { get; set; }

    public virtual Gender Gender1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Registration> Registration { get; set; }

    public virtual User User { get; set; }

}

}
