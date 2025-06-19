using MyModel_DBFirst.Models;

namespace MyModel_DBFirst.ViewModels
{
    public class VMtStudent
    {
        public List<tStudent>? Students { get; set; } //tStudent資料表的物件

        public List<Department>? Departments { get; set; } //Department資料表的物件 //"?"表示資料可有可無
    }
}
