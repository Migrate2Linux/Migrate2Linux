using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Collections.Specialized;
using System.IO;

namespace Migrate2Linux
{
    class Programs
    {
        //Read installed programs from registry
        public static List<string> installedPrograms()
        {
            List<string> allPrograms = new List<string>();
            string regKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey(regKeyPath);
            if (regKey != null)
            {
                string[] subKeyNames = regKey.GetSubKeyNames();
                for (int i = 0; i < subKeyNames.Length; i++)
                {
                    RegistryKey subKey = regKey.OpenSubKey(subKeyNames[i]);
                    string programName = (string)subKey.GetValue("DisplayName");

                    if (programName == null)
                    {
                        programName = (string)subKey.GetValue("QuitDisplayName");
                    }
                    if (programName != null)
                    {
                        allPrograms.Add(programName);
                    }
                }
            }
            else
            {
                throw new Exception("Registry-Key" + Registry.LocalMachine.Name + "\\" + regKeyPath + " not found");
            }
            return allPrograms;
        }

        public void getInstalledProgs(ListBox listbox)
        {
            List<string> st = new List<string>();

            st = installedPrograms();
                foreach (string programs in st)
                {
                    if (!(programs.Contains("Hotfix") || programs.Contains("Sicherheitsupdate") || programs.Contains("Update") || programs.Contains("Help") || programs.Contains("Visual C++") || programs.Contains("Language") || programs.Contains("Visual Studio") || programs.Contains(".Net") || programs.Contains(".NET")))
                    {

                        listbox.Items.Add(programs);
                    }

            }
        }

    }
}
