using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToArena : MonoBehaviour {

    public float Width, Height;

    public Camera ArenaCamera;
	// Use this for initialization
	void Start () {

        ArenaCamera.fieldOfView = ArenaCamera.orthographicSize;

    }
	
}
