using UnityEngine;

namespace ScoreSystem
{
    public class ScoreData
    {
        private const string ScoreKey = "ScoreData";

        public int Score;

        public void Save()
        {
            string json = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(ScoreKey, json);
            PlayerPrefs.Save();
        }

        public static ScoreData Load()
        {
            if (PlayerPrefs.HasKey(ScoreKey))
            {
                string json = PlayerPrefs.GetString(ScoreKey);
                return JsonUtility.FromJson<ScoreData>(json);
            }

            return new ScoreData { Score = 0 };
        }
    }
}