using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Egress.Api.Infraestructura.Implement.Services.General
{
    public class Aes256
    {
        public string JwtEncriptarPassword(string Password)
        {
            ConsultarParametros Parametros = new ConsultarParametros();
            string PasswordEncriptado = string.Empty;
            // Create a new instance of the Aes class.
            // This generates a new key and initialization vector (IV).
            byte[] Key = Encoding.ASCII.GetBytes(Parametros.ConsultarParametrosPorCodigo("LlaveAES"));
            byte[] IV = Encoding.ASCII.GetBytes(Parametros.ConsultarParametrosPorCodigo("VectorAES"));
            using (Aes myAes = Aes.Create())
            {
                // Encrypt the string to an array of bytes.
                //                Egress2021Egress2021Egress2021#@
                //Pa$$w0rd2021#@
                //myAes.Key = Encoding.ASCII.GetBytes("Egress2021Egress2021Egress2021#@");
                //myAes.IV = Encoding.ASCII.GetBytes("Pa$$w0rd2021#@#@");
                byte[] encrypted = EncryptStringToBytes_Aes(Password, Key, IV);
                PasswordEncriptado = BitConverter.ToString(encrypted, 0, encrypted.Length);
            }

            return PasswordEncriptado;
        }

        public string JwtDecrypPassword(string Usuario)
        {
            string TextoPlano = string.Empty;
            ConsultarParametros Parametros = new ConsultarParametros();
            Usuario usuarioRegistro = new Usuario();
            string UsuarioDato = usuarioRegistro.ConsultarPasswordUsuario(Usuario);
            var UsuarioByte = ObtenerByteDeLosDatos(UsuarioDato);
            byte[] Key = Encoding.ASCII.GetBytes(Parametros.ConsultarParametrosPorCodigo("LlaveAES"));
            byte[] IV = Encoding.ASCII.GetBytes(Parametros.ConsultarParametrosPorCodigo("VectorAES"));
            using (Aes myAes = Aes.Create())
            {
                // Encrypt the string to an array of bytes.
                myAes.Key = Key;
                myAes.IV = IV;
                //byte[] encrypted = EncryptStringToBytes_Aes(UsuarioByte, Key, IV);
                TextoPlano = DecryptStringFromBytes_Aes(UsuarioByte, myAes.Key, myAes.IV);
            }
            return TextoPlano;
        }


        private byte[] ObtenerByteDeLosDatos(string Dato)
        {
            byte[] sonuc = null;
            //await Task.Factory.StartNew(() =>
            //{
                string[] sifreliMesaj = Dato.Split('-');
                int[] decimalDeger = new int[sifreliMesaj.Length];
                string[] strDecimal = new string[sifreliMesaj.Length];
                sonuc = new byte[sifreliMesaj.Length];
                for (int i = 0; i < decimalDeger.Length; i++)
                {
                    if (sifreliMesaj[i] != null)
                    {
                        decimalDeger[i] = int.Parse(sifreliMesaj[i], System.Globalization.NumberStyles.HexNumber);
                        strDecimal[i] = Convert.ToString(decimalDeger[i]);
                        sonuc[i] = Convert.ToByte(strDecimal[i]);
                    }
                }
            //});

            return sonuc;
        }


        #region Cifrado Contraseña

        private static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            byte[] encrypted;

            // Create an Aes object with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key,
                                                                    aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt,
                                                                     encryptor,
                                                                     CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }

                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        private static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold the decrypted text.
            string plaintext = null;

            // Create an Aes object with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key,
                                                                    aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                                                                     decryptor,
                                                                     CryptoStreamMode.Read))
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


        #endregion
    }
}
