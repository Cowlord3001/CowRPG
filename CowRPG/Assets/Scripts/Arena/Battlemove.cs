using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Battlemove : MonoBehaviour
{
    public float Speed;
    float ydir;
    float xdir;
    Rigidbody2D Mybody;
    //public float DashTime;
    public float DashSpeed;
    public float DashDistance;
    //public float SlideDist;
    //public float DashThresh;
    public float DashCool;
    float Timestamp;
    public static bool Dashing;
    //float Wc, Ac, Sc, Dc;

    private void Start()
    {
        Mybody = GetComponent<Rigidbody2D>();
        //Wc = 0;
        //Ac = 0;
        //Sc = 0;
        //Dc = 0;
        Timestamp = 0;
        Dashing = false;
    }

    private void Update()
    {
        if (Dashing == false)
        {
            NormalMove();
        }

        if (Timestamp + DashCool < Time.time || Dashing == true)
        {
            Dash();
        }
    }

    void NormalMove()
    {
        ydir = Input.GetAxis("Vertical");
        xdir = Input.GetAxis("Horizontal");

        Mybody.velocity = new Vector2(xdir * Speed, ydir * Speed);

        Vector2 Look = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && Dashing == false)
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                Dashing = true;
                gameObject.tag = "Dashing";
                gameObject.transform.GetChild(0).tag = "Untagged";
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                Vector2 Dir = new Vector2(-1, 1);
                Dir = Dir.normalized;
                Mybody.velocity = Dir * DashSpeed;
                Timestamp = Time.time;
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                Dashing = true;
                gameObject.tag = "Dashing";
                gameObject.transform.GetChild(0).tag = "Untagged";
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                Vector2 Dir = new Vector2(1, 1);
                Dir = Dir.normalized;
                Mybody.velocity = Dir * DashSpeed;
                Timestamp = Time.time;
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                Dashing = true;
                gameObject.tag = "Dashing";
                gameObject.transform.GetChild(0).tag = "Untagged";
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                Vector2 Dir = new Vector2(-1, -1);
                Dir = Dir.normalized;
                Mybody.velocity = Dir * DashSpeed;
                Timestamp = Time.time;
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                Dashing = true;
                gameObject.tag = "Dashing";
                gameObject.transform.GetChild(0).tag = "Untagged";
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                Vector2 Dir = new Vector2(1, -1);
                Dir = Dir.normalized;
                Mybody.velocity = Dir * DashSpeed;
                Timestamp = Time.time;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                Dashing = true;
                gameObject.tag = "Dashing";
                gameObject.transform.GetChild(0).tag = "Untagged";
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                Vector2 Dir = Vector2.up;
                Mybody.velocity = Dir * DashSpeed;
                Timestamp = Time.time;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Dashing = true;
                gameObject.tag = "Dashing";
                gameObject.transform.GetChild(0).tag = "Untagged";
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                Vector2 Dir = Vector2.down;
                Mybody.velocity = Dir * DashSpeed;
                Timestamp = Time.time;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Dashing = true;
                gameObject.tag = "Dashing";
                gameObject.transform.GetChild(0).tag = "Untagged";
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                Vector2 Dir = Vector2.left;
                Mybody.velocity = Dir * DashSpeed;
                Timestamp = Time.time;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Dashing = true;
                gameObject.tag = "Dashing";
                gameObject.transform.GetChild(0).tag = "Untagged";
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                Vector2 Dir = Vector2.right;
                Mybody.velocity = Dir * DashSpeed;
                Timestamp = Time.time;
            }
            else
            {
               
            }

        }

        if (Timestamp + ((DashDistance / DashSpeed) * .6) < Time.time)
        {
            gameObject.tag = "Player";
            if (gameObject.GetComponent<SpriteRenderer>().color != Color.red)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        
        if (Timestamp + (DashDistance / DashSpeed) < Time.time)
        {
            Dashing = false;
            gameObject.transform.GetChild(0).tag = QuestLog.Class;
        }
    }


    //void Dash()
    //{
    //    if (Dashing == false)
    //    {
    //        if (Input.GetKeyDown(KeyCode.W))
    //        {
    //            if (Input.GetKeyDown(KeyCode.W) && Wc > 0.1)
    //            {
    //                Mybody.velocity = DashSpeed * Vector2.up;
    //                Dashing = true;
    //                Timestamp = Time.time;
    //                Timestamp2 = Time.time;

    //            }
    //            Wc = Wc + 1;
    //        }

    //        if (Wc > 0)
    //        {
    //            Wc = Wc - Time.deltaTime * DashThresh;
    //        }

    //        if (Input.GetKeyDown(KeyCode.A))
    //        {
    //            if (Input.GetKeyDown(KeyCode.A) && Ac > 0.1)
    //            {
    //                Mybody.velocity = DashSpeed * Vector2.left;
    //                Dashing = true;
    //                Timestamp = Time.time;
    //                Timestamp2 = Time.time;

    //            }
    //            Ac = Ac + 1;
    //        }

    //        if (Ac > 0)
    //        {
    //            Ac = Ac - Time.deltaTime * DashThresh;
    //        }

    //        if (Input.GetKeyDown(KeyCode.S))
    //        {
    //            if (Input.GetKeyDown(KeyCode.S) && Sc > 0.1)
    //            {
    //                Mybody.velocity = DashSpeed * Vector2.down;
    //                Dashing = true;
    //                Timestamp = Time.time;
    //                Timestamp2 = Time.time;

    //            }
    //            Sc = Sc + 1;
    //        }

    //        if (Sc > 0)
    //        {
    //            Sc = Sc - Time.deltaTime * DashThresh;
    //        }

    //        if (Input.GetKeyDown(KeyCode.D))
    //        {
    //            if (Input.GetKeyDown(KeyCode.D) && Dc > 0.1)
    //            {
    //                Mybody.velocity = DashSpeed * Vector2.right;
    //                Dashing = true;
    //                Timestamp = Time.time;
    //                Timestamp2 = Time.time;

    //            }
    //            Dc = Dc + 1;
    //        }

    //        if (Dc > 0)
    //        {
    //            Dc = Dc - Time.deltaTime * DashThresh;
    //        }
    //    }
        //if (Timestamp + DashTime - SlideDist < Time.time)
        //{
        //    Mybody.velocity = Mybody.velocity*.5f + new Vector2(xdir * Speed, ydir * Speed);
        //    Vector2 Look = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //    float angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg;
        //    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //}

    //    if (Timestamp + DashTime < Time.time)
    //    {
    //        Dashing = false;
    //    }
    //}
}
    


    



