using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InEnemyLook : MonoBehaviour
{

    GameObject Player;
    public float Rotation;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        if(Player == null)
        {
            Player = GameObject.Find("TPlayer");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Look = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(angle,Vector3.forward),Rotation);
    }
}
