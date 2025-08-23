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
    public GameObject Win;
    public GameObject DealerOver21;
    public GameObject winText;
    public GameObject LooseOver21;
    public GameObject LooseNotOver;
    public GameObject Draw;
    public bool LooseControl = true;

    private void Awake()
    {
        LooseControl = true;
    }
    private IEnumerator POver21()
    {
        LooseOver21.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(0);
    }

    private IEnumerator PLoose()
    {
        LooseNotOver.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(0);
    }

    private IEnumerator DRAW()
    {
        Draw.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(0);
    }

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

        // else if (GameManager.Instance.GameOver && GameManager.Instance.P_Score < GameManager.Instance.D_Score)
        // {
        //     GameManager.Instance.GameOver = false;
        //     StartCoroutine(FadeinLoose());
        // }
        // 졌을 때
        if ((GameManager.Instance.D_Score > 21) || (GameManager.Instance.GameOver && GameManager.Instance.P_Score > GameManager.Instance.D_Score))
        {
            if(GameManager.Instance.P_Score == 21 && !GameManager.Instance.GetMoney)
            {
                GameManager.Instance.GetMoney = true;
                GameManager.Instance.P_Money += (int)(GameManager.Instance.bet_Money * 2.5);
            }
            else if(!GameManager.Instance.GetMoney)
            {
                GameManager.Instance.GetMoney = true;
                GameManager.Instance.P_Money += GameManager.Instance.bet_Money * 2;
            }
            GameManager.Instance.GameOver = false;
            Win.SetActive(true);
            GameManager.Instance.bet_Money = 0;
            if (GameManager.Instance.P_Score > GameManager.Instance.D_Score)
            {
                winText.SetActive(true);
            }
            else if(GameManager.Instance.D_Score > 21)
            {
                DealerOver21.SetActive(true);
            }
        }
        if ((GameManager.Instance.P_Score > 21) || (GameManager.Instance.GameOver && GameManager.Instance.P_Score < GameManager.Instance.D_Score))
        {
            GameManager.Instance.bet_Money = 0;
            if (GameManager.Instance.P_Money <= 0)
            {
                GameManager.Instance.GameOver = false;
                LooseControl = false;
                StartCoroutine(FadeinLoose());
            }
            else if(LooseControl)
            {
                GameManager.Instance.GameOver = false;
                if(GameManager.Instance.P_Score > 21)
                {
                    StartCoroutine(POver21());
                }
                else
                {
                    StartCoroutine(PLoose());
                }
            }
        }
        // else if (GameManager.Instance.GameOver && GameManager.Instance.P_Score > GameManager.Instance.D_Score)
        // {
        //     GameManager.Instance.GameOver = false;
        //     SceneManager.LoadScene(0);
        // }
        // 이겼을 때
        if (GameManager.Instance.GameOver && GameManager.Instance.P_Score == GameManager.Instance.D_Score)
        {
            if(!GameManager.Instance.GetMoney)
            {
                GameManager.Instance.GetMoney = true;
                GameManager.Instance.P_Money += GameManager.Instance.bet_Money;
            }
            GameManager.Instance.bet_Money = 0;
            StartCoroutine(DRAW());
        }
        // 비겼을 때
    }

    public void re()
    {
        GameManager.Instance.NewGame = true;
        GameManager.Instance.P_Money = 300;
        SceneManager.LoadScene(0);
    }

    public void Double()
    {
        SceneManager.LoadScene(0);
    }

    public void Ranking()
    {
        GameManager.Instance.SubmitRanking();
    }
}
