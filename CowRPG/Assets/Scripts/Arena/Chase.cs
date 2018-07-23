using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    float Acceleration;
    public float MaxAccel;
    public float MaxSpeed;
    public int DashNum;
    public int Damage;
    //GameObject Player;
    Rigidbody2D MyBody;

    float x;
    float DashTime;

    bool Dashing;

    // Use this for initialization
    void Start() {
        //Player = GameObject.Find("Player");
        MyBody = GetComponent<Rigidbody2D>();

        Damage = (GetComponent<EnemyHealth>().lvl + 1) * Damage;
        Acceleration = MaxAccel;
        Dashing = false;

        DashTime = 0;
        x = Random.Range(5, 11);

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
            if (Acceleration > .1)
            {
                NormalMovement();
            }

            DashTime = DashTime + Time.deltaTime;

            if(DashTime > x)
            {
                ToggleDash();
            }
        }
        else
        {
            for (int i = 1; i < DashNum + 1; i++)
            {
                Invoke("Dash", i * 2);
            }
            Dashing = false;
        }
    }

    void Dash()
    {
        MyBody.velocity = transform.right * (MaxSpeed * 10);
    }

    void ToggleDash()
    {
        if (Acceleration < .1)
        {
            Debug.Log("Dash Toggled False");
            Acceleration = MaxAccel;
            Dashing = false;
            x = Random.Range(5, 11);
            if (gameObject.name == "ForestBoss")
            {
                x = 20;
            }
            DashTime = 0;
        }
        else
        {
            Debug.Log("Dash Toggled True");
            Acceleration = 0;
            Dashing = true;
            x = Random.Range(5, 11);
            if (gameObject.name == "ForestBoss")
            {
                x = 5;
            }
            DashTime = 0;
        }
    }
}
