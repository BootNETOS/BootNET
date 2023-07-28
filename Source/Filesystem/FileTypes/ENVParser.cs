using System;
using System.Collections.Generic;
using System.IO;

namespace BootNET.Filesystem.FileTypes
{
    public class ENVParser
    {
        public readonly string filePath;
        public readonly Dictionary<string, string> envDictionary;

        public ENVParser(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty.");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("The specified .env file does not exist.", filePath);

            this.filePath = filePath;
            envDictionary = ParseFile(filePath);
        }

        private static Dictionary<string, string> ParseFile(string filePath)
        {
            var envDict = new Dictionary<string, string>();

            try
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                        continue;

                    var separatorIndex = line.IndexOf('=');

                    if (separatorIndex != -1)
                    {
                        var key = line[..separatorIndex].Trim();
                        var value = line[(separatorIndex + 1)..].Trim();

                        if (value.StartsWith("\"") && value.EndsWith("\""))
                        {
                            value = value[1..^1];
                        }

                        envDict[key] = value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while parsing the .env file.", ex);
            }

            return envDict;
        }

        public string GetValue(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key), "Key cannot be null or empty.");

            if (envDictionary.TryGetValue(key, out var value))
                return value;

            throw new KeyNotFoundException($"The key '{key}' was not found in the .env file.");
        }

        public void SetValue(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key), "Key cannot be null or empty.");

            envDictionary[key] = value;
        }

        public void DeleteValue(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key), "Key cannot be null or empty.");

            envDictionary.Remove(key);
        }

        public Dictionary<string, string> ListVariables()
        {
            return new Dictionary<string, string>(envDictionary);
        }

        public void SaveToFile()
        {
            try
            {
                using var writer = new StreamWriter(filePath);
                foreach (var kvp in envDictionary)
                {
                    writer.WriteLine($"{kvp.Key}={kvp.Value}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving changes to the .env file.", ex);
            }
        }
    }
}