using Microsoft.AspNetCore.Mvc;

namespace MyController.Controllers
{
    public class SimpleBindController : Controller
    {
        //商品資料表：商品編號、商品名稱、商品價格
        //1.要先有一個可以讓人新增商品的表單介面(將介面實作於View)
        //2.所以要先有一個相對應的action來顯示表單
        //3.假設View名稱
        public IActionResult Create()
        {

            return View();
        }

        //表單submit後，會將資料傳到Controller的指定action
        [HttpPost]
        public IActionResult Create(string ProductNo, string ProductName, string ProductPrice)
        {
            ViewData["ProductNo"] = ProductNo;
            ViewData["ProductName"] = ProductName;
            ViewData["ProductPrice"] = ProductPrice;

            return View();

        }

        public IActionResult Create2()
        {
            return View();
        }
    }
}
