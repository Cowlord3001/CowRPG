using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour {

    public float Damage;
    public float Lifetime;
    float Timer = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Timer += Time.deltaTime;
        if (Timer > 1 / Damage)
        {
            collision.SendMessage("ApplyDMG", 1);
        }

        if (collision.name == "ForestBoss")
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        Destroy(gameObject, Lifetime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
