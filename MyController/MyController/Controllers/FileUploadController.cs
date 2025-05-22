using Microsoft.AspNetCore.Mvc;

namespace MyController.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult showPhotos()
        {
           string[]files= Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Photos"));
            // 抓 /www.root/Photos 底下的檔案 

            foreach (string item in files)
            {
                string fileName = Path.GetFileName(item); //取得檔案名稱
                ViewData["Photos"] += $"<img src='/Photos/{fileName}'>";

            }




            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormFile photo)      //I表示為"介面"
        {   //最基本的
            if (photo == null || photo.Length == 0)
            { 
               ViewData["ErrMessage"] = "^_^上傳檔案ください";
               return View();
            }

            //只允許上傳圖片 //contenttype=上傳檔案的類型 //常見圖檔類型.jpg、.png、.gif
            if (photo.ContentType != "image/jpeg" && photo.ContentType != "image/png")
            {
                ViewData["ErrMessage"] = "只允許上傳.jpg、.png的圖片檔案";
                return View();
            }


            //取得檔案名稱 
            //Path是路徑  //GetFileName是Static(靜態)method，不需要鑄造物件
            string fileName = Path.GetFileName(photo.FileName);

            //取得檔案的完整路徑
            //Directory.GetCurrentDirectory()是取得目前的路徑
            //Path.Combine是將路徑組合起來
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Photos", fileName);
            // /wwwroot/Photos/檔案名稱

            //將檔案上傳並儲存於指定的路徑
            //FileStream是用來讀取或寫入檔案的類別
            //FileStream fs = new FileStream() →鑄造物件
            //FileMode.Create是用來新創檔案
            //using用來釋放資源(自動回收垃圾)
            using (FileStream fs = new FileStream(filePath, FileMode.Create)) 
            { 
                photo.CopyTo(fs);    //將上傳的檔案複製到指定的路徑 
            }
            ViewData["Result"] = "上傳檔案成功";
            return View();




            
        }
    }
}
