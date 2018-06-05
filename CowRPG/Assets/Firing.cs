using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour {

    public GameObject Bullet;
    public float ROF;
    float Timestamp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Mouse0) && Timestamp + ROF < Time.time)
        {
            Instantiate(Bullet, transform.position, transform.parent.transform.rotation);
            Timestamp = Time.time;
        }

	}
}
