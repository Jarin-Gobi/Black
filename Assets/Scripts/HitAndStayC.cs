using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAndStayC : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.Instance != null)
        {
            if (gameObject.name == "HIT")
            {
                GameManager.Instance.Hit = gameObject;
            }
            else
            {
                GameManager.Instance.Stay = gameObject;
            }
        }
    }
}
