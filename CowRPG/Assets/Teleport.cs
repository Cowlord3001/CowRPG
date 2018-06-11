using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public float Teleport_Cooldown;
    public int Teleport_Number;
    public float Break_Cooldown;
    float Timestamp;

    TeleportRaycast Teleport_Waypoint;
    Rigidbody2D MyBody;

	// Use this for initialization
	void Start () {
        Teleport_Waypoint = GameObject.Find("TeleportRaycast").GetComponent<TeleportRaycast>();

        Timestamp = 0;

        MyBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
       if (Teleport_Number == 0)
        {
            NormPort();
        }
        else if(Timestamp+Break_Cooldown < Time.time)
        {
            BurstPort();
            Timestamp = Time.time;
        }
	}
    void NormPort()
    {
        if (Timestamp + Teleport_Cooldown < Time.time)
        {
            Port();

            Timestamp = Time.time;
        }
    }

    void Port()
    {
        Vector2 Teleport_Location = Teleport_Waypoint.RandomizedTP();
        transform.position = Teleport_Location;

        MyBody.velocity = Vector2.zero;
        MyBody.inertia = 1000;
    }

    void BurstPort()
    {
        for (int i = 0; i < Teleport_Number; i++)
        {
            Invoke("Port", Teleport_Cooldown*i);
        }
        
    }
}
