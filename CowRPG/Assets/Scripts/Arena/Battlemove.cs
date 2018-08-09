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
    public GameObject DashBullet;
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
            if (gameObject.transform.GetChild(0).tag == "Fighter" && QuestLog.Level >= 3)
            {
                for (int i = 0; i < 16; i++)
                {
                    GameObject GO = Instantiate(DashBullet, transform.position,
                        transform.rotation * Quaternion.AngleAxis((360f / 16f) * i, Vector3.forward));
                    GO.transform.position += GO.transform.right;
                    GO.transform.parent = transform;
                }
            }

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
    
}
    


    



