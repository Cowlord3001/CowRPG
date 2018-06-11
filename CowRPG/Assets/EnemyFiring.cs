using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiring : MonoBehaviour
{

    public GameObject Bullet;
    public float ROF;
    float Timestamp;
    public string Type;
    public float BurstCooldown;
    public int BurstNumber;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Type == "Burst")
        {
            BurstFire();
        }
        else if(Type == "Constant")
        {
            ConstantFire();
        }
    }

    void ConstantFire()
    {
        if (Timestamp + ROF < Time.time)
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
        Timestamp = Time.time;
    }

    void BurstFire()
    {
        if(BurstCooldown+Timestamp < Time.time)
        {
            for (int i = 0; i < BurstNumber; i++)
            {
                Invoke("Fire", ROF*i);
            }
        }
    }
}

