using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    public float Acceleration;
    public float MaxSpeed;
    public int Damage;
    //GameObject Player;
    Rigidbody2D MyBody;

    bool Dashing;

    // Use this for initialization
    void Start() {
        //Player = GameObject.Find("Player");
        MyBody = GetComponent<Rigidbody2D>();

        Damage = (GetComponent<EnemyHealth>().lvl + 1) * Damage;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GetComponent<EnemyHealth>().lvl == 0 || GetComponent<EnemyHealth>().lvl == 1)
        {
            NormalMovement();
        }
        else if(GetComponent<EnemyHealth>().lvl == 2 || gameObject.name == "ChaserMiniboss")
        {
            DashMovement();
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("ApplyPDMG", Damage);
        }
    }

    void NormalMovement()
    {
        MyBody.AddForce(transform.right * Acceleration);

        float CurrentSpeed = MyBody.velocity.magnitude;

        if (CurrentSpeed > MaxSpeed)
        {
            MyBody.velocity = MaxSpeed * MyBody.velocity.normalized;
        }
    }

    void DashMovement()
    {
        if(Dashing == false)
        {
            NormalMovement();
        }
        else
        {

            Acceleration = 0;
            for (int i = 1; i < 4; i++)
            {
                Invoke("Dash", i * 2);
            }
        }
    }

    void Dash()
    {
        MyBody.velocity = transform.right * (MaxSpeed * 5);
    }

    void ToggleDash()
    {
        Dashing = !Dashing;
    }
}
