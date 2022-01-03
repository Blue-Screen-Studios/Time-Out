using System.IO;
using UnityEngine;
using BetterDebug;

namespace SaveSystem
{
    public static class IO
    {
        private static string directoryPath = Application.persistentDataPath + "/" + Application.productName + "/";
        private static string saveDataFilePath = directoryPath + "SaveData.json";

        public static void WriteJSONSerialized(SaveData data)
        {
            string jsonData = JsonUtility.ToJson(data, true);
            File.WriteAllText(saveDataFilePath, jsonData);
        }

        public static SaveData ReadJSONSerialized()
        {
            if(!File.Exists(saveDataFilePath))
            {
                AdvancedDebug.LogError("No file was found at location '" + saveDataFilePath + "'.");
                return null;
            }
            else
            {
                string fileContents = File.ReadAllText(saveDataFilePath);
                SaveData data = JsonUtility.FromJson<SaveData>(fileContents);
                return data;
            }
        }
    }
}