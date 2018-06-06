using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiring : MonoBehaviour
{

    public GameObject Bullet;
    public float ROF;
    float Timestamp;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Timestamp + ROF < Time.time)
        {
            Instantiate(Bullet, transform.position, transform.rotation);
            Timestamp = Time.time;
        }

    }
}

