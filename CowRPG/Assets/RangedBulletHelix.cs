using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RangedBulletHelix : MonoBehaviour
{

    public float Speed;
    public float VertSpeed;
    public float Frequency;
    public float BulletLife;
    float Timer;
    public float Damage;
    public GameObject Death;
    Rigidbody2D Mybody;
    float Dir;

    // Use this for initialization
    void Start()
    {
        Mybody = GetComponent<Rigidbody2D>();
        Mybody.velocity = transform.right * Speed;
        Destroy(gameObject, BulletLife);

        Dir = -1;
        Mybody.velocity += Vector2.up * VertSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer >= 2/Frequency)
        {
            Timer = 0;
            Dir = Dir * -1;
        }
        
        Mybody.velocity += Dir * (Vector2.up * (Frequency * VertSpeed) * Time.deltaTime);


        Timer += Time.deltaTime;
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
        Mybody.velocity = Mybody.velocity + (Vector2)transform.up * VertSpeed;
    }
}