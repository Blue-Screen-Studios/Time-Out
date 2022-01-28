using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using UnityEngine.SceneManagement;

namespace SaveSystem
{
    [System.Serializable]
    public class SaveData
    {
        public bool[] playerAbilities;
        public float[] playerPostion;
        public int currentLevel;

        public SaveData(Transform _playerPosition)
        {
            playerAbilities = PlayerAbilityTracker.GetValues();
            currentLevel = SceneManager.GetActiveScene().buildIndex;

            playerPostion[0] = _playerPosition.position.x;
            playerPostion[1] = _playerPosition.position.y;
        }

        public override string ToString()
        {
            string output = string.Empty;

            output += "\nAbilites: ";

            foreach(bool ability in playerAbilities)
            {
                output += ability + ", ";
            }

            output += "\nPlayerPosition: ";

            foreach(float coord in playerPostion)
            {
                output += coord + ", ";
            }

            output += "\nCurrentLevel: " + currentLevel;

            return output;
        }
    }
}
