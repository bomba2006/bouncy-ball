using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Transform player;
    Rigidbody2D rdenemy;
    
    bool a=false;
    Vector2 startpos;
    Vector2 endpos;
    Vector2 waittime;
    public float difficult = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Circle").transform;   
        rdenemy = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
       
    void Update()
    {
        
        if (!a) 
        {
            startpos = transform.position;
            endpos = player.position;
            waittime = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            a = true;
        }
        if (a)
        {
            rdenemy.AddForce((endpos - (startpos + waittime)) * difficult);
        }

       
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag =="border")
        {
            rdenemy.velocity = Vector2.zero;
            a = false;
        }
    }
}
