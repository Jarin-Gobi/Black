using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Satisfaction : MonoBehaviour
{
    public GameObject Satisfy;
    public TextMeshProUGUI text;
    private void Update()
    {
        text.text = "총 포인트는 \"" + (GameManager.Instance.P_Money + GameManager.Instance.bet_Money) + "P\"입니다 정말 만족하십니까?";
    }

    public void Satis()
    {
        Satisfy.SetActive(true);
    }
    public void Maintain()
    {
        Satisfy.SetActive(false);
    }
}
