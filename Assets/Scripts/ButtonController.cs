using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button myButton;

    public Cheat myCheat;

    public Card card;

    private void Awake()
    {
        myButton = GetComponent<Button>();
    }

    void Start()
    {
        if (myButton != null)
        {
            myButton.onClick.RemoveAllListeners();
            myButton.onClick.AddListener(OnHitButtonClicked);
        }
    }

    public void OnHitButtonClicked()
    {
        if (GameManager.Instance.Round > 2 && !card.start)
        {
            myCheat.OnPlayerHit();
        }
        else
        {
            card.PlayerStart();
        }
    }

}
