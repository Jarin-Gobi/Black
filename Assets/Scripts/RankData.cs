using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RankData
{
    public string Name;
    public int Score;
    public string UniqueId;

    public RankData(string name, int score)
    {
        this.Name = name;
        this.Score = score;
        this.UniqueId = System.DateTime.Now.Ticks + "_" + Random.Range(0, 9999);
    }
}

[System.Serializable]
public class Ranking
{
    public System.Collections.Generic.List<RankData> rankList = new System.Collections.Generic.List<RankData>();
}