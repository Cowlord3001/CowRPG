using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAttack : MonoBehaviour {

    public GameObject Bullet;
    public float BulletGap;
    public int BulletNum;
    public int Directions;
    float Radius;

    // Use this for initialization
    void Start ()
    {
        Radius = BulletGap;

        for (int i = 0; i < BulletNum; i++)
        {
            Invoke("Fire", .5f * i);
        }
	}

    // Update is called once per frame
    void Update()
    {

    }

    void Fire()
    {
        for (int i = 0; i < Directions; i++)
        {
            float Angle = ((Mathf.PI * 2) / Directions) + i;

            Vector2 SpawnLocation = (Vector2)transform.position + new Vector2(Radius * Mathf.Cos(Angle), Radius * Mathf.Sin(Angle));
            GameObject GO = Instantiate(Bullet, (Vector3)SpawnLocation, Quaternion.identity);
            GO.transform.parent = transform;
        }
        Radius += BulletGap;
         
    }

}
