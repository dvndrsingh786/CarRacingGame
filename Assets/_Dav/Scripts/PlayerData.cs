using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dav
{
    public class PlayerData
    {
        public static string playerDataPP = "PlayerData";

        static PlayerData _instance;

        public static PlayerData instance
        {
            get
            {
                if (_instance == null)
                {
                    if (PlayerPrefs.HasKey(playerDataPP))
                    {
                        _instance = JsonUtility.FromJson<PlayerData>(playerDataPP);
                    }
                    else
                    {
                        _instance = new PlayerData();
                    }
                }
                return _instance;
            }
            set
            {
                _instance = value;
                PlayerPrefs.SetString(playerDataPP, JsonUtility.ToJson(_instance));
            }
        }

        public int selectedCarIndex = 0;
    }
}