using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
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
        int rand = Random.Range(0, Gachalist.Count);
        int rand2 = Random.Range(0, Gachalist[rand].Count);
        print(rand);
        print(Gachalist[rand][rand2]);
        Gachalist[rand].RemoveAt(rand2);
    }
}
