using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartView : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.Instance.Round > 0)
        {
            Destroy(gameObject);
        }
    }

    public void HideScreen50()
    {
        GameManager.Instance.P_Money -= 100;
        GameManager.Instance.GameMoney.text = "" + GameManager.Instance.P_Money;
        GameManager.Instance.Round++;
        gameObject.SetActive(false);
    }


    public void HideScreen100()
    {
        GameManager.Instance.P_Money -= 150;
        GameManager.Instance.GameMoney.text = "" + GameManager.Instance.P_Money;
        GameManager.Instance.Round++;
        gameObject.SetActive(false);
    }
    
    public void HideScreen150()
    {
        GameManager.Instance.P_Money -= 300;
        GameManager.Instance.GameMoney.text = "" + GameManager.Instance.P_Money;
        GameManager.Instance.Round++;
        gameObject.SetActive(false);
    }
}
