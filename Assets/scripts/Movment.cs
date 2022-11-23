using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Movment : MonoBehaviour
{
    Rigidbody2D Circle;
    float horizontal;
    float vertical;
    float slow=0.99f;
    public float Speed = 5f;
    public float wait;
    Vector2 preVel;
    bool dashing;
    bool slowwing;
    public AudioSource dashm;
    public GameObject effect;
    
    // Start is called before the first frame update
    void Start()
    {
        wait = Time.time;
        Circle = GetComponent<Rigidbody2D>();
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        
    }

    // Update is called once per frame
    void Update()
    {
       
        smoothmove();




    }
    private void FixedUpdate()
    {
        if (horizontal == 0 && vertical == 0)
        {
            if (slowwing)
            {
                slow = 0.99f;
                slowwing = false;
            }
            Circle.velocity = Circle.velocity * slow;
            slow -= 0.001f;
        }
        else if (horizontal == 0)
        {
            Circle.velocity = new Vector2(Circle.velocity.x * slow, Circle.velocity.y);
            slow -= 0.001f;
            slowwing = true;
        }
        else if (vertical == 0)
        {
            Circle.velocity = new Vector2(Circle.velocity.x, Circle.velocity.y * slow);
            slow -= 0.001f;
            slowwing = true;
        }
        else
        {
            slow = 0.99f;
            slowwing = false;
        }
        {

        }

    }//slowing down
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("Menu");
    }
    public void smoothmove()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        
        Circle.AddForce(new Vector2(horizontal * Speed, vertical * Speed));
        
        clamp();
        
        if (Input.GetKeyDown(KeyCode.LeftShift)&&Time.time-wait>2)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            dashm.Play();
            preVel = Circle.velocity;
            Instantiate(effect, transform.position, Quaternion.identity);
            Circle.velocity = new Vector2(horizontal, vertical) * 30f;
            wait = Time.time;
            dashing = false;
            Invoke("stop", 0.2f);
            
            //Circle.velocity = Vector2.zero;
        }//dash ability
    }//movement system
    void clamp()
    {
        if (dashing)
        {
            if (Circle.velocity.x > 40f)
            {
                Circle.velocity = new Vector2(15f, Circle.velocity.y);

            }
            if (Circle.velocity.x < -40f)
            {
                Circle.velocity = new Vector2(-15f, Circle.velocity.y);

            }
            if (Circle.velocity.y > 40f)
            {
                Circle.velocity = new Vector2(Circle.velocity.x, 15f);

            }
            if (Circle.velocity.y < -40f)
            {
                Circle.velocity = new Vector2(Circle.velocity.x, -15f);

            }
        }
            
        
        
    }//limit the velocity
    void stop()
    {
        Circle.velocity = Vector2.zero;
        dashing = true;
    }
}
