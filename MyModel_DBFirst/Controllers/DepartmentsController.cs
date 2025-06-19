using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyModel_DBFirst.Models;

namespace MyModel_DBFirst.Controllers
{
    public class DepartmentsController : Controller
    {
        //private readonly dbStudentsContext _context;

        //public DepartmentsController(dbStudentsContext context)
        //{
        //    _context = context;
        //} //依賴注入(Dependency Injection, DI)的寫法，目前我們尚未學到，因此先用一般new物件的寫法


        //5.6.4 參考2 .2.1修改建立DbContext物件的程式
        dbStudentsContext _context = new dbStudentsContext(); //直接建立new 物件dbStudentsContext 

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Department.ToListAsync());
        }



        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeptID,DeptName")] Department department)
        {

            var result = _context.Department.Find(department.DeptID); //使用Find方法查詢資料庫中是否存在相同科系代碼的科系

            if (result != null)
            {
                ViewData["DeptIDError"] = "科系代碼已存在，請重新輸入！";
                //將錯誤訊息傳遞到View，要在CreateView裡面加上<span class="text-danger">@ViewData["ErrorMessage"]</span>
                //這樣才能在畫面上顯示錯誤訊息
                return View(department); //如果科系代碼已存在，則返回Create視圖，並顯示錯誤訊息
            }

            //檢查科系名稱是否重複（DeptName 非主鍵，需自行檢查唯一性）
            //Any() 方法會回傳一個布林值，表示是否有任何一筆資料符合條件，只要有一筆 DeptName 相同的資料就會回傳 true，否則回傳 false。
            //因為只需要知道「有沒有重複」，不需要取得所有重複的資料，所以用 bool 來判斷最有效率。
            //bool isDeptNameExist = _context.Department.Any(d => d.DeptName == department.DeptName);
            //if (isDeptNameExist)
            //{
            //    ViewData["DeptNameError"] = "科系名稱已存在，請重新輸入！";
            //    return View(department);
            //}


            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }


        //這是一個私有方法，名稱為 DepartmentExists，傳入一個字串參數 id，回傳型別為 bool（布林值）。
        //方法內容會檢查資料庫中的 Department 資料表，是否有任何一筆資料的 DeptID 屬性等於傳入的 id。
        //使用 _context.Department.Any(...)，只要有一筆符合條件就會回傳 true，否則回傳 false。
        //DeptID（主鍵）唯一性檢查在多個地方（如編輯、刪除、AJAX 檢查等）都會用到，所以抽成 private 方法方便重複使用
        private bool DepartmentExists(string id)
        {
            return _context.Department.Any(e => e.DeptID == id);
        }

        //新增一個 Controller Action 供 AJAX 查詢，
        //並在前端用 jQuery 於輸入欄位失去焦點時即時檢查，讓使用者在送出前就能看到重複訊息。

        [HttpGet]
        public JsonResult CheckDeptID(string deptID)
        {
            bool exists = _context.Department.Any(d => d.DeptID == deptID);
            return Json(!exists); // true: 可用, false: 已存在
        }

        //[HttpGet]
        //public JsonResult CheckDeptName(string deptName)
        //{
        //    bool exists = _context.Department.Any(d => d.DeptName == deptName);
        //    return Json(!exists); // true: 可用, false: 已存在
        //}





    }
}
