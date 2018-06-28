using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour {

    public Sprite Vertical, Horizontal, DRelbow, DLelbow, URelbow, ULelbow, Left3, Up3, Down3, Right3, CrossRoad, UpEnd, DownEnd, LeftEnd, RightEnd;

    SpriteRenderer CurrentSprite;

    public Transform[] Walls;
    public Tile[] Neighbor;
    public bool Visited;

    private void Start()
    {
        CurrentSprite = GetComponent<SpriteRenderer>();
    }

    public void setSprite()
    {
        string SS = "";

        if (Walls[(int)Facing.Up].gameObject.activeSelf == false)
            SS = SS + "N";
        if (Walls[(int)Facing.Right].gameObject.activeSelf == false)
            SS = SS + "E";
        if (Walls[(int)Facing.Down].gameObject.activeSelf == false)
            SS = SS + "S";
        if (Walls[(int)Facing.Left].gameObject.activeSelf == false)
            SS = SS + "W";
        

        if(SS == "N")
        {
            CurrentSprite = GetComponent<SpriteRenderer>();
            CurrentSprite.sprite = DownEnd;
        }
        else if( SS == "E")
        {
            CurrentSprite = GetComponent<SpriteRenderer>();
            CurrentSprite.sprite = LeftEnd;
        }
        else if (SS == "S")
        {
            CurrentSprite = GetComponent<SpriteRenderer>();
            CurrentSprite.sprite = UpEnd;
        }
        else if (SS == "W")
        {
            CurrentSprite = GetComponent<SpriteRenderer>();
            CurrentSprite.sprite = RightEnd;
        }
        else if (SS == "EW")
        {
            CurrentSprite = GetComponent<SpriteRenderer>();
            CurrentSprite.sprite = Horizontal;
        }
        else if (SS == "NS")
        {
            CurrentSprite = GetComponent<SpriteRenderer>();
            CurrentSprite.sprite = Vertical;
        }
        else if (SS == "NE")
        {
            CurrentSprite = GetComponent<SpriteRenderer>();
            CurrentSprite.sprite = URelbow;
        }
        else if (SS == "NW")
        {
            CurrentSprite = GetComponent<SpriteRenderer>();
            CurrentSprite.sprite = ULelbow;
        }
        else if (SS == "ES")
        {
            CurrentSprite = GetComponent<SpriteRenderer>();
            CurrentSprite.sprite = DRelbow;
        }
        else if (SS == "SW")
        {
            CurrentSprite = GetComponent<SpriteRenderer>();
            CurrentSprite.sprite = DLelbow;
        }
        else if (SS == "NES")
        {
            CurrentSprite = GetComponent<SpriteRenderer>();
            CurrentSprite.sprite = Right3;
        }
        else if (SS == "ESW")
        {
            CurrentSprite = GetComponent<SpriteRenderer>();
            CurrentSprite.sprite = Down3;
        }
        else if (SS == "NSW")
        {
            CurrentSprite = GetComponent<SpriteRenderer>();
            CurrentSprite.sprite = Left3;
        }
        else if (SS == "NEW")
        {
            CurrentSprite = GetComponent<SpriteRenderer>();
            CurrentSprite.sprite = Up3;
        }
        else if (SS == "NESW")
        {
            CurrentSprite = GetComponent<SpriteRenderer>();
            CurrentSprite.sprite = CrossRoad;
        }



    }
    
}
