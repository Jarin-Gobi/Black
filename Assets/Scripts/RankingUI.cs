using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class RankingUI : MonoBehaviour
{
    public GameObject rankEntryPrefab;
    public Transform contentParent;
    public int displayLimit = 100;

    [Header("My Ranking")]
    public GameObject myRankPanel;
    public TextMeshProUGUI myRankText;
    public TextMeshProUGUI myNameText;
    public TextMeshProUGUI myScoreText;
    public Color myRankHighlightColor = Color.yellow;

    private void Start()
    {
        GameManager.Instance.rankingUI = this;
        gameObject.SetActive(false);
    }

    public void ShowRanking(RankData myRecordToShow = null)
    {
        // 1. 기존 UI 삭제
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }
        myRankPanel.SetActive(false);

        var allRanks = RankingManager.Instance.ranking.rankList;

        int loopCount = Mathf.Min(allRanks.Count, displayLimit);
        for (int i = 0; i < loopCount; i++)
        {
            GameObject entry = Instantiate(rankEntryPrefab, contentParent);
            TextMeshProUGUI[] texts = entry.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = (i + 1).ToString();
            texts[1].text = allRanks[i].Name;
            texts[2].text = allRanks[i].Score.ToString();

            if (myRecordToShow != null && allRanks[i].UniqueId == myRecordToShow.UniqueId)
            {
                entry.GetComponent<UnityEngine.UI.Image>().color = myRankHighlightColor;
            }
        }

        if (myRecordToShow != null)
        {
            int myRankIndex = allRanks.FindIndex(rank => rank.UniqueId == myRecordToShow.UniqueId);
            myRankText.text = (myRankIndex + 1).ToString();
            myNameText.text = myRecordToShow.Name;
            myScoreText.text = myRecordToShow.Score.ToString();
            myRankPanel.SetActive(true);
        }
    }

    void OnEnable()
    {
        ShowRanking(null);
    }

    public void Back()
    {
        GameManager.Instance.NewGame = true;
        GameManager.Instance.P_Money = 300;
        SceneManager.LoadScene(0);
    }
}
