using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject tilePreFab;
    public int gridSizeX = 6;
    public int gridSizeZ = 6;
    public float spacing = 2f;

    private Tile[,] grid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateGrid();
        GeneratePath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateGrid()
    {
        grid = new Tile[gridSizeX, gridSizeZ];

        Vector3 startPos = new Vector3(-54.24f, 9.52f, 48.2f);

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                Vector3 position = startPos + new Vector3(x * spacing, 0, z * spacing);
                GameObject tileObj = Instantiate(tilePreFab, position, Quaternion.identity);
                tileObj.transform.parent = this.transform;

                Tile tileScript = tileObj.GetComponent<Tile>();
                if (tileScript != null)
                {
                    tileScript.SetCoordinats(x, z);
                    grid[x, z] = tileScript;
                }
            }
        }
    }

    void GeneratePath()
    {
        int currentX = 0;
        int currentZ = 0;

        Tile currentTile = grid[currentX, currentZ];
        currentTile.isReal = true;

        System.Random rand = new System.Random();

        while (currentX < gridSizeX - 1 || currentZ < gridSizeZ - 1)
        {
            List<string> possibleMoves = new List<string>();

            if (currentX < gridSizeX - 1)
            {
                possibleMoves.Add("Right");
            }
            if (currentZ < gridSizeZ - 1)
            {
                possibleMoves.Add("Up");
            }

            string move = possibleMoves[rand.Next(possibleMoves.Count)];

            if (move == "Right")
            {
                currentX++;
            }
            else if (move == "Up")
            {
                currentZ++;
            }

            Tile nextTile = grid[currentX, currentZ];
            nextTile.isReal = true;

            //Debug
            //nextTile.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
