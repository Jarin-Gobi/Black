using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    // ī�� �����ֱ�
    public Image cardDisplayImage_D;
    public Image cardDisplayImage;

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
        Gachalist.Add(Spade);
        Gachalist.Add(Heart);
        Gachalist.Add(Clova);
        Gachalist.Add(Diamond);
    }

    public void Gacha()
    {
        // ��� ����
        int rand = Random.Range(0, Gachalist.Count);

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
                        Debug.Log(GameManager.Instance.D_Score + "+ 1 or +11");
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
                        Debug.Log(GameManager.Instance.D_Score + "+ 1 or +11");
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

            while (true)
            {
                cardDisplayImage = GetComponentInChildren<Image>();
                if(cardDisplayImage.name == "Original")
                {
                    cardDisplayImage.name = "TEST";
                    break;
                }
            }


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
                cardDisplayImage.sprite = cardSprite;
            }
            else
            {
                Debug.LogError(shape + " �̸��� ī�� �̹���X");
            }

            Debug.Log(Gachalist[rand][rand2]);

            // ����
            Gachalist[rand].RemoveAt(rand2);
        }
        else
        {
            Gachalist.RemoveAt(rand);

            // �����ֳ�?
            if (Gachalist.Count > 0)
            {
                Gacha();
            }
            else if(Gachalist.Count == 0)
            {
                Debug.Log("ī��X");
                return;
            }
        }
    }

    public void SpawnCard(Sprite cardsprite)
    {
        Sprite MinicardSprite = cardsprite;

        Vector2 size = new Vector2(144, 192);

        GameObject newImageObject = new GameObject("P_card");

        newImageObject.transform.SetParent(this.transform, false);

        Image imageComponent = newImageObject.AddComponent<Image>();

        imageComponent.sprite = MinicardSprite;

        RectTransform rectTransform = newImageObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = size;

        if (MinicardSprite != null)
        {
            newImageObject.name = "Original";
        }
    }

    public int Count = 0;

    private IEnumerator CardFlipCoroutine()
    {
        while (GameManager.Instance.Hit)
        {
            if(transform.childCount > 1)
            {
                Count = 1;
            }
            SpawnCard(cardDisplaySprite);
            yield return new WaitForSeconds(1.0f);
            if (!GameManager.Instance.Dealer)
            {
                Gacha();
                yield return new WaitForSeconds(1.0f);
            }
            yield return new WaitForSeconds(1.0f);
            Count++;
            if(Count > 1)
            {
                GameManager.Instance.Hit = false;
            }
        }

        if (GameManager.Instance.dealer_count > 0 && GameManager.Instance.Dealer)
        {
            if (GameManager.Instance.WhatChoose)
            {
                Gacha();
            }
        }
    }

    public void GachaStart()
    {
        StartCoroutine(CardFlipCoroutine());
    }
}