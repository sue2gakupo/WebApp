using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyController.Models;

namespace MyController.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["myTime"] = DateTime.Now;

            ViewData["myLink"] = "<a href='http://www.google.com.tw'>�I�ڨ�google!!</a>";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CheckIDNumber(string ID)
        {
            //A123456789
            //�榡�ˬd
            // 1.���ץ����O10�Ӧr��
            // 2.�Ĥ@�Ӧr�������O�^��r��
            // 3.�ĤG�Ӧr�������O1��2�Ʀr
            // 4.�ĤT�ӥH�᪺�r������0~9�O�Ʀr

            if (string.IsNullOrEmpty(ID))
                ViewData["Result"] = "�o�н��J�����Ҧr��";

            if (ID.Length != 10)
                ViewData["Result"] = "�o�O���X�k�������Ҧr��";




            string letters = "ABCDEFGHJKLMNPQRSTUVXYWZIO";

            if (letters.IndexOf(ID[0]) == -1)
                ViewData["Result"] = "�o�O���X�k�������Ҧr��";

            if (ID[1] != '1' && ID[1] != '2')
                ViewData["Result"] = "�o�O���X�k�������Ҧr��";

            for (int i = 2; i < ID.Length; i++)
            {
                if (ID[i] < '0' || ID[i] > '9')
                    ViewData["Result"] = "�o�O���X�k�������Ҧr��";
            }
            ///////////////////////////////////////////////////////////////////
            ///

            int letterNum = letters.IndexOf(ID[0]) + 10;

            int n1 = letterNum / 10;
            int n2 = letterNum % 10;

            //�ϩR���F�g�k
            //int n = n1 * 1 + n2 * 9 + ID[1] * 8 + ID[2] * 7 + ID[3] * 6 + ID[4] * 5 + ID[5] * 4 +
            //    ID[6] * 3 + ID[7] * 2 + ID[8] * 1 + ID[9] * 1;


            //�º��q��
            int n = n1 * 1 + n2 * 9;

            for (int i = 1; i <= 8; i++)
            {
                n += (ID[i] - '0') * (9 - i);

            }

            n += ID[9] - '0';

            if (n % 10 == 0)
                ViewData["Result"] = "�o�O�X�k�������Ҧr��";
            else
                ViewData["Result"] = "�o�O���X�k�������Ҧr��";


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
