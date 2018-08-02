using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToArena : MonoBehaviour {

    public float width;
    public Camera ArenaCamera;
	// Use this for initialization
	void Start () {

        ArenaCamera = GetComponent<Camera>();
        
        Camera.main.orthographicSize = 0.5f * (width / ArenaCamera.aspect);

    }
	
}
