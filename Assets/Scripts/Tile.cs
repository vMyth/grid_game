using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class Tile : MonoBehaviour
{
    /*The Commented lines count a distance of 2 from the target.*/

    public bool isTarget = false;
    public TextMesh displayText;
    public Material materialIdle;
    public Material materialLightup;
    public Material materialRed;
    public Material materialYellow;
    public Material materialGreen;

    public int ID;
    public int tilesPerRow;

    public Tile tileUpper;
    public Tile tileLower;
    public Tile tileLeft;
    public Tile tileRight;
    
/*    public Tile tileUpperS;
    public Tile tileLowerS;
    public Tile tileLeftS;
    public Tile tileRightS;*/

    public Tile tileUpperLeft;
    public Tile tileUpperRight;
    public Tile tileLowerLeft;
    public Tile tileLowerRight;
    
/*    public Tile tileUpperLeftS;
    public Tile tileUpperRightS;
    public Tile tileLowerLeftS;
    public Tile tileLowerRightS;
    
    public Tile tileUpperLeftS1;
    public Tile tileUpperLeftS2;
    public Tile tileUpperRightS1;
    public Tile tileUpperRightS2;
    public Tile tileLowerLeftS1;
    public Tile tileLowerLeftS2;
    public Tile tileLowerRightS1;
    public Tile tileLowerRightS2;*/

    public List<Tile> adjacentTiles = new List<Tile>();
    public int adjacentTarget = 0;

    public string state = "idle";

    private void Start()
    {
        gameObject.name = "Tile " + ID.ToString();

        if (inBounds(Grid.tilesAll, ID + tilesPerRow)) { tileUpper = Grid.tilesAll[ID + tilesPerRow]; }
        if (inBounds(Grid.tilesAll, ID - tilesPerRow)) { tileLower = Grid.tilesAll[ID - tilesPerRow]; }
        if (inBounds(Grid.tilesAll, ID + 1) && (ID + 1) % tilesPerRow != 0) { tileRight = Grid.tilesAll[ID + 1]; }
        if (inBounds(Grid.tilesAll, ID - 1) && ID % tilesPerRow != 0) { tileLeft = Grid.tilesAll[ID - 1]; }
        
/*        if (inBounds(Grid.tilesAll, ID + (2 * tilesPerRow))) { tileUpperS = Grid.tilesAll[ID + (2 * tilesPerRow)]; }
        if (inBounds(Grid.tilesAll, ID - (2 * tilesPerRow))) { tileLowerS = Grid.tilesAll[ID - (2 * tilesPerRow)]; }
        if (inBounds(Grid.tilesAll, ID + 2) && (ID + 2) % tilesPerRow != 0) { tileRightS = Grid.tilesAll[ID + 2]; }
        if (inBounds(Grid.tilesAll, ID - 2) && ID % tilesPerRow != 0) { tileLeftS = Grid.tilesAll[ID - 2]; }*/

        if (inBounds(Grid.tilesAll, ID + tilesPerRow + 1) && (ID + tilesPerRow + 1) % tilesPerRow != 0) { tileUpperRight = Grid.tilesAll[ID + tilesPerRow + 1]; }
        if (inBounds(Grid.tilesAll, ID + tilesPerRow - 1) && ID % tilesPerRow != 0) { tileUpperLeft = Grid.tilesAll[ID + tilesPerRow - 1]; }
        if (inBounds(Grid.tilesAll, ID - tilesPerRow + 1) && (ID + 1) % tilesPerRow != 0) { tileLowerRight = Grid.tilesAll[ID - tilesPerRow + 1]; }
        if (inBounds(Grid.tilesAll, ID - tilesPerRow - 1) && ID % tilesPerRow != 0) { tileLowerLeft = Grid.tilesAll[ID - tilesPerRow - 1]; }
        
/*        if (inBounds(Grid.tilesAll, ID + tilesPerRow + 2) && (ID + tilesPerRow + 2) % tilesPerRow != 0) { tileUpperRightS = Grid.tilesAll[ID + tilesPerRow + 2]; }
        if (inBounds(Grid.tilesAll, ID + tilesPerRow - 2) && ID % tilesPerRow != 0) { tileUpperLeftS = Grid.tilesAll[ID + tilesPerRow - 2]; }
        if (inBounds(Grid.tilesAll, ID - tilesPerRow + 2) && (ID + 2) % tilesPerRow != 0) { tileLowerRightS = Grid.tilesAll[ID - tilesPerRow + 2]; }
        if (inBounds(Grid.tilesAll, ID - tilesPerRow - 2) && ID % tilesPerRow != 0) { tileLowerLeftS = Grid.tilesAll[ID - tilesPerRow - 2]; }*/

/*        if (inBounds(Grid.tilesAll, ID + (2 * tilesPerRow) + 1) && (ID + (2 * tilesPerRow) + 1) % tilesPerRow != 0) { tileUpperRightS1 = Grid.tilesAll[ID + (2 * tilesPerRow) + 1]; }
        if (inBounds(Grid.tilesAll, ID + (2 * tilesPerRow) + 2) && (ID + (2 * tilesPerRow) + 2) % tilesPerRow != 0) { tileUpperRightS2 = Grid.tilesAll[ID + (2 * tilesPerRow) + 2]; }
        if (inBounds(Grid.tilesAll, ID + (2 * tilesPerRow) - 1) && ID % tilesPerRow != 0) { tileUpperLeftS1 = Grid.tilesAll[ID + (2 * tilesPerRow) - 1]; }
        if (inBounds(Grid.tilesAll, ID + (2 * tilesPerRow) - 2) && ID % tilesPerRow != 0) { tileUpperLeftS2 = Grid.tilesAll[ID + (2 * tilesPerRow) - 2]; }
        if (inBounds(Grid.tilesAll, ID - (2 * tilesPerRow) + 1) && (ID + 1) % tilesPerRow != 0) { tileLowerRightS1 = Grid.tilesAll[ID - (2 * tilesPerRow) + 1]; }
        if (inBounds(Grid.tilesAll, ID - (2 * tilesPerRow) + 2) && (ID + 2) % tilesPerRow != 0) { tileLowerRightS2 = Grid.tilesAll[ID - (2 * tilesPerRow) + 2]; }
        if (inBounds(Grid.tilesAll, ID - (2 * tilesPerRow) - 1) && ID % tilesPerRow != 0) { tileLowerLeftS1 = Grid.tilesAll[ID - (2 * tilesPerRow) - 1]; }
        if (inBounds(Grid.tilesAll, ID - (2 * tilesPerRow) - 2) && ID % tilesPerRow != 0) { tileLowerLeftS2 = Grid.tilesAll[ID - (2 * tilesPerRow) - 2]; }*/

        if (tileUpper) { adjacentTiles.Add(tileUpper); }
        if (tileLower) { adjacentTiles.Add(tileLower); }
        if (tileLeft) { adjacentTiles.Add(tileLeft); }
        if (tileRight) { adjacentTiles.Add(tileRight); }
        
/*        if (tileUpperS) { adjacentTiles.Add(tileUpperS); }
        if (tileLowerS) { adjacentTiles.Add(tileLowerS); }
        if (tileLeftS) { adjacentTiles.Add(tileLeftS); }
        if (tileRightS) { adjacentTiles.Add(tileRightS); }*/

        if (tileUpperLeft) { adjacentTiles.Add(tileUpperLeft); }
        if (tileUpperRight) { adjacentTiles.Add(tileUpperRight); }
        if (tileLowerLeft) { adjacentTiles.Add(tileLowerLeft); }
        if (tileLowerRight) { adjacentTiles.Add(tileLowerRight); }
        
/*        if (tileUpperLeftS) { adjacentTiles.Add(tileUpperLeftS); }
        if (tileUpperRightS) { adjacentTiles.Add(tileUpperRightS); }
        if (tileLowerLeftS) { adjacentTiles.Add(tileLowerLeftS); }
        if (tileLowerRightS) { adjacentTiles.Add(tileLowerRightS); }*/
        
/*        if (tileUpperLeftS1) { adjacentTiles.Add(tileUpperLeftS1); }
        if (tileUpperLeftS2) { adjacentTiles.Add(tileUpperLeftS2); }
        if (tileUpperRightS1) { adjacentTiles.Add(tileUpperRightS1); }
        if (tileUpperRightS2) { adjacentTiles.Add(tileUpperRightS2); }
        if (tileLowerLeftS1) { adjacentTiles.Add(tileLowerLeftS1); }
        if (tileLowerLeftS2) { adjacentTiles.Add(tileLowerLeftS2); }
        if (tileLowerRightS1) { adjacentTiles.Add(tileLowerRightS1); }
        if (tileLowerRightS2) { adjacentTiles.Add(tileLowerRightS2); }*/

        CountTarget();
    }

    private void CountTarget()
    {
        foreach (Tile currentTile in adjacentTiles)
        {
            if (currentTile.isTarget)
            {
                adjacentTarget += 1;
            }
        }

        displayText.text = adjacentTarget.ToString();

        if (adjacentTarget <= 0)
        {
            displayText.text = "";
        }
    }

    private bool inBounds(Tile[] inputArray, int targetID)
    {
        if (targetID < 0 || targetID >= inputArray.Length)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void OnMouseOver()
    {
        if (state == "idle")
        {
            this.GetComponent<Renderer>().material = materialLightup;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(state == "idle")
            {
                ++Grid.clickCount;

                if (isTarget)
                {
                    ++Grid.score;
                    this.GetComponent<Renderer>().material = materialRed;
                }
                else if(adjacentTarget > 0)
                {
                    this.GetComponent<Renderer>().material = materialYellow;
                }
                else
                {
                    this.GetComponent<Renderer>().material = materialGreen;
                }
            }
            state = "uncovered";
        }
    }

    private void OnMouseExit()
    {
        if (state == "idle")
        {
            GetComponent<Renderer>().material = materialIdle;
        }
    }
}
