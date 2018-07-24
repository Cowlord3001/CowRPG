using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    int hp;
    public int HPMAX;
    public GameObject Death;
    public GameObject Contact;
    public float CScale;

    Slider HealthBar;

    // Use this for initialization
    void OnEnable()
    {
        HealthBar = GameObject.Find("CurrentHP").GetComponent<Slider>();
        hp = HPMAX;
        if(HealthBar != null)
        {
            HealthBar.maxValue = HPMAX;
            HealthBar.value = hp;
        }
        else
        {
            Debug.Log("No Slider Found in Arena Scene");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RevertColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void ApplyPDMG(int DMG)
    {
        hp = hp - DMG;
        HealthBar.value = hp;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        CancelInvoke();
        Invoke("RevertColor", .1f);
        if (hp <= 0)
        {
            GameObject GO = Instantiate(Death, transform.position, Quaternion.identity);
            Destroy(GO, 2);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.gameObject.name == "BossWall")
        {

        }

        else if (collision.gameObject.tag == "Enemy")
        {
            Vector2 CPoint = collision.contacts[0].point;
            Vector2 Push = (Vector2)transform.position - CPoint;

            ApplyPDMG(1);
            GameObject GO = Instantiate(Contact, CPoint, Quaternion.identity);
            Destroy(GO, 2);

            if(Battlemove.Dashing == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Push.normalized * (CScale/4));
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(Push.normalized * CScale);
            }
        }
    }
}
