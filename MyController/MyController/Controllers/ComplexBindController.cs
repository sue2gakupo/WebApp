using Microsoft.AspNetCore.Mvc;
using MyController.Models;

namespace MyController.Controllers
{
    public class ComplexBindController : Controller
    {
        //會員資料表：會員編號、會員姓名、會員電話、地址、性別
        //1.撰寫會員資料表的資料模型(複雜繫結法必須要有模型Model)
        //2.撰寫會員資料表的表單介面(將介面實作於View)
        //3.撰寫會員資料表的action來顯示表單
        //4.View的名稱是Create.cshtml,則需有Create()Action

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Member member) 
        {


            ViewData["MemberID"] = member.MemberID;
            ViewData["MemberName"] = member.MemberName;
            ViewData["Phone"] = member.Phone;
            ViewData["Adress"] = member.Address;
            ViewData["Gender"]= member.Gender;


            return View();
        }

    }
}
