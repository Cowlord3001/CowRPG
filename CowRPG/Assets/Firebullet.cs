using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebullet : Bullet{

    float Timer;
    public GameObject Bullet;
    
	// Use this for initialization
	void Start () {
        Timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Released == true)
        {
            Timer += Time.deltaTime;
        }

        if(Timer >= 2)
        {
            Split();
        }
	}

    void Split()
    {
        GameObject GO = Instantiate(Bullet, transform.position, transform.rotation);
        GO.transform.localScale = transform.localScale * (1 / 3);
        GO.GetComponent<Bullet>().Damage = Damage * (1 / 3);
        Destroy(gameObject);
    }
}
