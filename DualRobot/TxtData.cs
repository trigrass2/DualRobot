using System;
using System.Collections.Generic;
using System.Text;

namespace LasMAN
{
    class TxtData
    {

        /// <summary>
        /// 下位机配置文件
        /// </summary>
        public struct CS8CConfigure
        {

            //public static bool BigFileMode = false;
            //public static bool TeachToolCaiEnable = false;
            //public static bool MoveBackEnable = false;
            //public static bool BoxCarEnable = false;
            //public static bool Axis7Enable = false;
            //public static bool StepMoveEnable = false;
            //public static bool WeldEnable = false;

            public static bool [] EnableItem=new bool [7];
            public static double HomeSpeed = 0;

            public static double StepLength=0;





            public static double[] Home=new double[6];
            public static double[] Tool=new double[6];
            public static double[] Cornerdata=new double[6];
            public static double[] Axis=new double[6];
            public static double[] PresetData=new double[6];
            public static double[] IODelay=new double[6];
            public static double[] BoxCar=new double[6];

         

           

        }

        /// <summary>
        /// 产品文件
        /// </summary>
        public struct Recipe
        {
            public static string[] TrajTypeName;

            public static string RecipeName;

            public static int TotalTraj;

            public static string[] TrajName;
            public static int[] TrajType;

            public static bool[] TrajByPass;
            public static int[,] TrajPointCount;
            public static bool[][] bAppro;
            public static bool[][] bMoveC;
            public static bool[][] bLeave;

            public static double[][,] pAppro;
            public static double[][,] pCut;
            public static double[][,] pMoveC;
            public static double[][,] pLeave;

            public static double[][,] mAppro;
            public static double[][,] mLeave;

            public static double[][,] mCut;


            public static double[] RecipeFrame;

            public static double[] RecipeOffset;

            public static double[,] TrajFrame;

            public static double[,] TrajOffset;

            public static double[,] Array;
            public static double[,] DownLead;
            public static double[,] WorkPlace;

            public static double[,] Delay;


        }

        /// <summary>
        /// 上下位机相互交换
        /// </summary>
        public struct DataBase
        {
            public static int nProcedure;
            public static bool bCycle;
            public static bool bPcStartCycle;
            public static bool bPcStopCycle;


            public static string ControllerTemp;
            public static bool SoapStaus;
            public static bool SoapAbort;
            public static int PointType;

            public static double Version;

            //*******************************************
            public static int InterfaceType = -1;

            public static double RobotSpeed;

            public static int ToolMode = -1;
            public static bool IsHome = false;
            public static bool Upload;

            public static bool AirOn;

            public static bool FollowOn;
            public static bool LaserOn;
            public static bool PowerOn;

            public static int ProductCount;

            public static int WorkPlaceCount;

            public static int WorkPlaceIndex;

            public static int[] WorkPlaceProductCount;

            public static int CycleIndex;

            public static int CycleCount;

            public static double CycleTime;

            public static string[] ProductName;

            public static double ID;
            public static int TrajIndex;

            public static double[] CurrentJoint;
            public static double[] CurrentPoint;

            public static double[] Home;
            public static double[] Tool;

            public static string ValVersion = "";
            public static string RobotType = "";

            public static int[] PresetData = new int[5];
            public static string Custom;


        }




        public struct DataBaseSlave
        {
            public static int nProcedure;
            public static bool bCycle;
            public static bool bPcStartCycle;
            public static bool bPcStopCycle;

            public static string ControllerTemp;
            public static bool SoapStaus;
            public static bool SoapAbort;
            public static int PointType;

            public static double Version;
            public static string ValVersion = "";
            public static string RobotType = "";
            //public static int InterfaceType = -1;

            //public static double RobotSpeed;

            //public static int ToolMode = -1;
            //public static bool IsHome = false;
            //public static bool Upload;

            //public static bool AirOn;

            //public static bool FollowOn;
            //public static bool LaserOn;
            //public static bool PowerOn;

            //public static int ProductCount;

            //public static int WorkPlaceCount;

            //public static int WorkPlaceIndex;

            //public static int[] WorkPlaceProductCount;

            //public static int CycleIndex;

            //public static int CycleCount;

            //public static double CycleTime;

            //public static string[] ProductName;

            //public static double ID;
            //public static int TrajIndex;
            //public static int PointType;

            //public static double Version;

            public static double[] CurrentJoint;
            public static double[] CurrentPoint;

            //public static double[] Home;
            //public static double[] Tool;

            //public static string ValVersion = "";
            //public static string RobotType = "";

            //public static int[] PresetData = new int[5];
            //public static string Custom;


        }
        /// <summary>
        /// 配置文件
        /// </summary>
        public struct XMLConfigure
        {
            public static string IpAddress = "192.168.0.254";
            public static string SlaveIpAddress = "192.168.0.253";
           // public static string Port;
            public static string ToolCode;

            public static string RegCode;

            public static bool AutoLogin=false;

            public static string RestrictCode;
            public static int SoftWareUsedDay;
            public static int CanUsedDay;
            public static bool Reged = false;
            public static bool OverTime = false;

            public static string[] ResCodes = new string[] { "01LASMAN".ToUpper(), "02val3pg".ToUpper(), "03soappg".ToUpper(), "06france".ToUpper(), "09pzhong".ToUpper(),
            "12staubl".ToUpper(), "18develp".ToUpper(), "24roboti".ToUpper(), "36weiken".ToUpper() ,"00yyeprg".ToUpper()};
            public static int[] Days = new int[] { 30, 60, 90, 180, 270, 360, 540, 720, 1080, int.MaxValue };
            public static int PopeDom = 0;
            public static bool Login = false;
            public static string User = "";
            public static string Password = "";

        }
        



        public struct PublicData
        {
            //不同的工位对应不同的产品
            public static string[][]RecipeName;
            public static string[] TriggleModeText = new string[] { "按钮触发单工位", "按钮触发单周期", "按钮触发多周期", "无需按钮触发","按钮触发排队","用户自定义" };
            public static int TriggleMode = 0;
            public static int CycleCount = 1;
            public static int WorkPlaceCount = 1;
            //数据库中保存的工艺名称
            public static string[] PresetName;


            //2013.10.30  需要对这个进行修改
            //public static string[] ProductName=new string[4];
            //public static bool[][] TrajByPass=new bool[4][];
            //public static string[] MatchPresetName = new string[4] { "StaubliPreset", "StaubliPreset", "StaubliPreset", "StaubliPreset"};

            public static string[][] ProductName = new string[10][];
            public static bool[][][] TrajByPass = new bool[10][][];
            public static string[][] MatchPresetName = new string[10][];
            //每个工位的个数
            public static int[] ProductCount=new int[]{1,1,1,1,1,1,1,1,1,1};



            //
            public static int ErrorCode = 0;
            public static int ErrorLine = 0;
            public static bool[,] ScreenEnable=new bool[6,20];
            public static string[] Customs;
            public static string[] Cs8cScreen = new string[] { "", "手动回零", "手动对齐", "编辑工艺", "编辑动作", "编辑产品", "远程生产", "选项配置", "退出程序", "空闲等待", 
                "示教坐标系", "示教偏差", "外部轴", "生产界面", "示教工具", "示教安全点", "", "", "", "", "", "", "", "", "", "", "" };




        }





        public struct RobotGroup
        {


            public static string[] IpAddress = new string[] { "192.168.0.254", "192.168.0.254", "192.168.0.254", "192.168.0.254", "192.168.0.254", 
            "192.168.0.254","192.168.0.254","192.168.0.254","192.168.0.254","192.168.0.254"};
            public static string[] Remark = new string[] { "激光切割机器人", "激光切割机器人", "激光切割机器人", "激光切割机器人", "激光切割机器人", 
            "激光切割机器人","激光切割机器人","激光切割机器人","激光切割机器人","激光切割机器人"};
          
            public static string[] Status = new string[] { "请小心，运行中", "请小心，运行中", "请小心，运行中", "请小心，运行中", "请小心，运行中",
            "请小心，运行中","请小心，运行中","请小心，运行中","请小心，运行中","请小心，运行中",};
            public static string[] Type = new string[] { "倒挂RX160L", "倒挂RX160L", "倒挂RX160L", "倒挂RX160L", "倒挂RX160L", 
            "倒挂RX160L","倒挂RX160L","倒挂RX160L","倒挂RX160L","倒挂RX160L"};



        }

    }
}
