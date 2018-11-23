using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace FolderDiff
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            //txtDirA.Text = @"C:\Root\compare\A";
            //txtDirB.Text = @"C:\Root\compare\B";
            //txtDirTo.Text = @"C:\Root\compare\RESULT";
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            var m = new FilesDiffManagement();
            m.ActorA.SearchPattern = txtFilter.Text;
            m.ActorB.SearchPattern = txtFilter.Text;
            m.ActorA.RootDirectory = new DirectoryInfo(txtDirA.Text);
            m.ActorB.RootDirectory = new DirectoryInfo(txtDirB.Text);
            m.ActorA.IncludeHideFiles = true;
            m.ActorB.IncludeHideFiles = true;
            m.SaveDiffTo = new DirectoryInfo(txtDirTo.Text);
            m.CompareType = rbA.Checked ? CompareType.AHasBNothing : CompareType.ANothingBHas;

            m.ActorA.GetOneFileMd5InfoFinished += (o, args) =>
            {
                if (statusStrip1.InvokeRequired)
                {
                    statusStrip1.Invoke(new Action(() =>
                    {
                        tsbl.Text = string.Format("正在分析(A)：{0}", args.FileMd5Info.FullFileName);
                    }));
                }
                else
                {
                    tsbl.Text = string.Format("正在分析(A)：{0}", args.FileMd5Info.FullFileName);
                }
                Application.DoEvents();
            };
            m.ActorB.GetOneFileMd5InfoFinished += (o, args) =>
            {
                if (statusStrip1.InvokeRequired)
                {
                    statusStrip1.Invoke(new Action(() =>
                    {
                        tsbl.Text = string.Format("正在分析(B)：{0}", args.FileMd5Info.FullFileName);
                    }));
                }
                else
                {
                    tsbl.Text = string.Format("正在分析(B)：{0}", args.FileMd5Info.FullFileName);
                }
                Application.DoEvents();
            };
            tsbl.Text = string.Format("正在装置文件信息...");
            btnExcute.Enabled = false;
            //var th1 = new Thread(() => m.ActorA.LoadFileMd5Info());
            //th1.Start();
            //while (th1.ThreadState != ThreadState.Stopped) Application.DoEvents();
            //var th2 = new Thread(() => m.ActorB.LoadFileMd5Info());
            //th2.Start();
            //while (th2.ThreadState != ThreadState.Stopped) Application.DoEvents();
            m.ActorA.LoadFileMd5Info();
            m.ActorB.LoadFileMd5Info();
            var diff = m.Compare();
            m.SaveResult(diff);
            tsbl.Text = string.Format("执行完毕！");

            Application.DoEvents();
            btnExcute.Enabled = true;
        }

        private void btnSelA_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDirA.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSelB_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDirB.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSelTo_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDirTo.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }

    public class Utils
    {
        public static long GetObjectSize(object o)
        {
            using (var stream = new MemoryStream(1000))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, o);
                return stream.Length;
            }
        }

    }

    public class Actor
    {
        public event EventHandler<CFileMd5Args> GetOneFileMd5InfoFinished;

        public Actor()
        {
            SearchPattern = "*.*";
        }

        protected virtual void OnGetOneFileMd5InfoFinished(CFileMd5Args e)
        {
            var handler = GetOneFileMd5InfoFinished;
            if (handler != null) handler(this, e);
        }

        public DirectoryInfo RootDirectory { get; set; }
        public string SearchPattern { get; set; }
        public bool IncludeHideFiles = false;

        [DefaultValue("SearchOption.AllDirectories")]
        public SearchOption SearchOption { get; set; }
        public List<CFileMd5> Files = new List<CFileMd5>();

        public void LoadFileMd5Info()
        {
            Files.Clear();
            DirectoryInfo root = new DirectoryInfo(RootDirectory.FullName);
            var fileInfos = root.GetFiles(SearchPattern, SearchOption.AllDirectories);
            foreach (var fi in fileInfos)
            {
                var fiMd5 = new CFileMd5();
                if (fi.Attributes == FileAttributes.System) continue;
                if (fi.Attributes == FileAttributes.Hidden && !IncludeHideFiles)
                    continue; // 不处理隐患文件
                if (fi.Attributes == FileAttributes.System) continue;

                fiMd5.FileName = fi.Name;
                fiMd5.FullFileName = fi.FullName;
                fiMd5.Md5 = GetMD5HashFromFile(fiMd5.FullFileName);
                var args = new CFileMd5Args {FileMd5Info = fiMd5};
                Files.Add(fiMd5);
                OnGetOneFileMd5InfoFinished(args);
            }
        }
        
        private string GetMd5(string originString)
        {
            var result = Encoding.Default.GetBytes(originString.Trim());
            var md5 = new MD5CryptoServiceProvider();
            var output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", string.Empty);
        }

        private static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail, error:" +ex.Message);
            }
        }
    }

    public class FilesDiffManagement
    {
        public Actor ActorA = new Actor();
        public Actor ActorB = new Actor();
        public CompareType CompareType = CompareType.AHasBNothing;
        public DirectoryInfo SaveDiffTo { get; set; }
        public List<CFileMd5> Compare()
        {
            var diffResult = new List<CFileMd5>();
            if (CompareType == CompareType.AHasBNothing)
            {
                ActorA.Files.ForEach(a =>
                {
                    if (ActorB.Files.Any(b => b.Md5 == a.Md5)) return;
                    diffResult.Add(a);
                });
            }
            else if (CompareType == CompareType.ANothingBHas)
            {
                ActorB.Files.ForEach(b =>
                {
                    if (ActorA.Files.Any(a => a.Md5 == b.Md5)) return;
                    diffResult.Add(b);
                });
            }

            return diffResult;
        }

        public void SaveResult(List<CFileMd5> diffResult)
        {
            foreach (var diff in diffResult)
            {
                if (CompareType == CompareType.AHasBNothing)
                {
                    var nfi = new FileInfo(Path.Combine(SaveDiffTo.FullName, diff.FullFileName.Replace(ActorA.RootDirectory.FullName, string.Empty).TrimStart(new[] {'\\'})));
                    if (nfi.DirectoryName != null && !Directory.Exists(nfi.DirectoryName))
                    {
                        Directory.CreateDirectory(nfi.DirectoryName);
                    }
                    File.Copy(diff.FullFileName, nfi.FullName, true);
                }
                else if (CompareType == CompareType.ANothingBHas)
                {
                    var nfi = new FileInfo(Path.Combine(SaveDiffTo.FullName, diff.FullFileName.Replace(ActorB.RootDirectory.FullName, string.Empty).TrimStart(new[] { '\\' })));
                    if (nfi.DirectoryName != null && !Directory.Exists(nfi.DirectoryName))
                    {
                        Directory.CreateDirectory(nfi.DirectoryName);
                    }
                    File.Copy(diff.FullFileName, nfi.FullName, true);
                }
            }
        }
    }

    public enum CompareType
    {
        AHasBNothing,
        ANothingBHas
    }
    public class CFileMd5
    {
        public string FileName { get; set; }
        public string FullFileName { get; set; }
        public string Md5 { get; set; }
    }

    public class CFileMd5Args : EventArgs
    {
        public CFileMd5 FileMd5Info { get; set; }
    }
}
