using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Minicards : MonoBehaviour
{
    private void Start()
    {
        // GameManager 인스턴스를 찾아서 자기 자신을 등록
        if (GameManager.Instance != null)
        {
            if (gameObject.name == "Minicards_D")
            {
                GameManager.Instance.minicards_d = this;
            }
            else
            {
                GameManager.Instance.minicards = this;
            }
        }
    }

    public void SpawnMini()
    {
        if(GameManager.Instance.Dealer)
        {
            return;
        }

        Sprite MinicardSprite = Resources.Load<Sprite>(GameManager.Instance.MiniCard);

        Vector2 size = new Vector2(56.25f, 82.5f);

        GameObject newImageObject = new GameObject("P_minicard");

        newImageObject.transform.SetParent(this.transform, false);

        Image imageComponent = newImageObject.AddComponent<Image>();

        imageComponent.sprite = MinicardSprite;

        RectTransform rectTransform = newImageObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = size;

        if (MinicardSprite != null)
        {
            newImageObject.name = MinicardSprite.name;
        }
    }

    public void SpawnMiniD()
    {
        if (!GameManager.Instance.Dealer)
        {
            return;
        }

        Sprite MinicardSprite = Resources.Load<Sprite>(GameManager.Instance.MiniCard);

        Vector2 size = new Vector2(56.25f, 82.5f);

        GameObject newImageObject = new GameObject("D_minicard");

        newImageObject.transform.SetParent(this.transform, false);

        Image imageComponent = newImageObject.AddComponent<Image>();

        imageComponent.sprite = MinicardSprite;

        RectTransform rectTransform = newImageObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = size;

        if (MinicardSprite != null)
        {
            newImageObject.name = MinicardSprite.name;
        }
    }

    //public int order = 0;
    //public GameObject minicardImage;

    ////public Image minicardDisplayImage_D;
    ////public Image minicardDisplayImage;

    //Sprite MinicardSprite = Resources.Load<Sprite>(GameManager.Instance.MiniCard);

    //public void Mini()
    //{
    //    if (GameManager.Instance.Dealer)
    //    {
    //        return;
    //    }

    //    order++;

    //    for(int i = transform.childCount - 1; i >= 0; i--)
    //    {
    //        if (GameManager.Instance.GameOver)
    //        {
    //            DestroyImmediate(transform.GetChild(i).gameObject);
    //        }
    //    }

    //    for(int i = 0; i < order; i++)
    //    {
    //        GameObject newImageObject = Instantiate(minicardImage, transform);

    //        Image image = newImageObject.GetComponent<Image>();
    //        RectTransform rectTransform = newImageObject.GetComponent<RectTransform>();

    //        if (image == null || rectTransform == null)
    //        {
    //            Debug.LogError("Image, RectangleX", newImageObject);
    //            continue;
    //        }

    //        image.sprite = MinicardSprite;
    //        rectTransform.sizeDelta = new Vector2(56.25f, 82.5f);

    //        if (MinicardSprite != null)
    //        {
    //            newImageObject.name = MinicardSprite.name;
    //        }
    //    }
    //}
}
