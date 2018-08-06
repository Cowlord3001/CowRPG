﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RangedBulletHelix : MonoBehaviour
{

    public float Speed;
    public float VertSpeed;
    public float BulletLife;
    public float Damage;
    public GameObject Death;
    Rigidbody2D Mybody;

    // Use this for initialization
    void Start()
    {
        Mybody = GetComponent<Rigidbody2D>();
        Mybody.velocity = transform.right * Speed;
        Destroy(gameObject, BulletLife);
    }

    // Update is called once per frame
    void Update()
    {
        //Mybody.velocity += + transform.up * 
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
}