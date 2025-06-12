using Microsoft.AspNetCore.Mvc;
using MyModel_DBFirst.Models;
namespace MyModel_DBFirst.Controllers
{
    public class MyStudentController : Controller
    {
        //4.1.4 撰寫建立DbContext物件的程式

        dbStudentsContext _context = new dbStudentsContext(); //直接建立dbStudentsContext物件

        //讀出tStudent資料表的資料
        public IActionResult Index()
        {

            //4.2.1 撰寫Index Action程式碼

            

            return View();
        }
    }
}
