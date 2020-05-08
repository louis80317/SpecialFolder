using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SpecialFolder
{

    partial class Operation
    {
        String path;
        private const String TITLE1 = "Path DNE!";
        private const String TITLE2 = "Confirm Password!";
        private const String LOCKEDNAME = @"DO NOT EH START.{21EC2020-3AEA-1069-A2DD-08002B30309D}";
        private const String TEMPLOC = @"C:\Windows\System32\";
        private const String TEMPPATH = TEMPLOC + LOCKEDNAME;


        public Operation()
        {
            path = "";
            //Console.WriteLine(path);
        }

        // 隱藏資料夾
        public void LockDir()
        {
            DirectoryInfo di = new DirectoryInfo(path);
            if (!di.Exists)
            {
                if (AskCreateDir(path))
                { 
                    MessageBox.Show("Folder created!");
                }
            }
            else
            {
                UpdateFileAttributes(di, true);
                MessageBox.Show("Locked");
            }
        }

        // 解除隱藏資料夾
        public void UnLockDir()
        {
            DirectoryInfo di = new DirectoryInfo(path);
            if (!di.Exists)
            {
                string noDirMsg = "The path: \"" + path
                    + "\" does not exist!";
                MessageBox.Show(noDirMsg);
            }
            UpdateFileAttributes(di, false);
            MessageBox.Show("UnLocked");
        }

        // dInfo更改檔案屬性
        private void UpdateFileAttributes(DirectoryInfo dInfo, bool hide)
        {
            // get path from directory info
            string tPath = dInfo.FullName;

            // Set Directory attribute
            FileAttributes tAttributes = File.GetAttributes(tPath);
            if (hide)
            {
                File.SetAttributes(tPath, tAttributes | FileAttributes.Hidden | FileAttributes.System);
            } else
            {
                tAttributes = RemoveAttribute(tAttributes, FileAttributes.Hidden | FileAttributes.System);
                File.SetAttributes(tPath, tAttributes);
            }
            //Console.WriteLine("The \"{0}\" directory's attributes has been edited.", tPath);

            // get list of all files in the directory
            foreach (FileInfo file in dInfo.GetFiles())
            {
                string tfPath = file.FullName;
                FileAttributes tfAttributes = File.GetAttributes(tfPath);
                if (hide)
                {
                    File.SetAttributes(tfPath, tfAttributes | FileAttributes.Hidden | FileAttributes.System);
                } else
                {
                    tfAttributes = RemoveAttribute(tfAttributes, FileAttributes.Hidden | FileAttributes.System);
                    File.SetAttributes(tfPath, tfAttributes);
                }
            }
            // recurse all of the subdirectories
            foreach (DirectoryInfo subDir in dInfo.GetDirectories())
            {
                UpdateFileAttributes(subDir, hide);
            }
        }

        // 檢查檔案路徑
        public bool CheckPath(string cPath)
        {
            if (cPath != "")
            {
                try
                {
                    Path.GetFullPath(cPath);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("[ERROR: CheckPath] Exception: {0}", e);
                }
            }
            else
            {
                MessageBox.Show("Please choose a valid folder path!");
            }
            return false;
        }

        // 儲存密碼
        public bool SetPass(string pw, string pPath)
        {
            pPath += @"\D0N0TEHH5T4RT.txt";
            try
            {
                if (File.Exists(pPath))
                {
                    MessageBox.Show("Folder is already Locked!");
                } else
                {
                    if (pw == "" || pw == null || pw == " ")
                    {
                        MessageBox.Show("Password can NOT be empty!");
                    }
                    else if (AskConfirmPass(pw))
                    {
                        using (FileStream fs = File.Create(pPath))
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes(pw);
                            fs.Write(info, 0, info.Length);
                        }
                        return true;
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine("[ERROR: SetPass] " + ex.ToString());
            }
            return false;
        }

        // 檢查/清除密碼
        public bool CheckPass(String pw, String pPath)
        {
            pPath += @"\D0N0TEHH5T4RT.txt";
            try
            {
                if (File.Exists(pPath))
                {
                    using (StreamReader sr = File.OpenText(pPath))
                    {
                        String s = sr.ReadLine();
                        sr.Close();
                        if (pw == s)
                        {
                            File.Delete(pPath);
                            return true;
                        } else
                        {
                            MessageBox.Show("Wrong password!");
                        }
                    }
                } else
                {
                    MessageBox.Show("The directory do not exists or\n"
                        +"This is not a folder locked by Secret Folder!");
                }
            } catch (Exception ex)
            {
                Console.WriteLine("[CheckPass] " + ex.ToString());
            }
            return false;
        }

        // 詢問建立資料夾
        public static bool AskCreateDir(string mPath)
        {
            string createDirMsg = "The path: \"" + mPath
                    + "\" does not exist!\nWould you like to create it?";
            MessageBoxButtons createDirMB = MessageBoxButtons.YesNo;
            DialogResult createDirDR = MessageBox.Show(createDirMsg, TITLE1, createDirMB);
            if (createDirDR == DialogResult.Yes)
            {
                Directory.CreateDirectory(mPath);
                return true;
            } else
            {
                return false;
            }
        }

        public static bool CheckTempLoc()
        {
            try
            {
                if (Directory.Exists(TEMPLOC))
                {
                    if (Directory.Exists(TEMPPATH))
                    {
                        // deal with multiple scret folder
                        //Directory.Move(TEMPPATH,TEMPLOC+@"2"+LOCKEDNAME);
                    } else
                    {
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("The magical directory do not exists \n"
                        + "The folder is locked with a less secure option!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[CheckPass] " + ex.ToString());
            }
            return false;
        }

        // 詢問確認密碼
        public bool AskConfirmPass(String pw)
        {
            String confirmPassMsg = "You are about to lock"
                + " the folder with password: " + pw;
            MessageBoxButtons confirmPassMB = MessageBoxButtons.OKCancel;
            DialogResult confirmPassDR = MessageBox.Show(confirmPassMsg, TITLE2, confirmPassMB);
            if (confirmPassDR == DialogResult.OK)
            {
                return true;
            } else
            {
                return false;
            }
        }

        /*
        // cmd 隱藏資料夾
        public static void hideFolder(bool hide, string path)
        {
            string hideOrShow = (hide) ? "+" : "-";
            Process.Start("cmd.exe" + hideOrShow + "h " + hideOrShow + "s \"" + path + "\" /S /D");
        }
        */

        // 去除檔案屬性
        private static FileAttributes RemoveAttribute
        (FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }

        // 更新路徑
        public void ChangePath(string nPath)
        {
            path = nPath;
        }
    }


}