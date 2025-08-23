using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RankingManager : MonoBehaviour
{
    public static RankingManager Instance;

    public Ranking ranking;
    private const string RankingDataKey = "RankingData";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadRanking();
    }

    public RankData AddScore(string playerName, int newScore)
    {
        RankData newRankData = new RankData(playerName, newScore);
        ranking.rankList.Add(newRankData);

        ranking.rankList = ranking.rankList.OrderByDescending(x => x.Score).ToList();

        if (ranking.rankList.Count > 100)
        {
            ranking.rankList = ranking.rankList.GetRange(0, 100);
        }

        SaveRanking();

        return newRankData;
    }

    private void SaveRanking()
    {
        string json = JsonUtility.ToJson(ranking);
        PlayerPrefs.SetString(RankingDataKey, json);
        PlayerPrefs.Save();
    }

    private void LoadRanking()
    {
        string json = PlayerPrefs.GetString(RankingDataKey, null);

        if (string.IsNullOrEmpty(json))
        {
            ranking = new Ranking();
        }
        else
        {
            ranking = JsonUtility.FromJson<Ranking>(json);
        }
    }

    [ContextMenu("테스트용 랭킹 추가")]
    void AddTestScore()
    {
        AddScore("Player" + Random.Range(1, 100), Random.Range(100, 2000));
    }
}
