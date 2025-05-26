using Microsoft.AspNetCore.Mvc;
using MyView.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace MyView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private static List<NightMarket> GetData()
        {
            string[] id = { "A01", "A02", "A03", "A04", "A05", "A06", "A07" };
            string[] name = { "���ש]��", "�sԳ���Ӱ�", "���X�]��", "�C�~�]��", "���]��", "�j�F�]��", "�Z�t�]��" };
            string[] address = { "813����������ϸθ۸�", "800�������s���ϥɿŨ�", "800�x�W�������s���Ϥ��X�G��",
                "80652�������e��ϳͱۥ|��758��", "�x�n���_�Ϯ��w���T�q533��", "�x�n���F�ϪL�˸��@�q276��",
                "�x�n������ϪZ�t��69��42��" };

            List<NightMarket> list = new List<NightMarket>();

            for (int i = 0; i < id.Length; i++)
            {
                NightMarket nm = new NightMarket();
                nm.Id = id[i];
                nm.Name = name[i];
                nm.Address = address[i];
                list.Add(nm);
            }

            return list;
        }

        public IActionResult IndexRWD()
        {
            return View(GetData());
        }

        public IActionResult IndexList(string id)
        {
            var list = GetData();


            VMNightMarket vMN = new VMNightMarket()
            {
                //���������C
                //���o�Ҧ��]����ƪ��s���P�W��
                NightMarkets = list,
                //�k����ܸ�Ƥ��e�D�e��
                //���o�Y�@���]����ƪ��ԲӤ��e
                NightMarket = list.Where(list => list.Id == id).FirstOrDefault()
            };

           

            //���������C
            //���o�Ҧ��]����ƪ��s���P�W��
            //ViewBag["nm"] = list;

            //�k����ܸ�Ƥ��e�D�e��
            //���o�Y�@���]����ƪ��ԲӤ��e
            //Lambda�g�k

            //var result =list.Where(list => list.Id == id).FirstOrDefault();


            return View(vMN);
        }

        public IActionResult Index()
        {

            return View(GetData());
        }

        public IActionResult Details(string id)
        {
            var list = GetData();

            //select *
            //from NightMarket(=list
            //where Id = 'A09'

            ////Linq�g�k:����SQL�y�k
            //var result = (from n in list
            //             where n.Id == id
            //             select n).FirstOrDefault();

            //Lambda�g�k:²��A�i���gLinq�ǧU�g�X��
            var result = list.Where(list => list.Id == id).FirstOrDefault();


            return View(result);
        }


        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Razor()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
