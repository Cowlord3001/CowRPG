using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour {

    public float Speed;
    Rigidbody2D MyBody;
    bool freeze;

	// Use this for initialization
	void Start () {
        MyBody = GetComponent<Rigidbody2D>();
        freeze = false;
	}

    public void togglefreeze()
    {
        freeze = !freeze;
    }
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.A))
        {
            x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            x = 1;
        }
        else
        {
            x = 0;
        }

        float y = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.S))
        {
            y = -1;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            y = 1;
        }
        else
        {
            y = 0;
        }

        if (freeze == false)
        {
            if (x > 0 && y > 0)
            {
                MyBody.velocity = (Vector2.right + Vector2.up).normalized * Speed;
            }

            else if (x > 0 && y < 0)
            {
                MyBody.velocity = (Vector2.right + Vector2.down).normalized * Speed;
            }

            else if (x < 0 && y > 0)
            {
                MyBody.velocity = (Vector2.left + Vector2.up).normalized * Speed;
            }

            else if (x < 0 && y < 0)
            {
                MyBody.velocity = (Vector2.left + Vector2.down).normalized * Speed;
            }

            else if (x > 0)
            {
                MyBody.velocity = Vector2.right * Speed;
            }

            else if (x < 0)
            {
                MyBody.velocity = Vector2.left * Speed;
            }

            else if (y < 0)
            {
                MyBody.velocity = Vector2.down * Speed;
            }

            else if (y > 0)
            {
                MyBody.velocity = Vector2.up * Speed;
            }

            else
            {
                MyBody.velocity = Vector2.zero;
            }
        }
        else
        {
            MyBody.velocity = Vector2.zero;
        }
    }
}
