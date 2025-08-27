using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Cheat : MonoBehaviour
{
    public Card cardScript;

    private struct CardLocation
    {
        public int suitIndex;
        public int cardValue;
    }

    public void OnPlayerHit()
    {
        StartCoroutine(HighCardDrawCoroutine());
    }

    private IEnumerator HighCardDrawCoroutine()
    {
        cardScript.hit.interactable = false;
        cardScript.stay.interactable = false;

        List<CardLocation> highCards = new List<CardLocation>();
        for (int i = 0; i < cardScript.Gachalist.Count; i++)
        {
            List<int> currentSuit = cardScript.Gachalist[i];
            foreach (int value in currentSuit)
            {
                if (value >= 10)
                {
                    highCards.Add(new CardLocation { suitIndex = i, cardValue = value });
                }
            }
        }

        if (highCards.Count == 0)
        {
            cardScript.PlayerStart();
            yield break;
        }

        Image newCardImage = cardScript.SpawnCard(cardScript.cardDisplaySprite);
        yield return new WaitForSeconds(0.5f);

        int rand = Random.Range(0, highCards.Count);
        CardLocation chosenCard = highCards[rand];


        GameManager.Instance.P_Score += 10;

        string shape = "";
        int CardNum = 0;
        int miniCardNum = 0;

        List<int> chosenSuitList = cardScript.Gachalist[chosenCard.suitIndex];
        if (chosenSuitList == cardScript.Heart)
        {
            CardNum = chosenCard.cardValue - 1;
            GameManager.Instance.MiniCard = "minicards_" + CardNum;
            shape = "1.2 Poker cards_" + CardNum;
        }
        else if (chosenSuitList == cardScript.Diamond)
        {
            CardNum = 14 + chosenCard.cardValue;
            miniCardNum = 12 + chosenCard.cardValue;
            GameManager.Instance.MiniCard = "minicards_" + miniCardNum;
            shape = "1.2 Poker cards_" + CardNum;
        }
        else if (chosenSuitList == cardScript.Spade)
        {
            CardNum = 27 + chosenCard.cardValue;
            miniCardNum = 25 + chosenCard.cardValue;
            GameManager.Instance.MiniCard = "minicards_" + miniCardNum;
            shape = "1.2 Poker cards_" + CardNum;
        }
        else if (chosenSuitList == cardScript.Clova)
        {
            CardNum = 40 + chosenCard.cardValue;
            miniCardNum = 38 + chosenCard.cardValue;
            GameManager.Instance.MiniCard = "minicards_" + miniCardNum;
            shape = "1.2 Poker cards_" + CardNum;
        }

        Sprite cardSprite = Resources.Load<Sprite>(shape);
        if (cardSprite != null)
        {
            newCardImage.sprite = cardSprite;
        }

        cardScript.Gachalist[chosenCard.suitIndex].Remove(chosenCard.cardValue);

        GameManager.Instance.minicards.SpawnMini();

        cardScript.hit.interactable = true;
        cardScript.stay.interactable = true;
    }

}
