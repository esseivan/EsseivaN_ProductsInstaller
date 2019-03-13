using EsseivaN.Tools;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace EsseivaN_ProductsInstaller
{
    public partial class frmMain : Form
    {
        public class Data
        {
            public string Name { get; set; }
            public string ProductName { get; set; }
            public int Index { get; set; }
            public string Url { get; set; }
            public DataType Type { get; set; }
            public string Version { get; set; }
            public bool Installed { get; set; }
            public string InstalledVersion { get; set; }
            public string Description { get; set; }
            public string Size { get; set; }
            public string Date { get; set; }
            public string InstallerUrl { get; set; }
            public string PublishUrl { get; set; }

            public Data()
            {

            }

            public Data(DataType Type)
            {
                this.Type = Type;
            }

            public Data(string Name, string Url, int Index)
            {
                this.Name = Name;
                this.Url = Url;
                this.Index = Index;
            }

            public override string ToString()
            {
                return $"Data : [Name={Name} ; Url={Url} ; Index={Index}; Type={Type.ToString()}]";
            }

            public enum DataType
            {
                None = 0,
                Unknown = 1,
                App = 10,
                Project = 20,
            }
        }
        List<Data> datas = new List<Data>();
        private int GroupAppIndex, GroupProjectIndex;
        private string Url = @"http://www.esseivan.ch/files/infos.xml";

        public frmMain()
        {
            InitializeComponent();
            InitList();
        }

        private void InitList()
        {
            listView1.FullRowSelect = true;
            listView1.CheckBoxes = true;
            listView1.ShowGroups = true;
            listView1.View = View.Details;
            listView1.Groups.Clear();
            GroupAppIndex = listView1.Groups.Add(new ListViewGroup("Apps"));
            GroupProjectIndex = listView1.Groups.Add(new ListViewGroup("Projects"));

            listView1.Columns.Clear();
            listView1.Columns.Add("Name", 120);
            listView1.Columns.Add("Description", 120);
            listView1.Columns.Add("Version", 120);
            listView1.Columns.Add("Size", 120);
            listView1.Columns.Add("Installed version", 120);
            listView1.Columns.Add("Infos", 120);
        }

        private void FillList()
        {
            if (datas == null)
            {
                return;
            }

            if (datas.Count == 0)
            {
                return;
            }

            listView1.Items.Clear();

            int groupIndex = 0;
            foreach (Data data in datas)
            {
                switch (data.Type)
                {
                    case Data.DataType.App:
                        groupIndex = GroupAppIndex;
                        break;
                    case Data.DataType.Project:
                        groupIndex = GroupProjectIndex;
                        break;
                    default:
                        break;
                }

                ListViewItem t = new ListViewItem(new string[] {
                    data.Name,
                    data.Description,
                    data.Version,
                    data.Size,
                    (data.Installed ? data.InstalledVersion : (data.Type == Data.DataType.Project ? "": "Not installed")),
                    (data.Installed && Version.Parse(data.InstalledVersion) < Version.Parse(data.Version) ? "Update available":"")},
                    listView1.Groups[groupIndex]);
                listView1.Items.Add(t);
            }
        }

        private Data generateData(XmlNodeList node, Data.DataType Type)
        {
            Data data_output = new Data(Type);
            foreach (XmlNode item in node)
            {
                switch (item.Name)
                {
                    case "index":
                        data_output.Index = int.Parse(item.InnerText);
                        break;
                    case "name":
                        data_output.Name = item.InnerText;
                        break;
                    case "url":
                        data_output.Url = item.InnerText;
                        break;
                    default:
                        break;
                }
            }

            // Get extra info if available
            if (Type == Data.DataType.App || Type == Data.DataType.Project)
            {
                // Read app's info file
                XmlElement appInfo = null;
                try
                {
                    appInfo = XmlWebReader.ReadFromWeb(data_output.Url).DocumentElement;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Infos not found for : " + data_output.Url);
                }

                if (appInfo == null)
                {
                    return data_output;
                }

                foreach (XmlNode item in appInfo)
                {
                    switch (item.Name)
                    {
                        case "productname":
                            data_output.ProductName = item.InnerText;
                            break;
                        case "version":
                            data_output.Version = item.InnerText;
                            break;
                        case "description":
                            data_output.Description = item.InnerText;
                            break;
                        case "size":
                            data_output.Size = item.InnerText;
                            break;
                        case "date":
                            data_output.Date = item.InnerText;
                            break;
                        case "installer":
                            data_output.InstallerUrl = item.InnerText;
                            break;
                        case "url":
                            data_output.PublishUrl = item.InnerText;
                            break;
                        default:
                            break;
                    }
                }
            }

            return data_output;
        }

        public void UpdateInfos(string url)
        {
            try
            {
                // read from web
                XmlDocument doc = XmlWebReader.ReadFromWeb(url);
                if (doc == null)
                {
                    Dialog.ShowDialog(new Dialog.DialogConfig()
                    {
                        Message = "Unable to read info file : \n" + url,
                        Title = "Error",
                        Button1 = Dialog.ButtonType.OK,
                        Icon = Dialog.DialogIcon.Error,
                    });
                    return;
                }

                datas.Clear();
                listView1.Items.Clear();

                // Get apps
                XmlNodeList nodes = doc.GetElementsByTagName("app");
                if (nodes.Count == 0)
                {
                    Console.WriteLine("Unable to retrieve apps");
                }
                else
                {
                    // For each app
                    foreach (XmlElement app in nodes)
                    {
                        if (app.HasChildNodes)
                        {
                            datas.Add(generateData(app.ChildNodes, Data.DataType.App));
                        }
                    }
                }

                // Get projects
                nodes = doc.GetElementsByTagName("project");
                if (nodes.Count == 0)
                {
                    Console.WriteLine("Unable to retrieve projects");
                }
                else
                {
                    foreach (XmlElement app in nodes)
                    {
                        if (app.HasChildNodes)
                        {
                            datas.Add(generateData(app.ChildNodes, Data.DataType.Project));
                        }
                    }
                }
                UpdateFromRegistry();
                FillList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); Dialog.ShowDialog(new Dialog.DialogConfig()
                {
                    Message = "Unable to process info file : \n" + ex,
                    Title = "Error",
                    Button1 = Dialog.ButtonType.OK,
                    Icon = Dialog.DialogIcon.Error,
                });
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dr = Dialog.ShowDialog(new Dialog.DialogConfig()
            {
                Message = "Enter the info xml url",
                Title = "Enter new url",
                Button1 = Dialog.ButtonType.OK,
                Button2 = Dialog.ButtonType.Cancel,
                Input = true,
                DefaultInput = Url
            });

            if (dr.DialogResult == Dialog.DialogResult.OK)
            {
                Url = dr.UserInput;
                UpdateInfos(Url);
            }
        }

        private void UpdateFromRegistry()
        {
            string Manufacturer = "EsseivaN";
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default))
            using (var key = hklm.OpenSubKey($@"Software\{Manufacturer}\"))
            {
                if (key == null)
                {
                    return;
                }

                if (key.SubKeyCount == 0)
                {
                    return;
                }

                foreach (string item in key.GetSubKeyNames())
                {
                    var t = datas.Where(x => x.ProductName == item);
                    if (t.Count() != 0)
                    {
                        t.FirstOrDefault().Installed = true;
                        var t2 = key.OpenSubKey(item).GetValue("version");
                        if (t2 != null)
                        {
                            t.FirstOrDefault().InstalledVersion = t2.ToString();
                        }
                    }
                }
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateInfos(Url);
        }

        private void installSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data selected;
            foreach (int item in listView1.CheckedIndices)
            {
                selected = datas[item];
                Console.WriteLine("Downloading and installing " + selected.Name);
                if (selected.InstallerUrl != string.Empty && selected.InstallerUrl != null)
                {
                    MiscTools.DownloadFile(selected.InstallerUrl, true);
                }
            }
        }

        private void visitPublishPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data selected;
            foreach (int item in listView1.SelectedIndices)
            {
                selected = datas[item];
                if (selected.PublishUrl != string.Empty && selected.PublishUrl != null)
                {
                    Process.Start(selected.PublishUrl);
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateInfos(Url);
        }
    }
}
