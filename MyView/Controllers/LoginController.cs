using Microsoft.AspNetCore.Mvc;

namespace MyView.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Models.Login login)
        {

            //1.抓表單送來的帳密
            //2.驗證帳密是否正確

            //3.如果正確，則登入成功，導向後台頁面
            //4.如果錯誤，則導向登入頁面，並顯示錯誤訊息

            //假設這裡的帳號密碼是 admin / 12345678

            if (login.UserName=="admin"&&login.Password=="12345678")
            {
                // 導向後台頁面
                return RedirectToAction("Index", "Home");
            }

            ViewData["Error"]="帳號或密碼錯誤";
            return View();
        }

    }
}
