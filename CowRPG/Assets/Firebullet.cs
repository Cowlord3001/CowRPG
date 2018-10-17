using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebullet : Bullet{

    float Timer;
    public GameObject Bullet;
    public bool Original = true;
    
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

        if(Timer >= 1 && Original == true)
        {
            Split();
        }
	}

    void Split()
    {
        GameObject GO = Instantiate(Bullet, transform.position, transform.rotation);
        GO.GetComponent<Firebullet>().Original = false;
        GO.GetComponent<Rigidbody2D>().velocity = GO.transform.right * 5;
        GO.transform.localScale = transform.localScale * (1f / 2f);
        GO.GetComponent<Bullet>().Damage = Damage * (1f / 2f);

        GO = Instantiate(Bullet, transform.position, transform.rotation*Quaternion.AngleAxis(30, Vector3.forward));
        GO.GetComponent<Firebullet>().Original = false;
        GO.GetComponent<Rigidbody2D>().velocity = GO.transform.right * 5;
        GO.transform.localScale = transform.localScale * (1f / 2f);
        GO.GetComponent<Bullet>().Damage = Damage * (1f / 2f);

        GO = Instantiate(Bullet, transform.position, transform.rotation * Quaternion.AngleAxis(-30, Vector3.forward));
        GO.GetComponent<Firebullet>().Original = false;
        GO.GetComponent<Rigidbody2D>().velocity = GO.transform.right * 5;
        GO.transform.localScale = transform.localScale * (1f / 2f);
        GO.GetComponent<Bullet>().Damage = Damage * (1f / 2f);
        Destroy(gameObject);
    }
}
