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
        text.text = "�� ����Ʈ�� \"" + (GameManager.Instance.P_Money + GameManager.Instance.bet_Money) + "P\"�Դϴ� ���� �����Ͻʴϱ�?";
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
