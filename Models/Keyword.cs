//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrowdCorrect.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Keyword
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Keyword()
        {
            this.UserKeywordTags = new HashSet<UserKeywordTag>();
        }
    
        public int Id { get; set; }
        public int TweetId { get; set; }
        public bool IsRelatedToHealth { get; set; }
        public string Keyword1 { get; set; }
    
        public virtual Tweet Tweet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserKeywordTag> UserKeywordTags { get; set; }
    }
}
