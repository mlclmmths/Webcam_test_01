using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Webcam_WS
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        //Code to perform at the time of installing application
        public override void Install(System.Collections.IDictionary stateSaver)
        {
            // this tell Visual Studio to install what is necessary first
            base.Install(stateSaver);

            // after the base.Install() is done, it will run subsequent codes below
            //System.Windows.Forms.MessageBox.Show("Installing Application..."); // sample code
        }

        //Code to perform at the time of uninstalling application 
        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            //System.Windows.Forms.MessageBox.Show("Uninstalling Application..."); // sample code
            base.Uninstall(savedState);
            try
            {
                /* testing */
                //// delete any addictional files (or comepletely remove the folder)
                //string pathtodelete = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                //System.Windows.Forms.MessageBox.Show("Deleting: " + pathtodelete);
                //if (pathtodelete != null && Directory.Exists(pathtodelete))
                //{
                //    // delete all the file inside this folder except SID.SetupSupport
                //    foreach (var file in Directory.GetFiles(pathtodelete))
                //    {
                //        // MessageBox.Show(file);
                //        if (!file.Contains(System.Reflection.Assembly.GetAssembly(typeof(ProjectInstaller)).GetName().Name))
                //        {
                //            System.Windows.Forms.MessageBox.Show("Deleting: " + file);
                //            File.SetAttributes(file, FileAttributes.Normal);
                //            File.Delete(file);
                //        }
                //    }
                //    foreach (var directory in Directory.GetDirectories(pathtodelete))
                //    {
                //        System.Windows.Forms.MessageBox.Show("Deleting: " + directory);
                //        Directory.Delete(directory, true);
                //    }
                //}
                //System.Windows.Forms.MessageBox.Show("Successfully deleted leftovers.");

                /* with error popup but still works */
                string pathtodelete = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                //System.Windows.Forms.MessageBox.Show("Deleting: " + pathtodelete); // for debugging purpose
                if (pathtodelete != null && Directory.Exists(pathtodelete))
                {
                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(pathtodelete, Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents);
                    System.Windows.Forms.MessageBox.Show("Successfully deleted leftovers.");
                }
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Failed to uninstall. " + ex); // for debugging purpose
            }
        }

        private void serviceProcessInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
