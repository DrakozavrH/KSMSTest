//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarathonSkills
{
    using System;
    using System.Collections.Generic;
    
    public partial class Registration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Registration()
        {
            this.RegistrationEvent = new HashSet<RegistrationEvent>();
            this.Sponsorship = new HashSet<Sponsorship>();
        }
    
        public int RegistrationId { get; set; }
        public int RunnerId { get; set; }
        public System.DateTime RegistrationDateTime { get; set; }
        public string RaceKitOptionId { get; set; }
        public byte RegistrationStatusId { get; set; }
        public decimal Cost { get; set; }
        public int CharityId { get; set; }
        public decimal SponsorshipTarget { get; set; }
    
        public virtual Charity Charity { get; set; }
        public virtual RaceKitOption RaceKitOption { get; set; }
        public virtual RegistrationStatus RegistrationStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistrationEvent> RegistrationEvent { get; set; }
        public virtual Runner Runner { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sponsorship> Sponsorship { get; set; }
    }
}
