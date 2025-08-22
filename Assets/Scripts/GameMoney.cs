using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMoney : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI Money;

    private void Awake()
    {
        Money = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        // GameManager �ν��Ͻ��� ã�Ƽ� �ڱ� �ڽ��� ���
        if (GameManager.Instance != null)
        {
            GameManager.Instance.GameMoney = Money;
        }
    }
}
