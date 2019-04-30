using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Collections.Specialized;

namespace DeviceManager
{
    public partial class Form1 : Form
    {
        public class DeviceFolder
        {
            DirectoryInfo directoryInfo;

            public DeviceFolder(DirectoryInfo info)
            {
                directoryInfo = info;
            }

            private string getSimplifiedName(string name)
            {
                var parts = name.Split(new char[] { '_' });
                return parts[0];
            }

            public string getPath()
            {
                return directoryInfo.FullName;
            }

            public string getSimplifiedPath()
            {
                return Path.Combine(directoryInfo.Parent.FullName, getSimplifiedName(directoryInfo.Name));
            }

            public override string ToString()
            {
                return getSimplifiedName(directoryInfo.Name);
            }
        }

        NameValueCollection appSettings = ConfigurationManager.AppSettings;
        public Form1()
        {
            InitializeComponent();
            
            fillList(computerList, appSettings["ComputerFolder"]);
            //fillList(deviceList, appSettings["DeviceFolder"]);
            fillList(deviceList, GetDeviceFolder());
        }

        private string GetDeviceFolder()
        {
            DriveInfo[] infos = DriveInfo.GetDrives();
            foreach (var info in infos)
            {
                if (!info.IsReady)
                    continue;

                if (info.VolumeLabel.ToUpper() != "WHARFEDALE")
                    continue;

                return info.RootDirectory.FullName;
            }

            return null;
        }

        private void fillList(ListBox list, string folder)
        {
            if (!Directory.Exists(folder))
            {
                MessageBox.Show("Folder does not exist: " + folder);
                return;
            }

            DirectoryInfo info = new DirectoryInfo(folder);
            DirectoryInfo[] directories = info.GetDirectories().OrderBy(p => p.Name).ToArray();
            list.Items.Clear();
            foreach (DirectoryInfo directory in directories)
            {
                if (!directory.Name.StartsWith("."))
                    list.Items.Add(new DeviceFolder(directory)); 
            }
        }

        private void copyFile(string filePath, string folderPath)
        {
            File.Copy(filePath, folderPath, true);
        }

        private string getSimplifiedName(string name)
        {
            var parts1 = name.Split(new char[] { '_' });
            var parts2 = parts1[parts1.Length - 1].Split(new string[] { " - " }, StringSplitOptions.None);
            return parts1[0] + " - " + parts2[1];
        }

        private void copyFiles(string fromFolder, string toFolder)
        {
            DirectoryInfo info = new DirectoryInfo(fromFolder);
            FileInfo[] files = info.GetFiles().OrderBy(p => p.Name).ToArray();
            copyProgress.Maximum = files.Count<FileInfo>();
            copyProgress.Value = 0;
            Directory.CreateDirectory(toFolder);
            foreach (FileInfo file in files)
            {
                copyFile(file.FullName, Path.Combine(toFolder, getSimplifiedName(file.Name)));

                copyProgress.Value++;
            }
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            if (computerList.SelectedItem == null)
            {
                MessageBox.Show("Select an Available Book you want to copy to the Device");
                return;
            }

            var selectedFolder = computerList.SelectedItem;
            addButton.Enabled = false;
            var fromPath = (computerList.SelectedItem as DeviceFolder).getPath();
            var toPath = Path.Combine(appSettings["DeviceFolder"], (computerList.SelectedItem as DeviceFolder).ToString());
            await Task.Run(() => { copyFiles(fromPath, toPath); });
            addButton.Enabled = true;

            fillList(deviceList, appSettings["DeviceFolder"]);
        }

        private void deleteFile(string filePath)
        {
            Directory.Delete(filePath, true);
        }


        private async void removeButton_Click(object sender, EventArgs e)
        {
            if (deviceList.SelectedItem == null)
            {
                MessageBox.Show("Select a Book you want to remove from the Device");
                return;
            }

            removeButton.Enabled = false;
            var filePath = (deviceList.SelectedItem as DeviceFolder).getSimplifiedPath();
            await Task.Run(() => { deleteFile(filePath); });
            removeButton.Enabled = true;

            deviceList.Items.Remove(deviceList.SelectedItem);
        }
    }
}
