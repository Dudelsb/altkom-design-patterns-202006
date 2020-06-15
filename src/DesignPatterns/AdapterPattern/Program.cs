﻿using CrystalDecisions.CrystalReports;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Adapter Pattern!");

            MotorolaRadioTest();

            RadioAdapterTest.Test();

            // HyteriaRadioTest();

            CrystalReportTest();

            //Report report = new Report("raport1.rtp");
            //report.Generate("output.pdf");
        }


        // Cwiczenie nr 1
        // Utworz adapter, z ktorym bedzie mozna pracowac w nastepujacy sposob:
        private static void AdapterCrystalReportTest()
        {
            //Report report = new Report("raport1.rtp");
            //report.Generate("output.pdf");
        }

        private static void CrystalReportTest()
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load("report1.rpt");

            ConnectionInfo connectInfo = new ConnectionInfo()
            {
                ServerName = "MyServer",
                DatabaseName = "MyDb",
                UserID = "myuser",
                Password = "mypassword"
            };

            foreach (Table table in rpt.Database.Tables)
            {
                table.LogOnInfo.ConnectionInfo = connectInfo;
                table.ApplyLogOnInfo(table.LogOnInfo);
            }

            rpt.ExportToDisk(ReportDocument.ExportFormatType.PortableDocFormat, "report1.pdf");
        }

        private static void MotorolaRadioTest()
        {
            MotorolaRadio radio = new MotorolaRadio();
            radio.PowerOn();
            radio.SelectChannel(10);
            radio.Send("Hello World!");
            radio.PowerOff();
        }

        private static void HyteraRadioTest()
        {
            HyteraRadio radio = new HyteraRadio();
            radio.Init();
            radio.SendMessage(10, "Hello World!");
            radio.Release();
        }
    }

    


}
