using System;
using System.IO;
using System.Windows.Forms;


namespace Products_Managment.GlobalClasses
{
    public class clsUtil
    {
        public static string GenerateGUID()
        {
            Guid newGuid = Guid.NewGuid();

            return newGuid.ToString();
        }


        public static bool CreateFolderIfDoesnotExist(string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                try
                {
                    Directory.CreateDirectory(filePath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في انشاء الملف: " + ex.Message);
                    return false;
                }
            }

            return true;
        }


        public static string ReplaceFileNameWithGUID(string SourceFile)
        {
            string FileName = SourceFile;
            FileInfo fi = new FileInfo(FileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;
        }


        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {



            string DestenationFolder = @"E:\Products Managment\Pictuers";
            if (!CreateFolderIfDoesnotExist(DestenationFolder))
            {
                return false;
            }

            string destenationFile = DestenationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destenationFile, true);
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile = destenationFile;
            return true;
        }
    }
}
