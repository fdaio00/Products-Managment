using System;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

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

        public static string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

       public static string Encrypt(string plainText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES encryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create an encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                // Encrypt the data
                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }


                    // Return the encrypted data as a Base64-encoded string
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }


        public static string Decrypt(string cipherText, string key)
        {
            // Ensure the key length is valid for AES (16, 24, or 32 bytes)
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            if (keyBytes.Length != 16 && keyBytes.Length != 24 && keyBytes.Length != 32)
            {
                throw new ArgumentException("Invalid key length for AES.");
            }

            try
            {
                // Convert the cipher text from Base64
                byte[] fullCipher = Convert.FromBase64String(cipherText);

                // Extract the IV from the beginning of the cipher text
                byte[] iv = new byte[16]; // AES block size is 16 bytes
                byte[] cipherBytes = new byte[fullCipher.Length - iv.Length];

                Array.Copy(fullCipher, iv, iv.Length);
                Array.Copy(fullCipher, iv.Length, cipherBytes, 0, cipherBytes.Length);

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = keyBytes;
                    aesAlg.IV = iv;

                    // Create a decryptor
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    // Decrypt the data
                    using (var msDecrypt = new System.IO.MemoryStream(cipherBytes))
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                    {
                        // Read the decrypted data from the StreamReader
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
            catch (FormatException)
            {
                throw new ArgumentException("The provided cipher text is not a valid Base64 string.");
            }
            catch (CryptographicException ex)
            {
                throw new CryptographicException("An error occurred during decryption. The input data may be corrupt or the key/IV may be incorrect.", ex);
            }
            catch (OverflowException ex)
            {
                throw new OverflowException("An overflow occurred during the decryption process. This may be due to improper handling of byte arrays or data conversion issues.", ex);
            }
        }

    }
}

