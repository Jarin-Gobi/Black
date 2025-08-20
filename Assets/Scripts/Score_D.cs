using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score_D : MonoBehaviour
{
    public TextMeshProUGUI score_p;
    private void Awake()
    {
        score_p = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        score_p.text = "D:" + GameManager.Instance.D_Score;
    }
}
