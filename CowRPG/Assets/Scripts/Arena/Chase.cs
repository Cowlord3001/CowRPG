using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    public float Acceleration;
    public float MaxSpeed;
    //GameObject Player;
    Rigidbody2D MyBody;

	// Use this for initialization
	void Start () {
        //Player = GameObject.Find("Player");
        MyBody = GetComponent<Rigidbody2D>();
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
}
