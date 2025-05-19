using Microsoft.AspNetCore.Mvc;

namespace CSharp.Controllers
{
    public class CSharpController : Controller
    {
        //在類別理的一個方法，它叫action
        public IActionResult Index()
        {
            return View();
        }

        public String Hello()
        {
            return "Hello World!";
        }

        //public void Number()
        //{
        //    int a = 123;
        //    short b = 123;
        //    long c = 123;

        //    float d = 12.23f;
        //    double e = 12.23;
        //}

        //public void Var()
        //{

        //    string a = "123";
        //    bool b = true;
        //}

        //public string Stament() 
        //{
        //    int a = 123;
        //    a += 10;
        //    a++;
        //    return "a變數的值為" + a;    
        // }

        //有參數的action
        public string IfStatement(int score) 
        {
            if (score >= 90 && score <= 100) {
                return "優等";
            }
            else if (score >= 80)
            {
                return "甲等";
            }
            else if(score >= 70)
            {
                return "乙等";
            }
            else if(score >= 60)
            {
                return "丙等";
            }
            else if(score >= 0 && score < 60) {
                return "丁等";
            }
            return "請輸入0~100的整數值";
        }

        //for敘述
        public void ForStatement()
        {
            string[] Rainbow = [ "紅", "橙", "黃", "綠", "藍", "靛", "紫" ];
            string[] RainbowColor = ["Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet"];

            string result = "";

            for(int i=0; i < Rainbow.Length; i++)
            {
                //result += Rainbow[i] + RainbowColor;

                //result += "<span style='color:"+RainbowColor[i]+"'>"+Rainbow[i]  + "</span>";

                result += $"<span style='color:{RainbowColor[i]}'>{Rainbow[i]}</span>";

            }
            Response.ContentType = "text/html; charset=utf-8"; //回應的內容類型 執行html的效果，utf-8=繁中
            Response.WriteAsync(result); //return就是回應
        }

        //while敘述
        public void WhileStatement()
        {
            int i = 0;
            string result = "";
            while (i < 10)
            {
                result += i + " ";
                i++;
            }
            Response.ContentType = "text/html; charset=utf-8"; //回應的內容類型 執行html的效果，utf-8=繁中
            Response.WriteAsync(result); //return就是回應
        }




    }
}
