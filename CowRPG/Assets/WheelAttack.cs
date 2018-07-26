using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAttack : MonoBehaviour {

    public GameObject Bullet;
    public float BulletGap;
    public int BulletNum;
    public int Directions;
    float Radius;

    public float SpinSpeed;
    bool Spin;

    // Use this for initialization
    void Start ()
    {
        Spin = false;
        Radius = BulletGap;

        float temp = 3f / BulletNum;
        Debug.Log(temp);

        for (int i = 0; i < BulletNum; i++)
        {
            Invoke("Fire", temp * i);
        }

        Invoke("SpinOn", 3);
	}

    // Update is called once per frame
    void Update()
    {
        if(Spin == true)
        {
            transform.Rotate(0, 0, SpinSpeed * Time.deltaTime);
        }
    }

    void Fire()
    {
        for (int i = 0; i < Directions; i++)
        {
            float Angle = ((Mathf.PI * 2) / Directions) * i;

            Vector2 SpawnLocation = (Vector2)transform.position + new Vector2(Radius * Mathf.Cos(Angle), Radius * Mathf.Sin(Angle));
            GameObject GO = Instantiate(Bullet, (Vector3)SpawnLocation, Quaternion.identity);
            GO.transform.parent = transform;
        }
        Radius += BulletGap;
         
    }

    void SpinOn()
    {
        Spin = true;
    }

}
