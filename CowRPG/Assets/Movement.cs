using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    //Current Square Character is On
    int xpos;
    int ypos;

    //TargetSquare
    int xtar, ytar;

    public float speed;

    Vector2 start;
    Vector2 target;
    bool moving = false;

    // Use this for initialization
    void Awake () {
        xpos = (int)transform.position.x;
        ypos = (int)transform.position.y;
        xtar = 0;
        ytar = 0;
        start = transform.position;
        target = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        //Debug.Log(xpos);
        if(!moving)
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                ytar = ypos + 1;
                xtar = xpos - 1;
                if (CanMove(xtar, ytar))
                {
                    moving = true;
                    start = new Vector2(xpos, ypos);
                    target = new Vector2(xtar, ytar);
                }
                else
                {
                    ChangeMove(-1, 0);
                }
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                ytar = ypos + 1;
                xtar = xpos + 1;
                if (CanMove(xtar, ytar))
                {
                    moving = true;
                    start = new Vector2(xpos, ypos);
                    target = new Vector2(xtar, ytar);
                }
                else
                {
                    ChangeMove(1, 0);
                }
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                ytar = ypos - 1;
                xtar = xpos - 1;
                if (CanMove(xtar, ytar))
                {
                    moving = true;
                    start = new Vector2(xpos, ypos);
                    target = new Vector2(xtar, ytar);
                }
                else
                {
                    ChangeMove(-1, 0);
                }
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                ytar = ypos - 1;
                xtar = xpos + 1;
                if (CanMove(xtar, ytar))
                {
                    moving = true;
                    start = new Vector2(xpos, ypos);
                    target = new Vector2(xtar, ytar);
                }
                else
                {
                    ChangeMove(1, 0);
                }
            }


            else if (Input.GetKey(KeyCode.W))
            {
                ytar = ypos + 1;
                xtar = xpos;
                if (CanMove(xtar, ytar))
                {
                    moving = true;
                    start = new Vector2(xpos, ypos);
                    target = new Vector2(xtar, ytar);
                }
                else
                {
                    ChangeMove(0, 1);
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                ytar = ypos - 1;
                xtar = xpos;
                if (CanMove(xtar, ytar))
                {
                    moving = true;
                    start = new Vector2(xpos, ypos);
                    target = new Vector2(xtar, ytar);
                }
                else
                {
                    ChangeMove(0, -1);
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                xtar = xpos - 1;
                ytar = ypos;
                if (CanMove(xtar, ytar))
                {
                    moving = true;
                    start = new Vector2(xpos, ypos);
                    target = new Vector2(xtar, ytar);
                }
                else
                {
                    ChangeMove(-1, 0);
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                xtar = xpos + 1;
                ytar = ypos;
                if (CanMove(xtar, ytar))
                {
                    moving = true;
                    start = new Vector2(xpos, ypos);
                    target = new Vector2(xtar, ytar);
                }
                else
                {
                    ChangeMove(1,0);
                }
            }

        }

        if(moving)
            transform.position = (Vector2)transform.position + (target - start) * speed * Time.deltaTime;

        if (moving && Mathf.Abs(transform.position.x - xtar) < .1 && Mathf.Abs(transform.position.y - ytar) < .1)
        {
            transform.position = new Vector2(xtar, ytar);
            moving = false;
            xpos = xtar;
            ypos = ytar;
        }

    }

    bool CanMove(int x, int y)
    {
        Vector2 dir = new Vector2(x, y);

        dir = dir - (Vector2)transform.position;
        Debug.DrawRay(transform.position, dir, Color.green, 800f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir ,1f);
        if (hit.collider != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void ChangeMove(int x, int y)
    {
        if (x > 0 && Input.GetKey(KeyCode.W))
        {
            ytar = ypos + 1;
            xtar = xpos;
            if (CanMove(xtar, ytar))
            {
                moving = true;
                start = new Vector2(xpos, ypos);
                target = new Vector2(xtar, ytar);
            }
        }

        if (x > 0 && Input.GetKey(KeyCode.S))
        {
            ytar = ypos - 1;
            xtar = xpos;
            if (CanMove(xtar, ytar))
            {
                moving = true;
                start = new Vector2(xpos, ypos);
                target = new Vector2(xtar, ytar);
            }
        }

        if (x < 0 && Input.GetKey(KeyCode.W))
        {
            ytar = ypos + 1;
            xtar = xpos;
            if (CanMove(xtar, ytar))
            {
                moving = true;
                start = new Vector2(xpos, ypos);
                target = new Vector2(xtar, ytar);
            }
        }
        if (x < 0 && Input.GetKey(KeyCode.S))
        {
            ytar = ypos - 1;
            xtar = xpos;
            if (CanMove(xtar, ytar))
            {
                moving = true;
                start = new Vector2(xpos, ypos);
                target = new Vector2(xtar, ytar);
            }
        }


        if (y > 0 && Input.GetKey(KeyCode.D))
        {
            ytar = ypos;
            xtar = xpos + 1;
            if (CanMove(xtar, ytar))
            {
                moving = true;
                start = new Vector2(xpos, ypos);
                target = new Vector2(xtar, ytar);
            }
        }

        if (y > 0 && Input.GetKey(KeyCode.A))
        {
            ytar = ypos;
            xtar = xpos - 1;
            if (CanMove(xtar, ytar))
            {
                moving = true;
                start = new Vector2(xpos, ypos);
                target = new Vector2(xtar, ytar);
            }
        }

        if (y < 0 && Input.GetKey(KeyCode.D))
        {
            ytar = ypos;
            xtar = xpos + 1;
            if (CanMove(xtar, ytar))
            {
                moving = true;
                start = new Vector2(xpos, ypos);
                target = new Vector2(xtar, ytar);
            }
        }
        if (y < 0 && Input.GetKey(KeyCode.A))
        {
            ytar = ypos;
            xtar = xpos - 1;
            if (CanMove(xtar, ytar))
            {
                moving = true;
                start = new Vector2(xpos, ypos);
                target = new Vector2(xtar, ytar);
            }
        }
    }
}
