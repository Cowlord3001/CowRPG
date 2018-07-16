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
    public bool AltSpread;
    bool AltSpreadTracker;
    public float Accuracy;

    float Timer;
    int x;
    bool Frozen;

    public int SpreadShots;
    public float MaxSpreadAngle;

    int level;

    // Use this for initialization
    void Start()
    {
        level = GetComponent<EnemyHealth>().lvl;
        Timer = 0;
        x = Random.Range(5, 11);

        AltSpreadTracker = true;
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
        else if(Type == "RangerMiniboss")
        {
            RangerMinibossControl();
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
        float SpreadAngle = Random.Range(-Accuracy, Accuracy);

        GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation*Quaternion.AngleAxis(SpreadAngle,Vector3.forward));
        bullet.GetComponent<EBullet>().Damage = level + 1;
        Timestamp = Time.time;
    }

    void SpreadFire()
    {
        float SpreadAngle = MaxSpreadAngle / SpreadShots;
        
        if(AltSpread == true)
        {
            if (AltSpreadTracker == true)
            {
                for (int i = -SpreadShots / 2; i < SpreadShots / 2; i++)
                {
                    GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation * Quaternion.AngleAxis((SpreadAngle * i) + SpreadAngle / 2, Vector3.forward));
                    bullet.GetComponent<EBullet>().Damage = level + 1;
                }
                AltSpreadTracker = false;
            }

            else
            {
                for (int i = -SpreadShots / 2; i <= SpreadShots / 2; i++)
                {
                    GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation * Quaternion.AngleAxis(SpreadAngle * i, Vector3.forward));
                    bullet.GetComponent<EBullet>().Damage = level + 1;
                }
                AltSpreadTracker = true;
            }
        }

        else
        {
            for (int i = -SpreadShots / 2; i <= SpreadShots / 2; i++)
            {
                GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation * Quaternion.AngleAxis(SpreadAngle * i, Vector3.forward));
                bullet.GetComponent<EBullet>().Damage = level + 1;
            }
        }

        Timestamp = Time.time;
    }

    void BurstFire()
    {
        if(BurstCooldown+Timestamp < Time.time)
        {
            for (int i = 0; i < BurstNumber; i++)
            {
               Invoke("SpreadFire", ROF * i);
            }
        }
    }

    void RangerMinibossControl()
    {
        Timer = Timer + Time.deltaTime;
        if(Timer > x)
        {
            if(Frozen == true)
            {
                UnfreezePos();
            }
            else
            {
                FreezePos();
            }
        }

        ConstantFire();
    }

    void FreezePos()
    {
        Frozen = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        x = Random.Range(5, 11);
        Timer = 0;
        ROF = ROF / 12;
        Accuracy = Accuracy / 1.5f;
    }

    void UnfreezePos()
    {
        Frozen = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        x = Random.Range(5, 11);
        Timer = 0;
        ROF = ROF * 12;
        Accuracy = Accuracy * 1.5f;
    }
}

