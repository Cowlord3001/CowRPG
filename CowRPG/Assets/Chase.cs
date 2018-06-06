using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    public float Speed;
    GameObject Player;
    Rigidbody2D MyBody;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        MyBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        MyBody.AddForce(transform.right * Speed);
	}
}
