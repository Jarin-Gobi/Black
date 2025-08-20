using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    Debug.Log("Error");
                }
            }
            return instance;
        }
    }

    public int playerMoney = 0;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    public Minicards minicards;
    public Minicards minicards_d;

    public GameObject Hit;
    public GameObject Stay;

    //딜러인가?
    public bool Dealer = false;

    public string MiniCard;

    //게임 끝?
    public bool GameOver = false;

    public int P_Score = 0;
    public int D_Score = 0;

    public int P_Money = 0;

    //public bool BlackJack_P = false;


}