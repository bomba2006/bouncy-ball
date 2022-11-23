using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinpickup : MonoBehaviour
{
    scoresystem script;
    
    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.Find("Circle").GetComponent<scoresystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            script.addscore(10);
            Destroy(gameObject);
            
        }
        
    }
}
