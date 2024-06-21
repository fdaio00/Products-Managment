using Product_Managment_BusniessLayer;
using System;
using System.IO;
using System.Windows.Forms;

namespace Products_Managment
{
    public class clsGlobal
    {


        public static clsUser CurrentUser;

        public static bool RememberUsernameAndPassword(string UserName, string Password)
        {

            try
            {
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                string filePath = currentDirectory + "\\data.txt";

                if (UserName == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }

                string DataToSave = UserName + "#//#" + Password;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(DataToSave);

                    return true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool GetStoredCredential(ref string UserName, ref string Password)
        {

            try

            {
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

                string filePath = CurrentDirectory + "\\data.txt";

                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);
                            UserName = result[0];
                            Password = result[1];
                        }

                        return true;
                    }
                }

                else
                    return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
