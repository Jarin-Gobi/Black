using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] private Image Loosemoney;
    [SerializeField] private Image Loosemoney_background;
    [SerializeField] private Button Restart;
    [SerializeField] private Button Backhome;
    private IEnumerator Fadein()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.Hit.SetActive(false);
        GameManager.Instance.Stay.SetActive(false);
        Loosemoney_background.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.45f);
        Loosemoney.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        Restart.gameObject.SetActive(true);
        Backhome.gameObject.SetActive(true);

    }

    private void Update()
    {
        if(GameManager.Instance.P_Score > 21)
        {
            GameManager.Instance.GameOver = false;
            GameManager.Instance.P_Score = 0;
            GameManager.Instance.D_Score = 0;
            StartCoroutine(Fadein());
        }
        else if(GameManager.Instance.GameOver && GameManager.Instance.P_Score < GameManager.Instance.D_Score)
        {
            GameManager.Instance.GameOver = false;
            GameManager.Instance.P_Score = 0;
            GameManager.Instance.D_Score = 0;
            StartCoroutine(Fadein());
        }
        else if(GameManager.Instance.D_Score > 21)
        {
            GameManager.Instance.GameOver = false;
            GameManager.Instance.P_Score = 0;
            GameManager.Instance.D_Score = 0;
            SceneManager.LoadScene(0);
        }
        else if(GameManager.Instance.GameOver && GameManager.Instance.P_Score > GameManager.Instance.D_Score)
        {
            GameManager.Instance.GameOver = false;
            GameManager.Instance.P_Score = 0;
            GameManager.Instance.D_Score = 0;
            SceneManager.LoadScene(0);
        }
        else if(GameManager.Instance.GameOver)
        {
            Hit();
        }
    }

    public void Hit()
    {
        GameManager.Instance.GameOver = false;
        SceneManager.LoadScene(0);
    }
}
