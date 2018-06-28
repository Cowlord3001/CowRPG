using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    public float Acceleration;
    public float MaxSpeed;
    public int Damage;
    //GameObject Player;
    Rigidbody2D MyBody;

    // Use this for initialization
    void Start() {
        //Player = GameObject.Find("Player");
        MyBody = GetComponent<Rigidbody2D>();

        Damage = (GetComponent<EnemyHealth>().lvl + 1) * Damage;
	}
	
	// Update is called once per frame
	void Update () {
        MyBody.AddForce(transform.right * Acceleration);

        float CurrentSpeed = MyBody.velocity.magnitude;

        if(CurrentSpeed > MaxSpeed)
        {
            MyBody.velocity = MaxSpeed * MyBody.velocity.normalized;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("ApplyPDMG", Damage);
        }
    }
}
