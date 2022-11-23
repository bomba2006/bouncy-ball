using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public float dif;
    public float a=0;
    public TextMeshProUGUI textDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayClick()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void DifficultClick()
    {
        switch (a)
        {
            case 1f:
                a = 2;
                dif = 0.03f;
                textDisplay.SetText("Difficult:Easy");
                break;
            case 2f:
                a = 3;
                dif = 0.06f;
                textDisplay.SetText("Difficult:Medium");
                break;
            case 3f:
                a = 1;
                dif = 0.1f;
                textDisplay.SetText("Difficult:Hard");
                break;
            default:
                break;
        }



    }
}
