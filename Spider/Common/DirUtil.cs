using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Spider.Common
{
    class DirUtil
    {
        /// <summary>
        /// 从完整的路径名/文件名中返回路径名。包含最后的斜杠"\"。
        /// </summary>
        /// <param name="fullPathFile"></param>
        /// <returns></returns>
        public static string GetPath(string fullPathFile)
        {
            string strReturn = "";
            int pos = fullPathFile.LastIndexOf(@"\");
            if (pos >= 0)
            {
                strReturn = fullPathFile.Substring(0, pos);
            }
            return strReturn;
        }

        /// <summary>
        /// 从完整的路径名/文件名中返回文件名
        /// </summary>
        /// <param name="fullPathFile"></param>
        /// <returns></returns>
        public static string GetFileName(string fullPathFile)
        {
            string strReturn = fullPathFile;
            int pos = fullPathFile.LastIndexOf(@"\");
            if (pos >= 0)
            {
                strReturn = fullPathFile.Substring(pos + 1);
            }
            return strReturn;
        }

        /// <summary>
        /// 从文件名中返回文件扩展名,文件名中可以包含路径.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileExtensionName(string fileName)
        {
            string strReturn = "";
            int pos = fileName.LastIndexOf(@".");
            if (pos >= 0)
            {
                strReturn = fileName.Substring(pos + 1);
            }
            return strReturn;
        }

        public static string GetParentDir(string dir)
        {
            string parentDir;                                       //the parent folder of Image files
            if (dir.EndsWith(@"\"))
            {
                parentDir = dir.Substring(0, dir.Length - 1);       //remove the last "\"
            }
            else
            {
                parentDir = dir;
            }
            int pos = parentDir.LastIndexOf(@"\");
            parentDir = parentDir.Substring(0, pos + 1);            //remove the last level of folder,get the parent folder of picture
            return parentDir;
        }

        public static string GetLastFolderName(string dir)
        {        //Return the last level of folder name
            string parentDir;                                       //the parent folder of Image files
            string lastFolderName;                                  //the last level of folder name

            if (dir.EndsWith(@"\"))
            {
                parentDir = dir.Substring(0, dir.Length - 1);       //remove the last "\"
            }
            else
            {
                parentDir = dir;
            }
            int pos = parentDir.LastIndexOf(@"\");
            lastFolderName = dir.Substring(pos + 1);
            return lastFolderName;
        }

        /// <summary>
        ///    //Copy directory,not copy files in directory
        /// </summary>
        /// <param name="sourceDir"></param>
        /// <param name="targetDir"></param>
        public static void CopyDir(string sourceDir, string targetDir)
        {
            DirectoryInfo sourceDirInfo = new DirectoryInfo(sourceDir);
            DirectoryInfo targetDirInfo = new DirectoryInfo(targetDir);

            //Determine whether the sourceDirInfo directory exists.
            if (!sourceDirInfo.Exists)
                return;
            if (!targetDirInfo.Exists)
                targetDirInfo.Create();

            //Copy files in sub directories.
            DirectoryInfo[] sourceSubDirectories = sourceDirInfo.GetDirectories();
            for (int j = 0; j < sourceSubDirectories.Length; ++j)
            {
                CopyDir(sourceSubDirectories[j].FullName, targetDirInfo.FullName + "\\" + sourceSubDirectories[j].Name);
            }
        }

        /// <summary>
        /// Copy a source directory to a target directory,including files
        /// </summary>
        /// <param name="sourceDir"></param>
        /// <param name="targetDir"></param>
        public static void CopyFiles(string sourceDir, string targetDir)
        {
            DirectoryInfo sourceDirInfo = new DirectoryInfo(sourceDir);
            DirectoryInfo targetDirInfo = new DirectoryInfo(targetDir);

            //Determine whether the sourceDirInfo directory exists.
            if (!sourceDirInfo.Exists)
                return;
            if (!targetDirInfo.Exists)
                targetDirInfo.Create();

            //Copy files.
            FileInfo[] sourceFiles = sourceDirInfo.GetFiles();
            for (int i = 0; i < sourceFiles.Length; ++i)
            {
                File.Copy(sourceFiles[i].FullName, targetDirInfo.FullName + "\\" + sourceFiles[i].Name, true);
            }

            //Copy files in sub directories.
            DirectoryInfo[] sourceSubDirectories = sourceDirInfo.GetDirectories();
            for (int j = 0; j < sourceSubDirectories.Length; ++j)
            {
                CopyFiles(sourceSubDirectories[j].FullName, targetDirInfo.FullName + "\\" + sourceSubDirectories[j].Name);
            }
        }

        /// <summary>
        /// Remove a source directory to a target directory,including files.
        /// </summary>
        /// <param name="sourceDir"></param>
        /// <param name="targetDir"></param>
        public static void RemoveFiles(string sourceDir, string targetDir)
        {
            DirectoryInfo sourceDirInfo = new DirectoryInfo(sourceDir);
            DirectoryInfo targetDirInfo = new DirectoryInfo(targetDir);

            //Determine whether the sourceDirInfo directory exists.
            if (!sourceDirInfo.Exists)
                return;
            if (!targetDirInfo.Exists)
                targetDirInfo.Create();

            //Copy files.
            FileInfo[] sourceFiles = sourceDirInfo.GetFiles();
            for (int i = 0; i < sourceFiles.Length; ++i)
            {
                File.Copy(sourceFiles[i].FullName, targetDirInfo.FullName + "\\" + sourceFiles[i].Name, true);
                File.Delete(sourceFiles[i].FullName);   //delete file after copy
            }

            //Copy files in sub directories.
            DirectoryInfo[] sourceSubDirectories = sourceDirInfo.GetDirectories();
            for (int j = 0; j < sourceSubDirectories.Length; ++j)
            {
                CopyFiles(sourceSubDirectories[j].FullName, targetDirInfo.FullName + "\\" + sourceSubDirectories[j].Name);
            }
        }
    }
}
