using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Battlemove : MonoBehaviour
{
    public float Speed;
    float ydir;
    float xdir;
    Rigidbody2D Mybody;
    public float DashTime;
    public float DashDist;
    public float DashThresh;
    float Timestamp;
    bool Dashing;
    float Wc, Ac, Sc, Dc;

    private void Start()
    {
        Mybody = GetComponent<Rigidbody2D>();
        Wc = 0;
        Ac = 0;
        Sc = 0;
        Dc = 0;
    }

    private void Update()
    {
        if (Dashing == false)
        {
            ydir = Input.GetAxis("Vertical");
            xdir = Input.GetAxis("Horizontal");

            Mybody.velocity = new Vector2(xdir * Speed, ydir * Speed);

            Vector2 Look = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (Dashing == false)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (Input.GetKeyDown(KeyCode.W) && Wc > 0.1)
                {
                    Mybody.velocity = DashDist * Vector2.up;
                    Dashing = true;
                    Timestamp = Time.time;

                }
                Wc = Wc + 1;
            }

            if (Wc > 0)
            {
                Wc = Wc - Time.deltaTime * DashThresh;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (Input.GetKeyDown(KeyCode.A) && Ac > 0.1)
                {
                    Mybody.velocity = DashDist * Vector2.left;
                    Dashing = true;
                    Timestamp = Time.time;

                }
                Ac = Ac + 1;
            }

            if (Ac > 0)
            {
                Ac = Ac - Time.deltaTime * DashThresh;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                if (Input.GetKeyDown(KeyCode.S) && Sc > 0.1)
                {
                    Mybody.velocity = DashDist * Vector2.down;
                    Dashing = true;
                    Timestamp = Time.time;

                }
                Sc = Sc + 1;
            }

            if (Sc > 0)
            {
                Sc = Sc - Time.deltaTime * DashThresh;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (Input.GetKeyDown(KeyCode.D) && Dc > 0.1)
                {
                    Mybody.velocity = DashDist * Vector2.right;
                    Dashing = true;
                    Timestamp = Time.time;

                }
                Dc = Dc + 1;
            }

            if (Dc > 0)
            {
                Dc = Dc - Time.deltaTime * DashThresh;
            }
        }

        if (Timestamp + DashTime < Time.time)
        {
            Dashing = false;
        }
    }


}
