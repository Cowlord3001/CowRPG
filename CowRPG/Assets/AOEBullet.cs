using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEBullet : Bullet {

    float T;
    float Timer;
    bool HideyBoi;
    public GameObject Pool;

	// Use this for initialization
	void Start () {
        Timer = 0;
        T = 999;
        HideyBoi = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Released == true)
        {
            Timer += Time.deltaTime;
            if (HideyBoi == true)
            {
                float Dist = ((Vector2)transform.position - (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition))).magnitude;
                T = Dist / 5;
                HideyBoi = false;
            }
            else
            {

            }
            //Debug.Log("Speed is " + Speed);
            //Debug.Log("T is " + T);
        }
        
        if (Timer >= T)
        {
            AOE();
        }
    }

    void AOE()
    {
        GameObject GO = Instantiate(Pool, transform.position, Quaternion.identity);
        GO.transform.localScale = transform.localScale * 2f;
        Destroy(gameObject);
    }
}
