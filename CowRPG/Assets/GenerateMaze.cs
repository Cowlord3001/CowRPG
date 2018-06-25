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
                Maze[x, y].GetComponent<Tile>().Visited = false;
                Maze[x,y].name = "Tile_" + x + "" + y;

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
        //The depth-first search algorithm of maze generation is frequently implemented using backtracking:

            //1. Make the initial cell the current cell and mark it as visited

            //2. While there are unvisited cells
                   //1. If the current cell has any neighbours which have not been visited
                        //1. Choose randomly one of the unvisited neighbours
                        //2. Push the current cell to the stack
                        //3. Remove the wall between the current cell and the chosen cell
                        //4. Make the chosen cell the current cell and mark it as visited
                   //2. Else if stack is not empty
                        //1. Pop a cell from the stack
                        //2. Make it the current cell

        List<Tile> TileStack = new List<Tile>();
        

        Tile CurrentTile;
        Tile NextTile;
        CurrentTile = Maze[0, 0].GetComponent<Tile>();
        


    }

    Tile SelectNeighbor(Tile CurTile)
    {

        List<Tile> ViableNextTile = new List<Tile>();

        foreach (Tile T in CurTile.Neighbor)
        {
            if(T == null)
            {
                //no nothing
            }
            else if(T.Visited == false)
            {
                ViableNextTile.Add(T);
            }
        }

        if (ViableNextTile.Count == 0)
            return null;
        else
        {
            int i = Random.Range(0, ViableNextTile.Count - 1);
            Debug.Log("Random Integer In Choosing Neihbor: " + i);
            return ViableNextTile[i];
        }
    }

    void LowerWall(Tile CurTile, Tile NextTile)
    {
        Vector2 dir = NextTile.transform.position - CurTile.transform.position;

        if( dir.x > 0.1)
        {
            CurTile.Walls[(int)Facing.Right].gameObject.SetActive(false);
            NextTile.Walls[(int)Facing.Left].gameObject.SetActive(false);
        }
        else if(dir.y < -.1)
        {
            CurTile.Walls[(int)Facing.Down].gameObject.SetActive(false);
            NextTile.Walls[(int)Facing.Up].gameObject.SetActive(false);
        }
        else if (dir.x < -.1)
        {
            CurTile.Walls[(int)Facing.Left].gameObject.SetActive(false);
            NextTile.Walls[(int)Facing.Right].gameObject.SetActive(false);
        }
        else if (dir.y > 0.1)
        {
            CurTile.Walls[(int)Facing.Up].gameObject.SetActive(false);
            NextTile.Walls[(int)Facing.Down].gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Error no walls were lowered when they should have been");
        }
    }
}
