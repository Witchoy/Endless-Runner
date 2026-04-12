using System;
using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    public static int coinCount = 0;

    [SerializeField] private GameObject coinDisplay;

    private void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "Coins: " + coinCount.ToString();
    }
}
