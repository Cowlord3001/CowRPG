using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int hp;
    public GameObject Death;
    public GameObject Contact;
    public float CScale;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ApplyPDMG(int DMG)
    {
        hp = hp - DMG;
        if (hp <= 0)
        {
            GameObject GO = Instantiate(Death, transform.position, Quaternion.identity);
            Destroy(GO, 2);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Vector2 CPoint = collision.contacts[0].point;
            Vector2 Push = (Vector2)transform.position - CPoint;

            ApplyPDMG(1);
            GameObject GO = Instantiate(Contact, CPoint, Quaternion.identity);
            Destroy(GO, 2);
            //fix garbagio from this functiony thing ^^^

            GetComponent<Rigidbody2D>().AddForce(Push.normalized * CScale);
        }
    }
}
