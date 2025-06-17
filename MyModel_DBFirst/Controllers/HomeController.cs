using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MyModel_DBFirst.Models;
using System.Diagnostics;

namespace MyModel_DBFirst.Controllers
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
            return View();
        }

        public IActionResult Privacy()
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


//MyModel_DBFirst�M�׶i��B�J

//1.�ϥ�DB First�إ� Model

//1.1 �bSSMS������dbStudents.sql�{���X�A�إ߽d�Ҹ�ƮwdbStudents�A���t�@��tStudent��ƪ�

//1.2 �إ߱M�׻P��Ʈw���s�u
//1.2.1 �ϥ�NuGet(�M�צW�٤W���k����޲zNuGet�M��)�w�ˤU�C�M��
//      (1) Microsoft.EntityFrameworkCore.SqlServer
//      (2) Microsoft.EntityFrameworkCore.Tools

//1.2.2 ��SSMS�]�w�n�JSQL Server���ϥΪ�(�������ճs�u���\)

//1.2.3 ��M��޲z���D���x(�˵� > ��L���� > �M��޲z���D���x)�U���O
//      Scaffold-DbContext "Data Source=���A����};Database=��Ʈw�W��;TrustServerCertificate=True;User ID=�b��;Password=�K�X" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -NoOnConfiguring -UseDatabaseNames -NoPluralize -Force
//      �Y���\���ܡA�|�ݨ�Build succeeded.�r���A�æbModels��Ƨ��̬ݨ�dbStudentsContext.cs(�y�z��Ʈw)��tStudent.cs(�y�z��ƪ�)

//1.2.4 �bdbStudentsContext.cs�̼��g�s�u���Ʈw���{��
//      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//              => optionsBuilder.UseSqlServer("Data Source=���A����};Database=��Ʈw�W��;TrustServerCertificate=True;User ID=�b��;Password=�K�X");

//1.2.5 �bdbStudentsContext.cs�̼��g�@�ӪŪ��غc�l
//      public dbStudentsContext()
//      {
//      }
///////////////////////////////////////////////////////
///

//2.  �s�@�۰ʥͦ���tStudent��ƪ�CRUD�\��

//2.1 �ϥ�Scaffold��k��Visual Studio�۰ʫإߥXtStudent��ƪ���CRUD�\��
//    �]�ttStudentController��Index.cshtml�BCreate.cshtml�BEdit.cshtml�BDelete.cshtml�BDetails.cshtml������View�������{���X

//2.1.1 �bControllers��Ƨ��W���k����[�J�����
//2.1.2 ��ܡu�ϥ�EntityFramework�����˵���MVC����v�����U�u�[�J�v�s
//2.1.3 �b��ܤ�����]�w�p�U
//      �ҫ����O: tStudent(MyModel_DBFirst.Models)
//      ��Ƥ��e���O: dbStudentsContext(MyModel_DBFirst.Models)
//      �Ŀ� �����˵�
//      �Ŀ� �Ѧҫ��O�X�{���w
//      �Ŀ� �ϥΪ����t�m��
//      ����W�٨ϥιw�]�Y�i(tStudentsController)
//      ���U�u�s�W�v�s
//2.1.4 ����Visual Studio�|�i��Scaffolding�ʧ@�A�N���X�@��tStudentsController
//      (�|�]�t�Ҧ�������Action)�Τ���View(Index.cshtml�BCreate.cshtml�BEdit.cshtml�BDelete.cshtml�BDetails.cshtml)�������{���X

//      ���Ƶ�������
//      Index.cshtml(List�d��)
//      Create.cshtml(Create�d��)
//      Edit.cshtml(Edit�d��)
//      Delete.cshtml(Delete�d��)
//      Details.cshtml(Details�d��)


//2.2   �ק�tStudentsController���e
//2.2.1 ���g�إ�DbContext���󪺵{��
//      dbStudentsContext _context=new dbStudentsContext();
//2.2.2 �N����J�����{���X(�p�U)���ѱ�
//      private readonly dbStudentsContext _context;
//      public tStudentsController(dbStudentsContext context)
//      {
//          _context = context;
//      }
//���۰ʥͦ���Controller�g�k���̿�`�J(Dependency Injection, DI)�A�ثe�ڭ̩|���Ǩ�A�]�����Τ@��new���󪺼g�k��


//2.3   ����Index View�i��CRUD�\�����

//���ɥR������
//Visual Studio�۰ʫإߥX��tStudentController�A�w�]�|�ϥΡu�̿�`�J(Dependency Injection)�v���g�k
//���L�@�}�l�ڭ̥����ϥΨ̿�`�J���g�k�A�]���ڭ̻ݭק�p 1.2.5 �� 2.2 ���B�J���{���X��~�ॿ�`����


///////////////////////////////////////////////////////
//3. ���g�ҫ����e

//3.1 ���}tStudent.cs�ɮ�
//3.2 ���g�bView�W��ܪ���줺�e(��using System.ComponentModel.DataAnnotations)
//3.3 ���g�b���W��������ҳW�h
//    �`�Ϊ����Ҿ� Required�BStringLength�BRegularExpression�BCompare�BEmailAddress�BRange�BDataType
//    Required:�������
//    StringLength:��Ʀr��
//    RegularExpression:��Ʈ榡(���h)
//    Compare:�P�䥦������O�_�۵�
//    EmailAddress:�O�_�OE-mail�榡
//    Range: ����Ҷ񪺽d��



///////////////////////////////////////////////////////
//4.�s�@��u���y��tStudent��ƪ�CRUD�\��

//4.1   �إ�MyStudentsController
//4.1.1 �bControllers��Ƨ��W���k����[�J�����
//4.1.2 ��ܡuMVC��� - �ťաv
//4.1.3 ��J�ɦWMyStudentsController.cs
//4.1.4 ���g�إ�DbContext���󪺵{��

//4.2   �إߦP�B���檺Index Action
//4.2.1 ���gIndex Action�{���X
//4.2.2 �إ�Index View
//4.2.3 �bIndex Action�����k����s�W�˵�����ܡuRazor�˵��v�����U�u�[�J�v�s
//4.2.4 �b��ܤ�����]�w�p�U
//      �˵��W��: Index
//      �d��:List
//      �ҫ����O: tStudent(MyModel_DBFirst.Models)
//      ��Ƥ��e���O: dbStudentsContext(MyModel_DBFirst.Models)
//      ���Ŀ� �إߦ������˵�
//      ���Ŀ� �Ѧҫ��O�X�{���w
//      �Ŀ� �ϥΪ����t�m��
//4.2.5 ����Index View����
//4.2.6 �ק虜���W����r�A����Details���W�쵲
//      ���i�̦ۤv���ߦn�ק�View����ܡ�


//4.3   �إߦP�B���檺Create Action
//4.3.1 ���gCreate Action�{���X(�ݦ����Create Action)
//4.3.2 �إ�Create View
//4.3.3 �bCreate Action�����k����s�W�˵�����ܡuRazor�˵��v�����U�u�[�J�v�s
//4.3.4 �b��ܤ�����]�w�p�U
//      �˵��W��: Create
//      �d��:Create
//      �ҫ����O: tStudent(MyModel_DBFirst.Models)
//      ��Ƥ��e���O: dbStudentsContext(MyModel_DBFirst.Models)
//      ���Ŀ� �إߦ������˵�
//      �Ŀ� �Ѧҫ��O�X�{���w
//      �Ŀ� �ϥΪ����t�m��
//4.3.5 ����Create�\�����
//      ���i�̦ۤv���ߦn�ק�View����ܡ�

//4.3.6 �[�J�ˬd�D��O�_���Ъ��{��
//4.3.7 �[�JToken���Ҽ���
//  ��Token���Ҫ��\�άO����CSRF�����A����洣��ɯ�����ҽШD���X�k�ʡ�


//4.4   �إߦP�B���檺Edit Action
//4.4.1 ���gEdit Action�{���X(�ݦ����Edit Action)
//4.4.2 �إ�Edit View
//4.4.3 �bEdit Action�����k����s�W�˵�����ܡuRazor�˵��v�����U�u�[�J�v�s
//4.4.4 �b��ܤ�����]�w�p�U
//      �˵��W��: Edit
//      �d��:Edit
//      �ҫ����O: tStudent(MyModel_DBFirst.Models)
//      ��Ƥ��e���O: dbStudentsContext(MyModel_DBFirst.Models)
//      ���Ŀ� �إߦ������˵�
//      �Ŀ� �Ѧҫ��O�X�{���w
//      �Ŀ� �ϥΪ����t�m��
//4.4.5 ����Edit�\�����
//      ���i�̦ۤv���ߦn�ק�View����ܡ�


//4.5   �إߦP�B���檺Delete Action
//4.5.1 ���gDelete Action�{���X
//4.5.2 �NIndex View��Delete�אּForm�A�HPost�覡�e�X
//4.5.3 �NDelete Actione�令Post�覡
//4.5.3 ����Delete�\�����
//���ɥR������
//�o�ؼg�k�Τ���Delete View�A�]���i�H��Delete.cshtml�R��
//Delete�����s�Y�ϥζW�쵲�A�ϥΪ̱N�i�����burl���ѼƴN��R�����


//�d�ұ��ҡG�ǥͭn�h�X��t��ơA�ҥH��Ʈw�ݭn�ק�A�إߤ@�Ӭ�t��ƪ�ûPtStudent��ƪ����p
//5. ��Ʈw�ק�
//���ѩ�DB First�O�H�ϦV�u�{�Q�θ�Ʈw�g�����{���X�A�]���b��Ʈw���p�T�ܰʮɡA�h������ʼ��g�ҫ����e��

//5.1   �btStudent��ƪ��W�[�@�����
//5.1.1 �bSSMS������U�CDDL���O�X�H�ק�tStudent��ƪ�ΡA�W�[�@��DeptID���
//  alter table tStudent
//	    add DeptID varchar(2) not null default '01'
//  go
//5.1.2 �btStudent Class���W�[�@���ݩ� public string DeptID { get; set; }
//5.1.3 �����p�ק�View
//5.1.4 �������


//5.2   �bdbStudents��Ʈw���W�[��ƪ�
//5.2.1 �bSSMS������U�CDDL���O�X�H�إ�Department��ƪ�λPtStudnet�����p
//////////////////////////////////////////////////////////
//create table Department(
//    DeptID varchar(2) primary key,
//    DeptName nvarchar(30) not null
//)
//go

//insert into Department values('01','��u�t'),('02', '��ިt'),('03', '�u�ިt')
//go

//alter table tStudent
//	add foreign key(DeptID) references Department(DeptID)
//go
//////////////////////////////////////////////////////////

