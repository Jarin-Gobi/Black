using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public bool start = true;
    // 카드 보여주기
    public Image cardDisplayImage_D;
    public Image cardDisplayImage;

    // 기본 카드 이미지
    public Sprite cardDisplaySprite;

    // 카드
    public List<List<int>> Gachalist = new List<List<int>>();
    public List<int> Spade = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
    public List<int> Heart = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
    public List<int> Clova = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
    public List<int> Diamond = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

    private void Awake()
    {
        Gachalist.Add(Spade);
        Gachalist.Add(Heart);
        Gachalist.Add(Clova);
        Gachalist.Add(Diamond);
    }

    public void Gacha(Image targetImage)
    {
        if (Gachalist.Count == 0)
        {
            Debug.Log("카드X");
            return;
        }

        int rand = 0;
        while (true)
        {
            // 모양 선택
            rand = Random.Range(0, Gachalist.Count);

            if (Gachalist[rand].Count > 0)
            {
                break;
            }
            else
            {
                Gachalist.RemoveAt(rand);

                if (Gachalist.Count == 0)
                {
                    Debug.Log("모든 카드가 소진되었습니다.");
                    return;
                }
            }
        }

        //int rand = Random.Range(0, Gachalist.Count);

        // 카드 개수 확인
        if (Gachalist[rand].Count > 0)
        {
            int miniCardNum = 0;
            int CardNum = 0;
            // 카드 뽑기
            int rand2 = Random.Range(0, Gachalist[rand].Count);

            //플레이어, 딜러 점수
            if (GameManager.Instance.Dealer)
            {
                if (Gachalist[rand][rand2] == 11 || Gachalist[rand][rand2] == 12 || Gachalist[rand][rand2] == 13)
                {
                    GameManager.Instance.D_Score += 10;
                }
                else if(Gachalist[rand][rand2] == 1)
                {
                    if(GameManager.Instance.D_Score + 11 > 21)
                    {
                        GameManager.Instance.D_Score += 1;
                    }
                    else
                    {
                        GameManager.Instance.D_Score += 11;
                    }
                }
                else
                {
                    GameManager.Instance.D_Score += Gachalist[rand][rand2];
                }
            }
            else
            {
                if (Gachalist[rand][rand2] == 11 || Gachalist[rand][rand2] == 12 || Gachalist[rand][rand2] == 13)
                {
                    GameManager.Instance.P_Score += 10;
                }
                else if (Gachalist[rand][rand2] == 1)
                {
                    if (GameManager.Instance.P_Score + 11 > 21)
                    {
                        GameManager.Instance.P_Score += 1;
                    }
                    else
                    {
                        GameManager.Instance.P_Score += 11;
                    }
                }
                else
                {
                    GameManager.Instance.P_Score += Gachalist[rand][rand2];
                }
            }


            // 스프라이트 찾기
            string shape = "";
       
            if (Gachalist[rand] == Heart) {
                CardNum = Gachalist[rand][rand2] - 1;
                GameManager.Instance.MiniCard = "minicards_" + CardNum;
                shape = "1.2 Poker cards_" + CardNum;
            }
            else if (Gachalist[rand] == Diamond) {
                CardNum = 14 + Gachalist[rand][rand2];
                miniCardNum = 12 + Gachalist[rand][rand2];
                GameManager.Instance.MiniCard = "minicards_" + miniCardNum;
                shape = "1.2 Poker cards_" + CardNum;
            }
            else if (Gachalist[rand] == Spade) {
                CardNum = 27 + Gachalist[rand][rand2];
                miniCardNum = 25 + Gachalist[rand][rand2];
                GameManager.Instance.MiniCard = "minicards_" + miniCardNum;
                shape = "1.2 Poker cards_" + CardNum;
            }
            else if (Gachalist[rand] == Clova) {
                CardNum = 40 + Gachalist[rand][rand2];
                miniCardNum = 38 + Gachalist[rand][rand2];
                GameManager.Instance.MiniCard = "minicards_" + miniCardNum;
                shape = "1.2 Poker cards_" + CardNum;
            }

            //while (true)
            //{
            //    cardDisplayImage = GetComponentInChildren<Image>();
            //    if(cardDisplayImage.name == "Original")
            //    {
            //        cardDisplayImage.name = "TEST";
            //        break;
            //    }
            //}


            Sprite cardSprite = Resources.Load<Sprite>(shape);

            // 카드 표시

            //if (cardSprite != null && !GameManager.Instance.Dealer)
            //{
            //    if(GameManager.Instance.dealer_count > 0)
            //    {
            //        GameManager.Instance.Dealer_2 = cardSprite;
            //    }
            //    else
            //    {
            //        cardDisplayImage.sprite = cardSprite;
            //    }
            //}
            //else if(cardSprite != null && GameManager.Instance.Dealer)
            //{
            //    cardDisplayImage_D.sprite = cardSprite;
            //}
            //else
            //{
            //    Debug.LogError(shape + " 이름의 카드 이미지X");
            //}

            if (cardSprite != null)
            {
                targetImage.sprite = cardSprite;
            }
            else
            {
                Debug.LogError(shape + " 이름의 카드 이미지X");
            }

            Debug.Log("뽑은 카드 숫자: " + Gachalist[rand][rand2] + ", 플레이어 점수: " + GameManager.Instance.P_Score + ", 딜러 점수: " + GameManager.Instance.D_Score);

            // 제거
            Gachalist[rand].RemoveAt(rand2);
        }
    }

    //public void SpawnCard(Sprite cardsprite)
    //{
    //    Sprite MinicardSprite = cardsprite;

    //    Vector2 size = new Vector2(144, 192);

    //    GameObject newImageObject = new GameObject("P_card");

    //    newImageObject.transform.SetParent(this.transform, false);

    //    Image imageComponent = newImageObject.AddComponent<Image>();

    //    imageComponent.sprite = MinicardSprite;

    //    RectTransform rectTransform = newImageObject.GetComponent<RectTransform>();
    //    rectTransform.sizeDelta = size;

    //    if (MinicardSprite != null)
    //    {
    //        newImageObject.name = "Original";
    //    }
    //}

    public Image SpawnCard(Sprite cardSprite)
    {
        Vector2 size = new Vector2(144, 192);
        GameObject newImageObject = new GameObject("Card");
        newImageObject.transform.SetParent(this.transform, false);
        Image imageComponent = newImageObject.AddComponent<Image>();
        imageComponent.sprite = cardSprite;
        RectTransform rectTransform = newImageObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = size;
        return imageComponent;
    }


    //private IEnumerator CardFlipCoroutine()
    //{
    //    while (GameManager.Instance.Hit)
    //    {
    //        if(transform.childCount > 1)
    //        {
    //            Count = 1;
    //        }
    //        SpawnCard(cardDisplaySprite);
    //        yield return new WaitForSeconds(1.0f);
    //        if (!GameManager.Instance.Dealer)
    //        {
    //            Gacha();
    //            yield return new WaitForSeconds(1.0f);
    //        }
    //        yield return new WaitForSeconds(1.0f);
    //        Count++;
    //        if(Count > 1)
    //        {
    //            GameManager.Instance.Hit = false;
    //        }
    //    }

    //    if (GameManager.Instance.dealer_count > 0 && GameManager.Instance.Dealer)
    //    {
    //        if (GameManager.Instance.WhatChoose)
    //        {
    //            Gacha();
    //        }
    //    }
    //}

    public void PlayerStart()
    {
        GameManager.Instance.Dealer = false;
        if (start)
        {
            StartCoroutine(PlayerCardDownForStart());
            start = false;
        }
        else
        {
            StartCoroutine(PlayerCardDownJust());
        }
    }

    private IEnumerator PlayerCardDownForStart()
    {
        for (int i = 0; i < 2; i++)
        {
            Image newCardImage = SpawnCard(cardDisplaySprite);
            yield return new WaitForSeconds(1.0f);
            Gacha(newCardImage);
            GameManager.Instance.minicards.SpawnMini();
            yield return new WaitForSeconds(1.0f);
            if(GameManager.Instance.P_Score == 21)
            {
                GameManager.Instance.BlackJack_P = true;
            }
        }
        GameManager.Instance.Dealer = true;
    }

    private IEnumerator PlayerCardDownJust()
    {
        Image newCardImage = SpawnCard(cardDisplaySprite);
        yield return new WaitForSeconds(1.0f);
        Gacha(newCardImage);
        GameManager.Instance.minicards.SpawnMini();
        GameManager.Instance.Dealer = true;
    }

    public Image DealerSecondCard;

    private IEnumerator DealerStart()
    {
        Image newCardImage = SpawnCard(cardDisplaySprite);
        yield return new WaitForSeconds(1.0f);
        Gacha(newCardImage);
        GameManager.Instance.minicards_d.SpawnMiniD();
        yield return new WaitForSeconds(1.0f);
        DealerSecondCard = SpawnCard(cardDisplaySprite);
    }
}