using Microsoft.AspNetCore.Mvc;
using MyModel_DBFirst.Models;
namespace MyModel_DBFirst.Controllers
{
    public class MyStudentController : Controller
    {
        //4.1.4 撰寫建立DbContext物件的程式

        dbStudentsContext db = new dbStudentsContext(); //直接建立dbStudentsContext物件

        //讀出tStudent資料表的資料
        public IActionResult Index()
        {
            //4.2.1 撰寫Index Action程式碼

            //select * from tStudents
            //LInq
            //var result=from s in db.tStudent
            //                select s; //從tStudent資料表中選取所有資料

            var result = db.tStudent.ToList();  //select * from tStudents


            return View(result);//將查詢結果傳給view
        }


        public IActionResult Create()
        {

            return View();
        }

        //加入Token標籤
        [HttpPost]
        [ValidateAntiForgeryToken]
        //防止CSRF攻擊(不是阻斷式，會用迴圈一次寫入極多筆資料塞入伺服器)
        //檢查資料進來時是否有攜帶每次變更的權杖才能進來
        public IActionResult Create(tStudent student)
        {
            //檢查學號是否重複

            var result = db.tStudent.Find(student.fStuId); //使用Find方法查詢資料庫中是否存在相同學號的學生

            if (result != null)
            {
                ViewData["ErrorMessage"] = "學號已存在，請重新輸入！"; //將錯誤訊息傳遞到View
                return View(student); //如果學號已存在，則返回Create視圖，並顯示錯誤訊息
            }



            //把表單送來的資料存入資料庫

            if (ModelState.IsValid) //檢查ModelState是否有效
            {
                //1.在模型新增一筆資料
                db.tStudent.Add(student);

                //2.回寫資料庫
                db.SaveChanges();   //轉譯SQL 執行INSERT INTO tStudent(fStuId, fName, fEmail, fScore) VALUES(?, ?, ?, ?)

                return RedirectToAction("Index"); //新增完成後，回到Index頁面
            }

            //模型驗證失敗，則回到Create View
            return View(student); //如果ModelState無效，則返回Create視圖，並顯示錯誤訊息

        }

        //4.4.1撰寫Edit Action程式碼(需有兩個Edit Action)
        public ActionResult Edit(string id)
        {

            ViewData["Now"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");//顯示目前時間


            var result = db.tStudent.Find(id); //用Find去資料表找傳進來的學號string是否存在

            if (result == null) //如果找不到資料
            {
                return NotFound(); //回傳404 Not Found
            }

            return View(result);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(string id,tStudent student) 
        {
            if (id != student.fStuId) 
            { 
            //return NotFound(); //如果傳進來的學號與資料庫不符，則回傳404 Not Found
            return View(student); //如果學號不符，則回到Edit View

            }

            if (ModelState.IsValid) 
            {
                db.tStudent.Update(student); 
                db.SaveChanges();
                return RedirectToAction("Index"); //如果模型驗證成功，則更新資料庫並回到Index頁面

            }

            db.tStudent.Update(student);
            db.SaveChanges(); //將修改後的資料寫入資料庫
            return RedirectToAction("Index");

        }













    }
}
