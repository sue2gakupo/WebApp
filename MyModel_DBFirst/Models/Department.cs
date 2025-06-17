
using System.ComponentModel.DataAnnotations;

namespace MyModel_DBFirst.Models
{
    public class Department 
    {
        [Key]
      public string DeptID { get; set; } = null!; //科系代碼，主鍵
        [Required(ErrorMessage = "必填")]
        [StringLength(30, ErrorMessage = "科系名稱最多30個字元")]
        public string DeptName { get; set; } = null!; //科系名稱
        [StringLength(100, ErrorMessage = "科系簡介最多100個字元")]

        public List<tStudent>? tStudents { get; set; } //與tStudent的關聯，表示一個科系可以有多個學生，所以學生可能是空值，程式要放"?"


    }
}
