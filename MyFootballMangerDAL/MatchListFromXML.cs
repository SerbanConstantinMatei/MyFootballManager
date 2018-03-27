using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MyFootballManagerObjects;

namespace MyFootballMangerDAL
{
    public class MatchListFromXML : MatchList
    {
        public string path { get; set; }

        public void LoadData()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            //TODO: Work in progress
            XmlNodeList info = xmlDoc.GetElementsByTagName("description");
            XmlNodeList infoDate = xmlDoc.GetElementsByTagName("pubDate");
            for (int i = 1; i < info.Count; i++)
            {
                Console.WriteLine("info: " + info[i].InnerText);
                Console.WriteLine("infoDate: " + infoDate[i].InnerText);
                Console.WriteLine();
            }
        }
    }
}
