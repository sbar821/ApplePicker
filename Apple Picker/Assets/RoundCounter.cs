using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoundCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int round = 1;

    private Text uiText;

    void Start()
    {
        uiText = GetComponent<Text>();
    }

    void Update()
    {
        GameObject[] baskets = GameObject.FindGameObjectsWithTag("Basket");

        int totalRounds = 4;

        int remainingBaskets = baskets.Length;

        int destroyedBaskets = totalRounds - remainingBaskets;

        round = Mathf.Clamp(destroyedBaskets + 1, 1, totalRounds);

        uiText.text = "Round: " + round.ToString("#,0");
    }
}
