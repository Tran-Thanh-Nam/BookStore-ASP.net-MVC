//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLNS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSach()
        {
            this.tblCTPhieuNhaps = new HashSet<tblCTPhieuNhap>();
        }
    
        public int ma_sach { get; set; }
        public string ten_sach { get; set; }
        public Nullable<int> ma_tac_gia { get; set; }
        public Nullable<int> ma_the_loai { get; set; }
        public Nullable<int> ma_nxb { get; set; }
        public Nullable<System.DateTime> nam_xb { get; set; }
        public Nullable<int> gia { get; set; }
        public Nullable<int> tinhnang { get; set; }
        public string hinhanh { get; set; }
    
        public virtual tblNXB tblNXB { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCTPhieuNhap> tblCTPhieuNhaps { get; set; }
        public virtual tblTacGia tblTacGia { get; set; }
        public virtual tblTheLoai tblTheLoai { get; set; }
    }
}
