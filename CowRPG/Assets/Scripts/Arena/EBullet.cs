using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    public bool Invincible;
    public float Speed;
    public float BulletLife;
    public float Damage;
    public GameObject Death;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * Speed;
        Destroy(gameObject, BulletLife);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Invincible == false)
        {
            collision.gameObject.SendMessage("ApplyPDMG", Damage);
            GameObject GO = Instantiate(Death, transform.position, Quaternion.identity);
            Destroy(GO, 2);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Wall" && Invincible == false)
        {
            GameObject GO = Instantiate(Death, transform.position, Quaternion.identity);
            Destroy(GO, 2);
            Destroy(gameObject);
        }

        else if (Invincible == true)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.SendMessage("ApplyPDMG", Damage);
                GameObject GO = Instantiate(Death, transform.position, Quaternion.identity);
                Destroy(GO, 2);
            }
        }
    }
}