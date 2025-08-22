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
    // 짐


    private IEnumerator FadeinLoose()
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
        // 올인에서도 지게 됨 고쳐야 됨
        if (GameManager.Instance.P_Money <= 0)
        {
            GameManager.Instance.GameOver = false;
            StartCoroutine(FadeinLoose());
            GameManager.Instance.P_Score = 0;
            GameManager.Instance.D_Score = 0;
        }
        if ((GameManager.Instance.P_Score > 21) || (GameManager.Instance.GameOver && GameManager.Instance.P_Score < GameManager.Instance.D_Score))
        {
            GameManager.Instance.P_Score = 0;
            GameManager.Instance.D_Score = 0;
        }
        // else if (GameManager.Instance.GameOver && GameManager.Instance.P_Score < GameManager.Instance.D_Score)
        // {
        //     GameManager.Instance.GameOver = false;
        //     StartCoroutine(FadeinLoose());
        // }
        // 졌을 때
        if ((GameManager.Instance.D_Score > 21) || (GameManager.Instance.GameOver && GameManager.Instance.P_Score > GameManager.Instance.D_Score))
        {
            GameManager.Instance.GameOver = false;
            GameManager.Instance.P_Score = 0;
            GameManager.Instance.D_Score = 0;
            //SceneManager.LoadScene(0); // 임시
        }
        // else if (GameManager.Instance.GameOver && GameManager.Instance.P_Score > GameManager.Instance.D_Score)
        // {
        //     GameManager.Instance.GameOver = false;
        //     SceneManager.LoadScene(0);
        // }
        // 이겼을 때
        if (GameManager.Instance.GameOver && GameManager.Instance.P_Score == GameManager.Instance.D_Score)
        {
            Hit();
        }
        // 비겼을 때
    }

    public void Hit()
    {
        GameManager.Instance.GameOver = false;
        SceneManager.LoadScene(0);
    }
}
