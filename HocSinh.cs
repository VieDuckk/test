namespace LamLaiTX2Lan2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocSinh")]
    public partial class HocSinh
    {
        [Key]
        [StringLength(10)]
        [Required(ErrorMessage ="Bạn phải nhập SBD")]
        [DisplayName("Số báo danh")]
        public string sbd { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Bạn phải nhập họ tên")]
        [DisplayName("Họ tên")]
        public string hoten { get; set; }

        [StringLength(50)]
        [DisplayName("Ảnh dự thi")]
        public string anhduthi { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập mã lớp")]
        [DisplayName("Mã Lớp")]
        public int? malop { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập điểm thi")]
        [DisplayName("Điểm thi")]
        public double? diemthi { get; set; }
        public virtual LopHoc LopHoc { get; set; }
    }
}
