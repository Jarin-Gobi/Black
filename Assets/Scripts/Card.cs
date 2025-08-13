using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    // 카드 보여주기
    public Image cardDisplayImage;

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

    public void Gacha()
    {
        // 모양 선택
        int rand = Random.Range(0, Gachalist.Count);

        // 카드 개수 확인
        if (Gachalist[rand].Count > 0)
        {
            int CardNum = 0;
            // 카드 뽑기
            int rand2 = Random.Range(0, Gachalist[rand].Count);

            string shape = "";
       
            if (Gachalist[rand] == Heart) {
                CardNum = Gachalist[rand][rand2] - 1;
                shape = "1.2 Poker cards_" + CardNum;
            }
            else if (Gachalist[rand] == Diamond) {
                CardNum = 14 + Gachalist[rand][rand2];
                shape = "1.2 Poker cards_" + CardNum;
            }
            else if (Gachalist[rand] == Spade) {
                CardNum = 27 + Gachalist[rand][rand2];
                shape = "1.2 Poker cards_" + CardNum;
            }
            else if (Gachalist[rand] == Clova) {
                CardNum = 40 + Gachalist[rand][rand2];
                shape = "1.2 Poker cards_" + CardNum;
            }


            Sprite cardSprite = Resources.Load<Sprite>(shape);

            // 카드 표시
            if (cardSprite != null)
            {
                cardDisplayImage.sprite = cardSprite;

            }
            else
            {
                Debug.LogError(shape + " 이름의 카드 이미지X");
            }

            Debug.Log(Gachalist[rand][rand2]);

            // 제거
            Gachalist[rand].RemoveAt(rand2);
        }
        else
        {
            Gachalist.RemoveAt(rand);

            // 남아있나?
            if (Gachalist.Count > 0)
            {
                Gacha();
            }
            else if(Gachalist.Count == 0)
            {
                Debug.Log("카드X");
                return;
            }
        }
    }
}