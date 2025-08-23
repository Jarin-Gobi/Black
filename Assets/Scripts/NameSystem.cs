using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameSystem : MonoBehaviour
{
    public Button OkayButton;
    public TMP_InputField nameInputField;
    void Start()
    {
        if (!GameManager.Instance.NewGame)
        {
            gameObject.SetActive(false);
        }
        OkayButton.onClick.AddListener(PlayerNameCheck);
    }

    public void PlayerNameCheck()
    {
        GameManager.Instance.NewGame = false;
        GameManager.Instance.playerName = nameInputField.text;
        gameObject.SetActive(false);
    }
}
