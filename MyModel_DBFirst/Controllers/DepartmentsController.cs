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
                ViewData["ErrorMessage"] = "科系代碼已存在，請重新輸入！";
                //將錯誤訊息傳遞到View，要在CreateView裡面加上<span class="text-danger">@ViewData["ErrorMessage"]</span>
                //這樣才能在畫面上顯示錯誤訊息
                return View(department); //如果科系代碼已存在，則返回Create視圖，並顯示錯誤訊息
            }


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
        //用來判斷某個科系代碼（DeptID）是否已經存在於資料庫中。這通常用於新增或編輯資料時，避免重複的主鍵值。
        private bool DepartmentExists(string id)
        {
            return _context.Department.Any(e => e.DeptID == id);
        }

    }
}
