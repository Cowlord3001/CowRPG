using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Facing
{
    Up, Right, Down, Left
}


public class GenerateMaze : MonoBehaviour {

    public int Width, Height;
    public float tileWidth, tileHeight;

    GameObject[,] Maze;

    public GameObject TileGameObject;

	// Use this for initialization
	void Start () {
        Maze = new GameObject[Width, Height];

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Maze[x,y] = Instantiate(TileGameObject,
                                        (Vector2)transform.position + new Vector2(x * tileWidth, y * tileHeight),
                                        Quaternion.identity);

                
                Maze[x,y].transform.parent = transform;
                Maze[x, y].GetComponent<Tile>().MazeGen = gameObject;
                Maze[x,y].name = "Tile_" + x + "" + y;

                Debug.Log("Tile_" + x + "" + y + " Instantiated");

            }
        }

        LinkNeighbors();
	}
	

    void LinkNeighbors()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {

                if (x == 0 && y == 0)
                {
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Up] = Maze[x, y + 1].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Right] = Maze[x + 1, y].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Down] = null;
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Left] = null;
                }
                else if (x == 0 && y == Height - 1)
                {
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Up] = null;
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Right] = Maze[x + 1, y].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Down] = Maze[x, y - 1].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Left] = null;
                }
                else if (x == Width - 1 && y == 0)
                {
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Up] = Maze[x, y + 1].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Right] = null;
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Down] = null;
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Left] = Maze[x - 1, y].GetComponent<Tile>();
                }
                else if (x == Width - 1 && y == Height - 1)
                {
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Up] = null;
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Right] = null;
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Down] = Maze[x, y - 1].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Left] = Maze[x - 1, y].GetComponent<Tile>();
                }
                else if (x == 0)
                {
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Up] = Maze[x, y + 1].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Right] = Maze[x + 1, y].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Down] = Maze[x, y - 1].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Left] = null;
                }
                else if (x == Width - 1)
                {
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Up] = Maze[x, y + 1].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Right] = null;
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Down] = Maze[x, y - 1].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Left] = Maze[x - 1, y].GetComponent<Tile>();
                }
                else if (y == 0)
                {
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Up] = Maze[x, y + 1].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Right] = Maze[x + 1, y].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Down] = null;
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Left] = Maze[x - 1, y].GetComponent<Tile>();
                }
                else if (y == Height - 1)
                {
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Up] = null;
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Right] = Maze[x + 1, y].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Down] = Maze[x, y - 1].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Left] = Maze[x - 1, y].GetComponent<Tile>();
                }
                else
                {
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Up] = Maze[x, y + 1].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Right] = Maze[x + 1, y].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Down] = Maze[x, y - 1].GetComponent<Tile>();
                    Maze[x, y].GetComponent<Tile>().Neighbor[(int)Facing.Left] = Maze[x - 1, y].GetComponent<Tile>();
                }
            }

        }
    }


    void CreateMaze()
    {
        List<Tile> TileStack;
        

    }

    void SelectNeighbor()
    {
       
    }

    void LowerWall()
    {

    }
}
