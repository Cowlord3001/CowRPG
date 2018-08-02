using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraYFollow : MonoBehaviour {

    public bool FollowX, FollowY;
    public float XOffset, YOffset;

    public GameObject ObjectToFollow;

	// Update is called once per frame
	void Update () {
        if(ObjectToFollow != null)
        {
            Follow(FollowX, FollowY);
        }
	}

    void Follow(bool x, bool y)
    {

        float Xpos, Ypos;
        Xpos = transform.position.x;
        Ypos = transform.position.y;


        if ( y )
        {
            Ypos = ObjectToFollow.transform.position.y + YOffset;
        }
        if ( x )
        {
            Xpos = ObjectToFollow.transform.position.x + XOffset;
        }

        transform.position = new Vector3(Xpos, Ypos, -10.0f);
    }
}
