using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RangedBulletHelix : MonoBehaviour
{

    public float Speed;
    public float VertAcceleration;
    public float InitialVerticalVelocity;
    public float BulletLife;
    float Timer;
    float Timer2;
    public float Damage;
    public GameObject Death;
    Rigidbody2D Mybody;

    static bool Up;
    float Dir;
    Vector2 StartPos;

    // Use this for initialization
    void Start()
    {
        Mybody = GetComponent<Rigidbody2D>();
        Mybody.velocity = transform.right * Speed;
        Destroy(gameObject, BulletLife);


        StartPos = transform.position;

        if(Up == true)
        {
            Dir = -1;
            Mybody.velocity += (Vector2)transform.up * InitialVerticalVelocity;
        }
        else if(Up == false)
        {
            Dir = 1;
            Mybody.velocity += -(Vector2)transform.up * InitialVerticalVelocity;
        }

        Up = !Up;
        Timer = 0;
        Timer2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer >= (2*InitialVerticalVelocity)/VertAcceleration)
        {
            
            Dir = Dir * -1;

            Mybody.velocity -= (Vector2)transform.up * Vector2.Dot( (Vector2)transform.up, Mybody.velocity );
            Mybody.velocity += (-Dir)*(Vector2)transform.up * InitialVerticalVelocity;
            transform.position = StartPos + Speed * Timer2 * (Vector2)transform.right;

            Timer = 0;
        }
        
        //Frequency = 2*InitialVerticalVelocity/VertAcceleration
        //Height = (InitialVeticalVelocity^2)/(2*VertAcceleration)

        Mybody.velocity += Dir * ((Vector2)transform.up * VertAcceleration * Time.deltaTime);
        
        Timer += Time.deltaTime;
        Timer2 += Time.deltaTime;
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("ApplyDMG", Damage);
            GameObject GO = Instantiate(Death, transform.position, Quaternion.identity);
            Destroy(GO, 2);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            GameObject GO = Instantiate(Death, transform.position, Quaternion.identity);
            Destroy(GO, 2);
            Destroy(gameObject);
        }
    }

    void BulletUp()
    {
        Mybody.velocity = Mybody.velocity + (Vector2)transform.up * VertAcceleration;
    }
}