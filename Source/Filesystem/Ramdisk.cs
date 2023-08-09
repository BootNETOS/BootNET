using System;
using System.Collections.Generic;

namespace BootNET.Filesystem
{
    /// <summary>
    /// A simple ramdisk implementation without support of sub directories.
    /// </summary>
    public class Ramdisk
    {
        #region Constructors
        public Ramdisk()
        {
            RootDir = new Dictionary<string, string>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lists the files of the ramdisk.
        /// </summary>
        /// <returns>A list with the contents of the ramdisk</returns>
        public List<string> DirectoryListing()
        {
            List<string> keys = new();
            foreach (string key in RootDir.Keys)
            {
                keys.Add(key);
            }
            return keys;
        }

        /// <summary>
        /// Writes a file to the ramdisk FLT, if it doesn't exist, it will create said file.
        /// </summary>
        /// <param name="file">The file you want to write to.</param>
        /// <param name="contents">What you want to write to file.</param>
        public void WriteText(string file, string contents)
        {
            if (FileExists(file))
            {
                RootDir[file] = contents;
            }
            else
            {
                RootDir.Add(file, contents);
            }
        }

        /// <summary>
        /// This method returns the contents of a file in the ramdisk as a string, assuming it exists. If the file doesn't exist, then it will return the phrase "ERR_NOTFOUND".
        /// </summary>
        /// <param name="file">The file you want to read from.</param>
        /// <returns>The contents of a file in the ramdisk as a string, assuming it exists.</returns>
        public string ReadText(string file)
        {
            if (RootDir.ContainsKey(file))
            {
                return RootDir[file];
            }
            else
            {
                throw new Exception("Cannot find file \"" + file + "\"");
            }
        }

        /// <summary>
        /// This method returns the contents of a file in the ramdisk as a byte[], assuming it exists. If the file doesn't exist, then it will return the phrase "ERR_NOTFOUND".
        /// </summary>
        /// <param name="file">The file you want to read from.</param>
        /// <returns>The contents of a file in the ramdisk as a byte[], assuming it exists.</returns>
        public byte[] ReadBytes(string file)
        {
            if (RootDir.ContainsKey(file))
            {
                byte[] byteArray = new byte[RootDir[file].Length];

                // loop through the char array and convert each character to a byte
                // why did i think that returning bytes was a good idea
                for (int i = 0; i < RootDir[file].Length; i++)
                {
                    byteArray[i] = (byte)RootDir[file][i];
                }
                return byteArray;
            }
            else
            {
                throw new Exception("Cannot find file \"" + file + "\"");
                // if copy and pasting didn't exist, writing that byte array would be so painful lmao
            }
        }

        /// <summary>
        /// Returns a boolean value representing if the requested file exists in the Ramdisk.
        /// </summary>
        /// <param name="file">The file you want to check.</param>
        /// <returns>A boolean value representing if the requested file exists in the Ramdisk.</returns>
        public bool FileExists(string file)
        {
            return RootDir.ContainsKey(file);
        }
        #endregion

        #region Fields
        public Dictionary<string, string> RootDir;
        #endregion
    }
}