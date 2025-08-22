using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI One_third;
    [SerializeField] private TextMeshProUGUI Half;
    [SerializeField] private TextMeshProUGUI Howmuch;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartView = gameObject;
        }
    }

    private void Update()
    {
        One_third.text = (GameManager.Instance.P_Money / 3) + "P";
        Half.text = (GameManager.Instance.P_Money / 2) + "P";
        Howmuch.text = "현재 보유 포인트 : " + GameManager.Instance.P_Money + "P";
    }

    public void HideScreen100()
    {
        GameManager.Instance.bet_Money = GameManager.Instance.P_Money / 3;
        GameManager.Instance.P_Money -= GameManager.Instance.bet_Money;
        GameManager.Instance.Round++;
        gameObject.SetActive(false);
    }


    public void HideScreen150()
    {
        GameManager.Instance.bet_Money = GameManager.Instance.P_Money / 2;
        GameManager.Instance.P_Money -= GameManager.Instance.bet_Money;
        GameManager.Instance.Round++;
        gameObject.SetActive(false);
    }

    public void HideScreenAllin()
    {
        GameManager.Instance.bet_Money = GameManager.Instance.P_Money;
        GameManager.Instance.P_Money -= GameManager.Instance.bet_Money;
        GameManager.Instance.Round++;
        gameObject.SetActive(false);
    }
}
