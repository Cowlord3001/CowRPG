using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour {

    Sprite Vertical, Horizontal, DRelbow, DLelbow, URelbow, ULelbow, Left3, Up3, Down3, Right3, CrossRoad;

    SpriteRenderer CurrentSprite;

    public Transform[] Walls;
    public Tile[] Neighbor;
    public bool Visited;

    public int x, y;
    public GameObject MazeGen;
	// Update is called once per frame
	void Start () {
		
	}
    
}
