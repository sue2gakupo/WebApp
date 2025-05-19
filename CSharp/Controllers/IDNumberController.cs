using Microsoft.AspNetCore.Mvc;

namespace CSharp.Controllers
{
    public class IDNumberController : Controller
    {
        public string CheckIDNumber(string ID)
        {
            //A123456789
            //step1.格式檢查
            //1.長度必須是10個字元
            //2.第一個字元必須是英文字母
            //3.第二個字元必須是1或2的數字
            //4.第三個字元必須是0~9的數字


            if (string.IsNullOrEmpty(ID))  //先驗有沒有輸入
                return "請輸入身分證字號";

            
            if (ID.Length!=10)  //字串不是10個字的話
                return "這是非法的身分證字號";

            

            string letters = "ABCDEFGHJKLMNPQRSTUVXYWZIO";  //字串可以當陣列用
            if(letters.IndexOf(ID[0])==-1)  //2.第一個字元必須是英文字母
                return "這是非法的身分證字號";

            if (ID[1] != '1' || ID[1] != '2')  //3.第二個字元必須是1或2的數字 //在字串裡面找substract要用單引號
                return "這是非法的身分證字號";

            for (int i = 2;i<ID.Length; i++)
            {
                if (ID[i] < '0' || ID[i] > '9')  //4.第三個字元必須是0~9的數字
                    return "這是非法的身分證字號";
            }

            /////////////////////////////////////
            //step2.計算合理性

            int lettersNum = letters.IndexOf(ID[0]) + 10; //字母的值
            int n1 = lettersNum / 10; 
            int n2 = lettersNum % 10;

            //一定會寫對
            //int n = n1 * 1 + n2 * 9 + ID[1]*8 + ID[2]*7 + ID[3] * 6
            //    + ID[4] * 5 + ID[5] * 4 + ID[6] * 3 + ID[7] * 2 + ID[8] * 1+ID[9]*1; 

            //畫面精簡
            int n = n1 * 1 + n2 * 9;
            for (int i = 1; i <= 8; i++)
            { 
                n += (ID[i]-'0') * (9 - i); 
            }
            n += ID[9];


            if (n % 10 == 0)
                    return "這是合法的身分證字號";

            return "這是非法的身分證字號";


        }
    }
}
