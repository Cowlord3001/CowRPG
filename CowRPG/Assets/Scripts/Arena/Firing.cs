﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour {

    public GameObject RangedBullet;
    public GameObject MeleeBullet;
    public GameObject SpellBullet;
    public float ROF;
    float Timestamp;
    bool Charging;
    GameObject GO;
    Vector3 Scale;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(gameObject.tag == "Ranger")
        {
            RangerFire();
        }
        else if(gameObject.tag == "Fighter")
        {
            FighterFire();
        }
        else if(gameObject.tag == "Spellcaster")
        {
            SpellFire();
        }
	}

    void RangerFire()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Timestamp + ROF < Time.time)
        {
            Instantiate(RangedBullet, transform.position, transform.parent.transform.rotation);
            Timestamp = Time.time;
        }
    }

    void FighterFire()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Timestamp + ROF*4 < Time.time)
        {
            Instantiate(MeleeBullet, transform.position, transform.parent.transform.rotation);
            Timestamp = Time.time;
        }
    }

    void SpellFire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Timestamp + ROF * 8 < Time.time)
        {
            GO = Instantiate(SpellBullet, transform.position, transform.parent.transform.rotation);
            Timestamp = Time.time;
            Charging = true;
            Scale = GO.transform.localScale;
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            GO.GetComponent<Rigidbody2D>().velocity = transform.right * 5;
            GO.transform.parent = null;
            Charging = false;
        }
        if(Charging == true)
        {
            GO.transform.position = transform.position + transform.right;
            GO.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            Debug.Log(GO.transform.localScale);
            GO.transform.localScale = GO.transform.localScale + Scale * Time.deltaTime * .5f;
        }
    }
}
