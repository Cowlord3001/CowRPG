using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : MonoBehaviour
{

    public float Speed;
    public float PDist;
    GameObject Player;
    Rigidbody2D MyBody;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        MyBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Distance = (Player.transform.position - transform.position);

        if (Distance.magnitude < PDist - 1)
        {
            MyBody.AddForce(-transform.right * Speed);
        }
        else if (Distance.magnitude > PDist)
        {
            MyBody.AddForce(transform.right * Speed);
        }
        else
        {
            if (Distance.x < 0)
            {
                float Angle = Vector2.Dot(MyBody.velocity, transform.right);
                MyBody.velocity = MyBody.velocity + Angle * Vector2.right;
            }
            else
            {
                float Angle = Vector2.Dot(MyBody.velocity, transform.right);
                MyBody.velocity = MyBody.velocity - Angle * Vector2.right;
            }
        }
    }
}
