
using System.ComponentModel.DataAnnotations;

namespace MyModel_DBFirst.Models
{
    public class Department 
    {
        //5.6.6 編輯Department 模型
        [Key]
        [Display(Name ="科系代碼")]
        [StringLength(2, ErrorMessage = "科系代碼最多2碼")]
        [Required(ErrorMessage = "必填")]


        public string DeptID { get; set; } = null!; //抓主鍵，科系代碼


        [Display(Name = "科系名稱")]
        [StringLength(30, ErrorMessage = "科系名稱最多2碼")]
        [Required(ErrorMessage = "必填")]
        public string DeptName { get; set; } = null!; //科系名稱


        public List<tStudent>? tStudents { get; set; } //與tStudent的關聯，表示一個科系可以有多個學生，所以學生可能是空值，程式要放"?"


    }
}
