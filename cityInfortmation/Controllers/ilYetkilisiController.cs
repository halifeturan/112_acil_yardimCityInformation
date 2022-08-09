using CityInformation.Models;
using CityInformation.Models.Entities;
using cityInfortmation.Controllers;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace cityInfo.Controllers
{
    [Authorize(Roles = "Yetkili")]
    public class ilYetkilisiController : Controller
    {
        Aes myAes = Aes.Create();
        public static Crypt crypt = new Crypt();

        public IActionResult Index()
        {
            using (var dbContext = new Context())
            {
                //şifresi çözülmüş veri gelecek
                ViewData["ilId"] = HomeController.yetkiliId;

                var city = dbContext.CityProp.ToList();

                return View(city);
            }
        }

        public IActionResult addCity()
        {
            using (var dbContext = new Context())
            {
                return View(dbContext.CityProp.ToList());
            }
        }

        [HttpPost]

        public IActionResult addCity(CityProp city)
        {
            //veri geliyor-city
            using (myAes)
            {
                encryptCity(city);
                using (var db = new Context())
                {
                    db.CityProp.Add(city);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "ilYetkilisi");
        }
        public IActionResult updateCity(string cityId)
        {
            using (var dbContext = new Context())
            {
                var city = dbContext.CityProp.Find(cityId);
                return View(city);
            }
        }
        [HttpPost]
        public IActionResult updateCity(CityProp city)
        {
            encryptCity(city);
            using (var db = new Context())
            {
                db.CityProp.Update(city);
                db.SaveChanges();
                return RedirectToAction("Index", "ilYetkilisi", db.CityProp.ToList());
            }
          
        }


        //-------------------------------ENCRYPT-DECRYPT METODLARI BAŞLANGICI--------------------------------
        public CityProp encryptCity(CityProp city)
        {
            //şehir bilgilerini şifreleme > başlangıç
            if (city.cityName!=null)
            {
                string CRYPTcityName = crypt.Encrypt(city.cityName, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
                city.cityName = CRYPTcityName;
            }
            if (city.citySaglikUsername != null)
            {
                string CRYPTcitySaglikUsername = crypt.Encrypt(city.citySaglikUsername, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
                city.citySaglikUsername = CRYPTcitySaglikUsername;
            }
            if (city.cityItfaiyeUsername != null)
            {
                string CRYPTcityItfaiyeUsername = crypt.Encrypt(city.cityItfaiyeUsername, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
                city.cityItfaiyeUsername = CRYPTcityItfaiyeUsername;
            }
            if (city.cityJandarmaUsername != null)
            {
                string CRYPTcityJandarmaUsername = crypt.Encrypt(city.cityJandarmaUsername, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
                city.cityJandarmaUsername = CRYPTcityJandarmaUsername;
            }
            if (city.cityEmniyetUsername != null)
            {
                string CRYPTcityEmniyetUsername = crypt.Encrypt(city.cityEmniyetUsername, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
                city.cityEmniyetUsername = CRYPTcityEmniyetUsername;
            }
            if (city.cityAfadUsername != null)
            {
                string CRYPTcityAfadUsername = crypt.Encrypt(city.cityAfadUsername, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
                city.cityAfadUsername = CRYPTcityAfadUsername;
            }
            if (city.citySGuvenlikUsername != null)
            {
                string CRYPTcitySGuvenlikUsername = crypt.Encrypt(city.citySGuvenlikUsername, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
                city.citySGuvenlikUsername = CRYPTcitySGuvenlikUsername;
            }
            if (city.cityOrmanUsername != null)
            {
                string CRYPTcityOrmanUsername = crypt.Encrypt(city.cityOrmanUsername, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
                city.cityOrmanUsername = CRYPTcityOrmanUsername;
            }
            if (city.citySaglikPin != null)
            {
                string CRYPTcitySaglikPin = crypt.Encrypt(city.citySaglikPin, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
                city.citySaglikPin = CRYPTcitySaglikPin;
            }
            if (city.cityItfaiyePin != null)
            {
                string CRYPTcityItfaiyePin = crypt.Encrypt(city.cityItfaiyePin, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
                city.cityItfaiyePin = CRYPTcityItfaiyePin;
            }
            if (city.cityJandarmaPin != null)
            {
                string CRYPTcityJandarmaPin = crypt.Encrypt(city.cityJandarmaPin, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
                city.cityJandarmaPin = CRYPTcityJandarmaPin;
            }
            if (city.cityEmniyetPin != null)
            {
                string CRYPTcityEmniyetPin = crypt.Encrypt(city.cityEmniyetPin, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
                city.cityEmniyetPin = CRYPTcityEmniyetPin;
            }
            if (city.cityAfadPin != null)
            {
                string CRYPTcityAfadPin = crypt.Encrypt(city.cityAfadPin, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
                city.cityAfadPin = CRYPTcityAfadPin;
            }
            if (city.citySGuvenlikPin != null)
            {
                string CRYPTcitySGuvenlikPin = crypt.Encrypt(city.citySGuvenlikPin, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
                city.citySGuvenlikPin = CRYPTcitySGuvenlikPin;
            }
            if (city.cityOrmanPin != null)
            {
                string CRYPTcityOrmanPin = crypt.Encrypt(city.cityOrmanPin, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
                city.cityOrmanPin = CRYPTcityOrmanPin;
            }
            if (city.flet_id != null)
            {
                string CRYPTcityFlet_id = crypt.Encrypt(city.flet_id, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
                city.flet_id = CRYPTcityFlet_id;
            }

            //şehir bilgilerini şifreleme > bitiş
            return city;
        }
        //----------------------------------------------ENCRYPT----------------------------------------------
        #region kullanılmayan crypt metodları
        static byte[] EncryptStringToBytes_Aes(CityProp cityprop, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cityprop.cityName == null || cityprop.cityName.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(cityprop);

                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }


        //----------------------------------------------DECRYPT----------------------------------------------
        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
        //-------------------------------ENCRYPT-DECRYPT METODLARI BİTİŞ--------------------------------

        //-------------------------------BYTE/STRING METODLARI BAŞLANGIÇ--------------------------------
        public static String byteToString(byte[] rByte)
        {
            System.Text.ASCIIEncoding ByteEnc = new System.Text.ASCIIEncoding();
            return ByteEnc.GetString(rByte);
        }
        public static byte[] stringToByte(string rtext)
        {
            System.Text.ASCIIEncoding stringEnc = new System.Text.ASCIIEncoding();
            return stringEnc.GetBytes(rtext);
        }
        //-------------------------------BYTE/STRING METODLARI BİTİŞ--------------------------------

        //-------------------------------ŞEHİR ŞİFRELEME METODU BAŞLANGIÇ--------------------------------
        public static String sehirBilgisiEncrypt(CityProp cityprop, byte[] Key, byte[] IV)
        {
            Aes myAes = Aes.Create();
            byte[] encrypted = EncryptStringToBytes_Aes(cityprop, myAes.Key, myAes.IV);
            string ecString = byteToString(encrypted);
            return ecString;
        } 
        #endregion
        //-------------------------------ŞEHİR ŞİFRELEME METODU BİTİŞ--------------------------------
        public class Crypt
        {
            public string Encrypt(string passtext, string passPhrase, string saltV, string hashstring, int Iterations, string initVect, int keysize)
            {
                string functionReturnValue = null;

                try
                {
                    byte[] initVectorBytes = null;
                    initVectorBytes = Encoding.ASCII.GetBytes(initVect);
                    byte[] saltValueBytes = null;
                    saltValueBytes = Encoding.ASCII.GetBytes(saltV);

                    byte[] plainTextBytes = null;
                    plainTextBytes = Encoding.UTF8.GetBytes(passtext);

                    PasswordDeriveBytes password = default(PasswordDeriveBytes);
                    password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashstring, Iterations);

                    byte[] keyBytes = null;
                    keyBytes = password.GetBytes(keysize / 8);

                    RijndaelManaged symmetricKey = default(RijndaelManaged);
                    symmetricKey = new RijndaelManaged();


                    symmetricKey.Mode = CipherMode.CBC;

                    ICryptoTransform encryptor = default(ICryptoTransform);
                    encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);


                    MemoryStream memoryStream = default(MemoryStream);
                    memoryStream = new MemoryStream();


                    CryptoStream cryptoStream = default(CryptoStream);
                    cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);


                    cryptoStream.FlushFinalBlock();

                    byte[] cipherTextBytes = null;
                    cipherTextBytes = memoryStream.ToArray();


                    memoryStream.Close();
                    cryptoStream.Close();

                    string cipherText = null;
                    cipherText = Convert.ToBase64String(cipherTextBytes);

                    functionReturnValue = cipherText;
                }
                catch (Exception)
                {

                }
                return functionReturnValue;


            }
            public string Decrypt(string cipherText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
            {
                string functionReturnValue = null;

                // Convert strings defining encryption key characteristics into byte
                // arrays. Let us assume that strings only contain ASCII codes.
                // If strings include Unicode characters, use Unicode, UTF7, or UTF8
                // encoding.

                try
                {
                    byte[] initVectorBytes = null;
                    initVectorBytes = Encoding.ASCII.GetBytes(initVector);

                    byte[] saltValueBytes = null;
                    saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                    // Convert our ciphertext into a byte array.
                    byte[] cipherTextBytes = null;
                    cipherTextBytes = Convert.FromBase64String(cipherText);

                    // First, we must create a password, from which the key will be
                    // derived. This password will be generated from the specified
                    // passphrase and salt value. The password will be created using
                    // the specified hash algorithm. Password creation can be done in
                    // several iterations.
                    PasswordDeriveBytes password = default(PasswordDeriveBytes);
                    password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

                    // Use the password to generate pseudo-random bytes for the encryption
                    // key. Specify the size of the key in bytes (instead of bits).
                    byte[] keyBytes = null;
                    keyBytes = password.GetBytes(keySize / 8);

                    // Create uninitialized Rijndael encryption object.
                    RijndaelManaged symmetricKey = default(RijndaelManaged);
                    symmetricKey = new RijndaelManaged();

                    // It is reasonable to set encryption mode to Cipher Block Chaining
                    // (CBC). Use default options for other symmetric key parameters.
                    symmetricKey.Mode = CipherMode.CBC;

                    // Generate decryptor from the existing key bytes and initialization
                    // vector. Key size will be defined based on the number of the key
                    // bytes.
                    ICryptoTransform decryptor = default(ICryptoTransform);
                    decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

                    // Define memory stream which will be used to hold encrypted data.
                    MemoryStream memoryStream = default(MemoryStream);
                    memoryStream = new MemoryStream(cipherTextBytes);

                    // Define memory stream which will be used to hold encrypted data.
                    CryptoStream cryptoStream = default(CryptoStream);
                    cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                    // Since at this point we don't know what the size of decrypted data
                    // will be, allocate the buffer long enough to hold ciphertext;
                    // plaintext is never longer than ciphertext.
                    byte[] plainTextBytes = null;
                    plainTextBytes = new byte[cipherTextBytes.Length + 1];

                    // Start decrypting.
                    int decryptedByteCount = 0;
                    decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                    // Close both streams.
                    memoryStream.Close();
                    cryptoStream.Close();

                    // Convert decrypted data into a string.
                    // Let us assume that the original plaintext string was UTF8-encoded.
                    string plainText = null;
                    plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

                    // Return decrypted string.
                    functionReturnValue = plainText;

                }
                catch (Exception)
                {

                    throw;
                }
               

                return functionReturnValue;
            }
        }

    }
}
