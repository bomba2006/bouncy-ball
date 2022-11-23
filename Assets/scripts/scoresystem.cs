using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoresystem : MonoBehaviour
{

    public int score = 0;
    float count,count1;
    public TextMeshProUGUI textDisplay;
    public GameObject coin;
    void Start()
    {
        
    }

    void Update()
    {
        timescore();
        coinscore();


    }
    
    void timescore()
    {
        if (count > 1)
        {
            score++;
            textDisplay.SetText("Score:" + score);
            count = 0;
        }
        count += Time.deltaTime;
    }
    void coinscore()
    {
        if (count1 > 5)
        {
            Instantiate(coin, new Vector3(Random.Range(-15.85f, 15.85f), Random.Range(-17.75f, 17.75f), 0), Quaternion.identity);
            count1 = 0;
        }
        count1 += Time.deltaTime;
    }
    public void addscore(int _score)
    {
        score += _score;
    }
    
}
