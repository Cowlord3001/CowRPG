using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour {

    public Sprite Vertical, Horizontal, DRelbow, DLelbow, URelbow, ULelbow, Left3, Up3, Down3, Right3, CrossRoad;

    SpriteRenderer CurrentSprite;

    public Transform[] Walls;
    public Tile[] Neighbor;
    public bool Visited;
    

    public void setSprite()
    {
        string SS = "";

        if (Walls[(int)Facing.Up].gameObject.activeSelf == true)
            SS = SS + "N";
        if (Walls[(int)Facing.Right].gameObject.activeSelf == true)
            SS = SS + "E";
        if (Walls[(int)Facing.Down].gameObject.activeSelf == true)
            SS = SS + "S";
        if (Walls[(int)Facing.Left].gameObject.activeSelf == true)
            SS = SS + "W";

        if(SS == "N")
        {
            CurrentSprite.sprite = Vertical;
        }else if( SS == "E")
        {
            CurrentSprite.sprite = Horizontal;
        }
        else if (SS == "S")
        {
            CurrentSprite.sprite = Vertical;
        }
        else if (SS == "W")
        {
            CurrentSprite.sprite = Horizontal;
        }
        else if (SS == "NE")
        {
            CurrentSprite.sprite = URelbow;
        }
        else if (SS == "NW")
        {
            CurrentSprite.sprite = ULelbow;
        }
        else if (SS == "ES")
        {
            CurrentSprite.sprite = DRelbow;
        }
        else if (SS == "SW")
        {
            CurrentSprite.sprite = DLelbow;
        }
        else if (SS == "NES")
        {
            CurrentSprite.sprite = Left3;
        }
        else if (SS == "ESW")
        {
            CurrentSprite.sprite = Down3;

        }
        else if (SS == "NSW")
        {
            CurrentSprite.sprite = Right3;
        }
        else if (SS == "NEW")
        {
            CurrentSprite.sprite = Up3;
        }
        else if (SS == "NESW")
        {
            CurrentSprite.sprite = CrossRoad;
        }



    }
    
}
