using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public float Teleport_Cooldown;
    public int Teleport_Number;
    float Timestamp;

    TeleportRaycast Teleport_Waypoint;

	// Use this for initialization
	void Start () {
        Teleport_Waypoint = GameObject.Find("TeleportRaycast").GetComponent<TeleportRaycast>();

        Timestamp = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Timestamp + Teleport_Cooldown < Time.time)
        {
            Vector2 Teleport_Location = Teleport_Waypoint.RandomizedTP();
            transform.position = Teleport_Location;

            Timestamp = Time.time;
        }
	}
}
