using BetterDebug;

namespace SaveSystem
{
    public static class Saver
    {
        public static void SaveNow(SaveData data)
        {
            IO.WriteJSONSerialized(data);
            AdvancedDebug.Log("Saved game data: " + data);
        }
        
        public static SaveData LoadNow()
        {
            SaveData data = IO.ReadJSONSerialized();
            
            if(data != null)
            {
                AdvancedDebug.Log("Loaded game data: " + data);
            }
            else
            {
                AdvancedDebug.LogWarning("Loaded null game data: " + data);
            }

            return IO.ReadJSONSerialized();
        }
    }
}
