using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Security.Cryptography;
using System.Drawing;
using System.Data;
using System.ComponentModel;
using StaubliRobot;
using System.Management;




namespace LasMAN
{
    class PublicFunc
    {
        public static bool SaveTxt(string FileName, string[] txt)
        {
            try
            {
                if (FileName == null || txt == null || txt.Length < 1)
                {
                    return false;
                }
                FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                {
                    for (int i = 0; i < txt.Length; i++)
                    {

                        sw.WriteLine(txt[i]);
                    }

                }
                return true;
            }

            catch
            {
                return false;

            }

        }


        public static bool SaveTxt(string FileName, string txt)
        {
            return SaveTxt(FileName, new string[] { txt });
        }
        public static string SfD_Show(string Name)
        {


            return SfD_Show(Name, null);

        }

        public static string SfD_Show(string Name, string FileType)
        {
            System.Windows.Forms.SaveFileDialog sfd = null;
            try
            {
                sfd = new SaveFileDialog();
                sfd.InitialDirectory = Directory.GetCurrentDirectory();
                if (Name != null)
                {
                    sfd.FileName = Name;
                }
                if (FileType == null)
                {
                    sfd.Filter = "文本文件(*.txt)|*.txt";
                }
                else
                {
                    sfd.Filter = FileType;

                }
                if (DialogResult.OK != sfd.ShowDialog())
                {
                    return null;
                }
                return sfd.FileName;

            }
            catch
            {
                return null;
            }
            finally
            {

            }
        }
        public static string SfD_Show()
        {
            return SfD_Show(null);
        }




        public static string OpenDir_Show()
        {
            return OpenDir_Show(Application.StartupPath + "\\Txt");
        }
        public static string OpenDir_Show(string DirPath)
        {
            return OpenDir_Show(DirPath, "txt文件|*.txt");
        }



        public static string OpenDir_Show(string DirPath, string FileFilter)
        {
            System.Windows.Forms.OpenFileDialog ofg = null;
            try
            {
                //  string FileFilter = "txt文件|*.txt";
                ofg = new OpenFileDialog();
                if (Directory.Exists(DirPath))
                {
                    ofg.InitialDirectory = DirPath;
                }
                else
                {
                    ofg.InitialDirectory = Application.StartupPath;
                }
                ofg.Filter = FileFilter;

                //打开文件
                if (ofg.ShowDialog() != DialogResult.OK)
                {
                    return null;
                }
                else
                {
                    return ofg.FileName;
                }

            }
            catch
            {


                return null;
            }
            finally
            {


            }

        }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        static public bool ReadCs8CConfigure(string FileName)
        {
            if (FileName == null || !File.Exists(FileName) || TxtData.CS8CConfigure.EnableItem == null)
            {
                return false;
            }

            FileStream fs = null;
            StreamReader sr = null;
            string StrLine = null;
            string[] data = null;
            int LineCount = 0;
            for (int i = 0; i < TxtData.CS8CConfigure.EnableItem.Length; i++)
            {

                TxtData.CS8CConfigure.EnableItem[i] = false;
            }
            try
            {


                fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);  //使用StreamReader类来读取文件 
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                while ((StrLine = sr.ReadLine()) != null)
                {
                    LineCount++;
                    StrLine = StrLine.Trim().ToUpper();
                    if (StrLine == "")
                    {
                        continue;

                    }


                    if (StrLine.IndexOf("TOOL=") >= 0)
                    {
                        data = StrLine.Substring(5, StrLine.Length - 5).Split(',');
                        if (data == null || data.Length != 6)
                        {
                            return false;
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            TxtData.CS8CConfigure.Tool[i] = double.Parse(data[i]);

                        }
                    }


                    if (StrLine.IndexOf("HOME=") == 0)
                    {
                        data = StrLine.Substring(5, StrLine.Length - 5).Split(',');
                        if (data == null || data.Length != 6)
                        {
                            return false;
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            TxtData.CS8CConfigure.Home[i] = double.Parse(data[i]);

                        }
                    }


                    if (StrLine.IndexOf("CORNERDATA=") >= 0)
                    {
                        data = StrLine.Substring(11, StrLine.Length - 11).Split(',');
                        if (data == null || data.Length != 6)
                        {
                            return false;
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            TxtData.CS8CConfigure.Cornerdata[i] = double.Parse(data[i]);

                        }
                    }


                    if (StrLine.IndexOf("EXTAXIS=") == 0)
                    {
                        data = StrLine.Substring(8, StrLine.Length - 8).Split(',');
                        if (data == null || data.Length != 6)
                        {
                            return false;
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            TxtData.CS8CConfigure.Axis[i] = double.Parse(data[i]);

                        }

                    }

                    if (StrLine.IndexOf("PRESETDATA=") == 0)
                    {
                        data = StrLine.Substring(11, StrLine.Length - 11).Split(',');
                        if (data == null || data.Length != 6)
                        {
                            return false;
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            TxtData.CS8CConfigure.PresetData[i] = double.Parse(data[i]);

                        }

                    }
                    if (StrLine.IndexOf("IODELAY=") == 0)
                    {
                        data = StrLine.Substring(8, StrLine.Length - 8).Split(',');
                        if (data == null || data.Length != 6)
                        {
                            return false;
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            TxtData.CS8CConfigure.IODelay[i] = double.Parse(data[i]);

                        }

                    }


                    if (StrLine.IndexOf("STEPLENGTH=") >= 0)
                    {
                        string Buff = StrLine.Substring("STEPLENGTH=".Length, StrLine.Length - "STEPLENGTH=".Length);

                        TxtData.CS8CConfigure.StepLength = double.Parse(Buff);


                    }

                    if (StrLine.IndexOf("HOMESPEED=") >= 0)
                    {
                        string Buff = StrLine.Substring("HOMESPEED=".Length, StrLine.Length - "HOMESPEED=".Length);

                        TxtData.CS8CConfigure.HomeSpeed = double.Parse(Buff);


                    }

                    if (StrLine.IndexOf("BOXCARENABLE=") >= 0)
                    {
                        TxtData.CS8CConfigure.EnableItem[0] = (StrLine == "BOXCARENABLE=TRUE");


                    }
                    if (StrLine.IndexOf("WELDENABLE=") == 0)
                    {
                        TxtData.CS8CConfigure.EnableItem[1] = (StrLine == "WELDENABLE=TRUE");


                    }
                    if (StrLine.IndexOf("MOVEBACKENABLE=") == 0)
                    {
                        TxtData.CS8CConfigure.EnableItem[2] = (StrLine == "MOVEBACKENABLE=TRUE");


                    }
                    if (StrLine.IndexOf("TEACHTOOLCALENABLE=") >= 0)
                    {
                        TxtData.CS8CConfigure.EnableItem[3] = (StrLine == "TEACHTOOLCALENABLE=TRUE");

                    }
                    if (StrLine.IndexOf("BIGFILEMODE=") == 0)
                    {
                        TxtData.CS8CConfigure.EnableItem[4] = (StrLine == "BIGFILEMODE=TRUE");


                    }

                    if (StrLine.IndexOf("7AXISENABLE=") == 0)
                    {
                        TxtData.CS8CConfigure.EnableItem[5] = (StrLine == "7AXISENABLE=TRUE");


                    }

                    if (StrLine.IndexOf("STEPMOVEENABLE=") >= 0)
                    {
                        TxtData.CS8CConfigure.EnableItem[6] = (StrLine == "STEPMOVEENABLE=TRUE");


                    }




                }




                return true;
            }
            catch
            {

                // MessageBox.Show(EX.Message);
                return false;

            }

            finally
            {

                if (sr != null)
                {
                    sr.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }

            }


        }


        //static public bool ReadCs8CLog(out string[] Date, out string[] Txt)
        //{
        //    return ReadCs8CLog(out Date, out Txt, Application.StartupPath + "\\Txt\\errors.log");
        //}

        //static public bool ReadCs8CLog(out string[] Date, out string[] Txt, string FileName)
        //{
        //    Date = null;
        //    Txt = null;
        //    if (FileName == null || !File.Exists(FileName))
        //    {
        //        return false;
        //    }

        //    FileStream fs = null;
        //    StreamReader sr = null;
        //    string StrLine = null;
        //    string[] data = null;
        //    int LineCount = 0;
        //    Txt = new string[10000];
        //    Date = new string[10000];
        //    int j = 0;
        //    try
        //    {

        //        fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
        //        sr = new StreamReader(fs);  //使用StreamReader类来读取文件 
        //        sr.BaseStream.Seek(0, SeekOrigin.Begin);
        //        while ((StrLine = sr.ReadLine()) != null)
        //        {
        //            LineCount++;
        //            StrLine = StrLine.Trim();
        //            if (StrLine == "")
        //            {
        //                continue;

        //            }
        //            data = StrLine.Split(new char[] { '[', ']' });
        //            if (data != null && data.Length >= 3 && j < 10000)
        //            {
        //                Date[j] = data[1];
        //                Txt[j] = data[2];
        //                j++;

        //            }

        //        }
        //        if (j > 0)
        //        {
        //            Array.Resize(ref Txt, j);
        //            Array.Resize(ref Date, j);
        //        }




        //        return true;
        //    }
        //    catch
        //    {


        //        return false;

        //    }

        //    finally
        //    {

        //        if (sr != null)
        //        {
        //            sr.Close();
        //        }
        //        if (fs != null)
        //        {
        //            fs.Close();
        //        }

        //    }


        //}



        static public bool ReadCs8CConfigure()
        {

            return ReadCs8CConfigure(Application.StartupPath + "\\Txt\\Configure.txt");



        }



        /// <summary>
        /// 下位机配置文件
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        static public bool ReadXMLConfigure()
        {


            if (!Directory.Exists(Application.StartupPath + "\\Txt"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Txt");
            }

            if (!File.Exists("C:\\WINDOWS\\cfg.txt"))
            {
                File.Create("C:\\WINDOWS\\cfg.txt");
            }

            TxtData.XMLConfigure.SoftWareUsedDay = (DateTime.Now - File.GetCreationTime("C:\\WINDOWS\\cfg.txt")).Days;
            //四天备份一次
            if (TxtData.XMLConfigure.SoftWareUsedDay % 4 == 0)
            {
                if (File.Exists(Application.StartupPath + "Txt\\LasMAN.mdb") && File.GetLastAccessTime(Application.StartupPath + "Txt\\LasMAN.mdb").Date == DateTime.Now.Date)
                {
                }
                else
                {
                    File.Copy(Application.StartupPath + "\\LasMAN.mdb", Application.StartupPath + "\\Txt\\LasMAN.mdb", true);


                }



            }

            try
            {


                int Index = Array.IndexOf(TxtData.XMLConfigure.ResCodes, TxtData.XMLConfigure.RestrictCode.ToUpper());
                int Days = 0;
                if (Index < 0)
                {
                    Days = 30;
                }
                else
                {
                    Days = TxtData.XMLConfigure.Days[Index];
                }
                TxtData.XMLConfigure.CanUsedDay = Days;
                TxtData.XMLConfigure.OverTime = TxtData.XMLConfigure.SoftWareUsedDay > Days;
                TxtData.XMLConfigure.Reged = CompareCode(TxtData.XMLConfigure.RegCode);



                return true;

            }
            catch
            {
                return false;
            }



        }

        //static public bool ReadXMLConfigure()
        //{
        //    return ReadXMLConfigure(Application.StartupPath + "\\Configure.xml");
        //}

        static public bool ReadCs8CLog(out string[] Date, out string[] Txt)
        {




            return ReadCs8CLog(out Date, out Txt, Application.StartupPath + "\\Txt\\errors.log");
        }

        static public bool ReadCs8CLog(out string[] Date, out string[] Txt, string FileName)
        {
            Date = null;
            Txt = null;
            if (FileName == null || !File.Exists(FileName))
            {
                return false;
            }

            FileStream fs = null;
            StreamReader sr = null;
            string StrLine = null;
            string[] data = null;
            int LineCount = 0;
            Txt = new string[10000];
            Date = new string[10000];
            int j = 0;
            try
            {

                fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);  //使用StreamReader类来读取文件 
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                while ((StrLine = sr.ReadLine()) != null)
                {
                    LineCount++;
                    StrLine = StrLine.Trim();
                    if (StrLine == "")
                    {
                        continue;

                    }
                    data = StrLine.Split(new char[] { '[', ']' });
                    if (data != null && data.Length >= 3 && j < 10000)
                    {
                        Date[j] = data[1];
                        Txt[j] = data[2];
                        j++;

                    }

                }
                if (j > 0)
                {
                    Array.Resize(ref Txt, j);
                    Array.Resize(ref Date, j);
                }




                return true;
            }
            catch
            {


                return false;

            }

            finally
            {

                if (sr != null)
                {
                    sr.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }

            }


        }



        /// <summary>
        /// 读取应用程序
        /// </summary>
        /// <param name="data"></param>
        static public void ReadApplication(byte[] data)
        {

            if (data == null)
            {
                TxtData.DataBase.InterfaceType = -1;


                return;
            }
            MemoryStream sm = null;
            StreamReader rd = null;
            XmlDocument xd = null;
            try
            {
                sm = new MemoryStream(data);
                sm.Position = 0;
                rd = new StreamReader(sm);
                xd = new XmlDocument();
                xd.LoadXml(rd.ReadToEnd());
                TxtData.DataBase.nProcedure = StaubliXML.GetXMLInt("nProcedure", xd);
                TxtData.DataBase.bCycle = StaubliXML.GetXMLBool("bCycle", xd);
                TxtData.DataBase.bPcStartCycle = StaubliXML.GetXMLBool("bPcStartCycle", xd);
                TxtData.DataBase.bPcStopCycle = StaubliXML.GetXMLBool("bPcStopCycle", xd);

                TxtData.DataBase.ProductCount = StaubliXML.GetXMLInt("nCycleCount", xd);
                TxtData.DataBase.CycleTime = StaubliXML.GetXMLDouble("nCycleTime", xd);


                //TxtData.DataBase.Upload = StaubliXML.GetXMLBool("bUpload", xd);
                //TxtData.DataBase.IsHome = StaubliXML.GetXMLBool("bIsHome", xd);
                //TxtData.DataBase.PowerOn = StaubliXML.GetXMLBool("bPowerOn", xd);
                //TxtData.DataBase.InterfaceType = StaubliXML.GetXMLInt("nInterfaceType", xd);
                //TxtData.DataBase.ToolMode = StaubliXML.GetXMLInt("nToolMode", xd);
                //TxtData.DataBase.CurrentJoint = StaubliXML.GetXMLJoint("jCurrentJoint", xd);
                //TxtData.DataBase.CurrentPoint = StaubliXML.GetXMLCarten("pCurrentPoint", xd);
                //TxtData.DataBase.CycleIndex = (int)StaubliXML.GetXMLDouble("nCycleIndex", xd);
                //TxtData.DataBase.CycleCount = (int)StaubliXML.GetXMLDouble("nCycleCount", xd);
                //TxtData.DataBase.RobotSpeed = StaubliXML.GetXMLDouble("nRobotSpeed", xd);
                //TxtData.DataBase.WorkPlaceCount = StaubliXML.GetXMLInt("nWorkPlaceCount", xd);
                //TxtData.DataBase.WorkPlaceIndex = StaubliXML.GetXMLInt("nWorkPlaceIndex", xd);
                //TxtData.DataBase.PresetData = StaubliXML.GetXMLIntArray("nPresetData", xd);
                //TxtData.DataBase.CycleTime = StaubliXML.GetXMLDouble("nCycleTime", xd);
                //TxtData.DataBase.PointType = (int)StaubliXML.GetXMLDouble("nPointType", xd);
                //TxtData.DataBase.TrajIndex = (int)StaubliXML.GetXMLDouble("nTrajIndex", xd);


                //TxtData.DataBase.Custom = StaubliXML.GetXMLString("sCustom",xd);
                //TxtData.DataBase.WorkPlaceProductCount = StaubliXML.GetXMLIntArray("nWpProduct", xd);
                //TxtData.DataBase.ProductName = StaubliXML.GetXMLStringArray("sProductName", xd);
                //TxtData.DataBase.AirOn = StaubliXML.GetXMLBool("bAirOn", xd);
                //TxtData.DataBase.FollowOn = StaubliXML.GetXMLBool("bFollowOn", xd);
                //TxtData.DataBase.LaserOn = StaubliXML.GetXMLBool("bLaserOn", xd);
            }
            catch
            {
                return;
            }
            finally
            {
                if (sm != null)
                {
                    sm.Close();
                }
                if (rd != null)
                {
                    rd.Close();
                }

            }


        }



        static public void ReadApplicationSlave(byte[] data)
        {

            if (data == null)
            {
                TxtData.DataBase.InterfaceType = -1;


                return;
            }
            MemoryStream sm = null;
            StreamReader rd = null;
            XmlDocument xd = null;
            try
            {
                sm = new MemoryStream(data);
                sm.Position = 0;
                rd = new StreamReader(sm);
                xd = new XmlDocument();
                xd.LoadXml(rd.ReadToEnd());
                TxtData.DataBaseSlave.nProcedure = StaubliXML.GetXMLInt("nProcedure", xd);
                TxtData.DataBaseSlave.bCycle = StaubliXML.GetXMLBool("bCycle", xd);
                TxtData.DataBaseSlave.bPcStartCycle = StaubliXML.GetXMLBool("bPcStartCycle", xd);
                TxtData.DataBaseSlave.bPcStopCycle = StaubliXML.GetXMLBool("bPcStopCycle", xd);
                
                //TxtData.DataBase.Upload = StaubliXML.GetXMLBool("bUpload", xd);
                //TxtData.DataBase.IsHome = StaubliXML.GetXMLBool("bIsHome", xd);
                //TxtData.DataBase.PowerOn = StaubliXML.GetXMLBool("bPowerOn", xd);
                //TxtData.DataBase.InterfaceType = StaubliXML.GetXMLInt("nInterfaceType", xd);
                //TxtData.DataBase.ToolMode = StaubliXML.GetXMLInt("nToolMode", xd);
                //TxtData.DataBase.CurrentJoint = StaubliXML.GetXMLJoint("jCurrentJoint", xd);
                //TxtData.DataBase.CurrentPoint = StaubliXML.GetXMLCarten("pCurrentPoint", xd);
                //TxtData.DataBase.CycleIndex = (int)StaubliXML.GetXMLDouble("nCycleIndex", xd);
                //TxtData.DataBase.CycleCount = (int)StaubliXML.GetXMLDouble("nCycleCount", xd);
                //TxtData.DataBase.RobotSpeed = StaubliXML.GetXMLDouble("nRobotSpeed", xd);
                //TxtData.DataBase.WorkPlaceCount = StaubliXML.GetXMLInt("nWorkPlaceCount", xd);
                //TxtData.DataBase.WorkPlaceIndex = StaubliXML.GetXMLInt("nWorkPlaceIndex", xd);
                //TxtData.DataBase.PresetData = StaubliXML.GetXMLIntArray("nPresetData", xd);
                //TxtData.DataBase.CycleTime = StaubliXML.GetXMLDouble("nCycleTime", xd);
                //TxtData.DataBase.PointType = (int)StaubliXML.GetXMLDouble("nPointType", xd);
                //TxtData.DataBase.TrajIndex = (int)StaubliXML.GetXMLDouble("nTrajIndex", xd);


                //TxtData.DataBase.Custom = StaubliXML.GetXMLString("sCustom",xd);
                //TxtData.DataBase.WorkPlaceProductCount = StaubliXML.GetXMLIntArray("nWpProduct", xd);
                //TxtData.DataBase.ProductName = StaubliXML.GetXMLStringArray("sProductName", xd);
                //TxtData.DataBase.AirOn = StaubliXML.GetXMLBool("bAirOn", xd);
                //TxtData.DataBase.FollowOn = StaubliXML.GetXMLBool("bFollowOn", xd);
                //TxtData.DataBase.LaserOn = StaubliXML.GetXMLBool("bLaserOn", xd);
            }
            catch
            {
                return;
            }
            finally
            {
                if (sm != null)
                {
                    sm.Close();
                }
                if (rd != null)
                {
                    rd.Close();
                }

            }


        }
        /// <summary>
        /// Soap轮询
        /// </summary>
        /// <returns></returns>
        static public void Poll()
        {

            //对于变量的轮询
            StaubliRobot.SoapInstance.SoapRead = new StaubliRobot.SoapClient(TxtData.XMLConfigure.IpAddress);
            StaubliRobot.SoapInstance.SoapWrite = new StaubliRobot.SoapClient(TxtData.XMLConfigure.SlaveIpAddress);
            StaubliRobot.SoapInstance.SoapRead.SoapGetAppname = @"Disk://cycleStatus/cycleStatus.pjx";
            StaubliRobot.SoapInstance.SoapRead.SoapSetAppname = @"Disk://cycleStatus/cycleStatus.pjx";

            StaubliRobot.SoapInstance.SoapWrite.SoapGetAppname= @"Disk://cycleStatus/cycleStatus.pjx";
            StaubliRobot.SoapInstance.SoapWrite.SoapSetAppname = @"Disk://cycleStatus/cycleStatus.pjx";
            //TxtData.DataBase.SoapStaus = StaubliRobot.SoapInstance.SoapRead.Login();
            double PollIndex = 0;
            PollIndex = 0;

            TxtData.DataBase.SoapStaus = StaubliRobot.SoapInstance.SoapRead.Login() && StaubliRobot.SoapInstance.SoapWrite.Login();

            if (!TxtData.DataBase.SoapStaus)
            {
                return;
            }


            while (!TxtData.DataBase.SoapAbort)
            {
                PollIndex++;
                if (TxtData.DataBase.SoapStaus)
                {


                    ReadApplication(StaubliRobot.SoapInstance.SoapRead.GetAppdata());
                    ReadApplicationSlave(StaubliRobot.SoapInstance.SoapWrite.GetAppdata());
                    TxtData.DataBase.CurrentJoint = StaubliRobot.SoapInstance.SoapRead.GetJointPos();
                    TxtData.DataBase.CurrentPoint = StaubliRobot.SoapInstance.SoapRead.GetJointCartPos();

                    TxtData.DataBaseSlave.CurrentJoint = StaubliRobot.SoapInstance.SoapWrite.GetJointPos();
                    TxtData.DataBaseSlave.CurrentPoint = StaubliRobot.SoapInstance.SoapWrite.GetJointCartPos();


                    //    ReadProductCount();
                    if (PollIndex % 20 == 0)
                    {
                        TxtData.DataBase.ControllerTemp = SoapInstance.SoapRead.ReadIOValue("CBT_TEMP");
                        TxtData.DataBaseSlave.ControllerTemp = SoapInstance.SoapWrite.ReadIOValue("CBT_TEMP");
                    }
                }
                //else
                //{
                //    PollIndex = 0;
                //    if (StaubliRobot.SoapInstance.SoapRead.Ping())
                //    {
                //        TxtData.DataBase.SoapStaus = StaubliRobot.SoapInstance.SoapRead.Login();

                //    }
                //    else
                //    {
                //        TxtData.DataBase.SoapStaus = false;
                //    }

                //}





                System.Threading.Thread.Sleep(100);
            }





        }
        //static   public void ReadProductCount()
        //   {


        //    if (TxtData.DataBase.ProductName!=null&&TxtData.DataBase.InterfaceType==9&&TxtData.DataBase.WorkPlaceProductCount!=null)
        //    {
        //        int len = 0;
        //        for (int i = 0; i < TxtData.DataBase.WorkPlaceProductCount.Length;i++ )
        //        {
        //            len = len + TxtData.DataBase.WorkPlaceProductCount[i];

        //        }
        //        if (len==0)
        //        {
        //            return;
        //        }
        //        try
        //        {

        //        DataBaseManage db = new DataBaseManage();
        //        for (int i = 1; i <= 4;i++)
        //        {
        //          if (TxtData.DataBase.ProductName.Length>=i&&TxtData.DataBase.WorkPlaceProductCount.Length>i&&TxtData.DataBase.WorkPlaceProductCount[i]>0)
        //          {
        //              db.AddProductCount(i,TxtData.DataBase.Custom, TxtData.DataBase.ProductName[i-1], TxtData.DataBase.WorkPlaceProductCount[i]);
        //              SoapInstance.SoapRead.SetAppdata("nWpProduct["+i.ToString()+"]", 0);

        //          }

        //        }

        //        }
        //        catch (System.Exception ex)
        //        {

        //        }


        //    }





        //   }
        public static string GetCpuSerialNumber()
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return strCpu;
        }
        /// <summary>
        /// 获得硬盘ID
        /// </summary>
        /// <returns></returns>
        public static string GetDiskVolumeSerialNumber()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"d:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }
        public static bool CompareCode(string regcode)
        {
            if (regcode == null || regcode == "")
            {
                return false;
            }
            try
            {
                string toolcode = GetDiskVolumeSerialNumber() + GetCpuSerialNumber();
                string pubkey = "<RSAKeyValue><Modulus>xe3teTUwLgmbiwFJwWEQnshhKxgcasglGsfNVFTk0hdqKc9i7wb+gG7HOdPZLh65QyBcFfzdlrawwVkiPEL5kNTX1q3JW5J49mTVZqWd3w49reaLd8StHRYJdyGAL4ZovBhSTThETi+zYvgQ5SvCGkM6/xXOz+lkMaEgeFcjQQs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
                string prikey = "<RSAKeyValue><Modulus>xe3teTUwLgmbiwFJwWEQnshhKxgcasglGsfNVFTk0hdqKc9i7wb+gG7HOdPZLh65QyBcFfzdlrawwVkiPEL5kNTX1q3JW5J49mTVZqWd3w49reaLd8StHRYJdyGAL4ZovBhSTThETi+zYvgQ5SvCGkM6/xXOz+lkMaEgeFcjQQs=</Modulus><Exponent>AQAB</Exponent><P>5flMAd7IrUTx92yomBdJBPDzp1Kclpaw4uXB1Ht+YXqwLW/9icI6mcv7d2O0kuVLSWj8DPZJol9V8AtvHkC3oQ==</P><Q>3FRA9UWcFrVPvGR5bewcL7YqkCMZlybV/t6nCH+gyMfbEvgk+p04F+j8WiHDykWj+BahjScjwyF5SGADbrfJKw==</Q><DP>b4WOU1XbERNfF3JM67xW/5ttPNX185zN2Ko8bbMZXWImr1IgrD5RNqXRo1rphVbGRKoxmIOSv7flr8uLrisKIQ==</DP><DQ>otSZlSq2qomgvgg7PaOLSS+F0TQ/i1emO0/tffhkqT4ah7BgE97xP6puJWZivjAteAGxrxHH+kPY0EY1AzRMNQ==</DQ><InverseQ>Sxyz0fEf5m7GrzAngLDRP/i+QDikJFfM6qPyr3Ub6Y5RRsFbeOWY1tX3jmV31zv4cgJ6donH7W2dSBPi67sSsw==</InverseQ><D>nVqofsIgSZltxTcC8fA/DFz1kxMaFHKFvSK3RKIxQC1JQ3ASkUEYN/baAElB0f6u/oTNcNWVPOqE31IDe7ErQelVc4D26RgFd5V7dSsF3nVz00s4mq1qUBnCBLPIrdb0rcQZ8FUQTsd96qW8Foave4tm8vspbM65iVUBBVdSYYE=</D></RSAKeyValue>";

                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {

                    rsa.FromXmlString(pubkey);

                    RSAPKCS1SignatureDeformatter f = new RSAPKCS1SignatureDeformatter(rsa);


                    f.SetHashAlgorithm("SHA1");

                    SHA1Managed sha = new SHA1Managed();

                    byte[] name = sha.ComputeHash(ASCIIEncoding.ASCII.GetBytes(toolcode));
                    byte[] key = Convert.FromBase64String(regcode);

                    return f.VerifySignature(name, key);
                }
            }
            catch
            {
                return false;
            }



        }












    }
}
