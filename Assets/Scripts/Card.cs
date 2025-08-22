using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Button hit;
    public Button stay;
    public Card Card_D;

    public bool start = true;

    // �⺻ ī�� �̹���
    public Sprite cardDisplaySprite;

    // ī��
    public List<List<int>> Gachalist = new List<List<int>>();
    public List<int> Spade = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
    public List<int> Heart = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
    public List<int> Clova = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
    public List<int> Diamond = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

    private void Awake()
    {
        GameManager.Instance.GetMoney = false;
        GameManager.Instance.GameOver = false;
        GameManager.Instance.P_Score = 0;
        GameManager.Instance.D_Score = 0;
        hit.interactable = true;
        stay.interactable = true;
        Gachalist.Add(Spade);
        Gachalist.Add(Heart);
        Gachalist.Add(Clova);
        Gachalist.Add(Diamond);
    }

    public void Gacha(Image targetImage)
    {
        if (Gachalist.Count == 0)
        {
            Debug.Log("ī��X");
            return;
        }

        int rand = 0;
        while (true)
        {
            // ��� ����
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
                    //Debug.Log("��� ī�尡 �����Ǿ����ϴ�.");
                    return;
                }
            }
        }

        //int rand = Random.Range(0, Gachalist.Count);

        // ī�� ���� Ȯ��
        if (Gachalist[rand].Count > 0)
        {
            int miniCardNum = 0;
            int CardNum = 0;
            // ī�� �̱�
            int rand2 = Random.Range(0, Gachalist[rand].Count);

            //�÷��̾�, ���� ����
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


            // ��������Ʈ ã��
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

            // ī�� ǥ��

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
            //    Debug.LogError(shape + " �̸��� ī�� �̹���X");
            //}

            if (cardSprite != null)
            {
                targetImage.sprite = cardSprite;
            }
            else
            {
                //Debug.LogError(shape + " �̸��� ī�� �̹���X");
            }

            //Debug.Log("���� ī�� ����: " + Gachalist[rand][rand2] + ", �÷��̾� ����: " + GameManager.Instance.P_Score + ", ���� ����: " + GameManager.Instance.D_Score);

            // ����
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
        Vector2 size = new Vector2(108, 144);
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
    //    while (GameManager.Instance.re)
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
    //            GameManager.Instance.re = false;
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
        hit.interactable = false;
        stay.interactable = false;
        for (int i = 0; i < 2; i++)
        {
            Image newCardImage = SpawnCard(cardDisplaySprite);
            yield return new WaitForSeconds(0.5f);
            Gacha(newCardImage);
            GameManager.Instance.minicards.SpawnMini();
            yield return new WaitForSeconds(0.5f);
            //if(GameManager.Instance.P_Score == 21)
            //{
            //    GameManager.Instance.BlackJack_P = true;
            //}
        }
        GameManager.Instance.Dealer = true;
        StartCoroutine(Card_D.DealerStart());
    }

    private IEnumerator PlayerCardDownJust()
    {
        hit.interactable = false;
        stay.interactable = false;
        Image newCardImage = SpawnCard(cardDisplaySprite);
        yield return new WaitForSeconds(0.5f);
        Gacha(newCardImage);
        GameManager.Instance.minicards.SpawnMini();
        hit.interactable = true;
        stay.interactable = true;
    }

    public Image DealerSecondCard;

    private IEnumerator DealerStart()
    {
        Image newCardImage = SpawnCard(cardDisplaySprite);
        yield return new WaitForSeconds(0.5f);
        Gacha(newCardImage);
        GameManager.Instance.minicards_d.SpawnMiniD();
        yield return new WaitForSeconds(0.5f);
        DealerSecondCard = SpawnCard(cardDisplaySprite);
        GameManager.Instance.Dealer = false;
        hit.interactable = true;
        stay.interactable = true;
    }

    //public void StartDealer()
    //{
    //    GameManager.Instance.Dealer = true;
    //    StartCoroutine(DealerStart());
    //}

    public void DealerLoop()
    {
        hit.interactable = false;
        stay.interactable = false;
        GameManager.Instance.Dealer = true;
        StartCoroutine(DealerAI());
    }

    private IEnumerator DealerAI()
    {
        yield return new WaitForSeconds(0.5f);
        Gacha(DealerSecondCard);
        GameManager.Instance.minicards_d.SpawnMiniD();
        while (true)
        {
            if(GameManager.Instance.D_Score >= 17)
            {
                GameManager.Instance.Dealer = false;
                break;
            }
            yield return new WaitForSeconds(0.5f);
            Image newCardImage = SpawnCard(cardDisplaySprite);
            yield return new WaitForSeconds(0.5f);
            Gacha(newCardImage);
            GameManager.Instance.minicards_d.SpawnMiniD();
        }
        GameManager.Instance.GameOver = true;
    }
}