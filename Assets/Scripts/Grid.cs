using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid : MonoBehaviour
{
	public Tile tilePrefab;
	public int numberOfTiles = 10;
	public float distanceBetweenTiles = 1f;
	public int tilesPerRow = 4;
	public int numberOfTarget = 5;

	public static Tile[] tilesAll;
	public static ArrayList targetTiles;
	public static ArrayList nonTargetTiles;

	public static int clickCount = 0;
	public static int score = 0;

	void Start()
	{
		CreateTiles();
	}

    private void Update()
    {
        if(clickCount == 20)
        {
			if(score == 10)
            {
				Debug.Log("Win");
            }
            else
            {
				Debug.Log("Lose");
            }
        }
    }

    private void CreateTiles()
    {
		tilesAll = new Tile[numberOfTiles];

		float xOffset = 0f;
		float zOffset = 0f;

		for (int tilesCreated = 0; tilesCreated < numberOfTiles; tilesCreated++)
		{
			xOffset += distanceBetweenTiles;

			if (tilesCreated % tilesPerRow == 0)
			{
				zOffset += distanceBetweenTiles;
				xOffset = 0;
			}

			Tile newTile = (Tile)Instantiate(tilePrefab, new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z + zOffset), transform.rotation);
			newTile.ID = tilesCreated;
			newTile.tilesPerRow = tilesPerRow;
			tilesAll[tilesCreated] = newTile;
		}

		AssignTarget();
	}

    private void AssignTarget()
    {
		nonTargetTiles = new ArrayList(tilesAll);
		targetTiles = new ArrayList();

		for (int targetAssigned = 0; targetAssigned < numberOfTarget; targetAssigned++)
		{

			Tile currentTile = (Tile)nonTargetTiles[UnityEngine.Random.Range(0, nonTargetTiles.Count)];

			currentTile.GetComponent<Tile>().isTarget = true;

			//Add to Tiles mined
			targetTiles.Add(currentTile);
			//Remove from unmined
			nonTargetTiles.Remove(currentTile);
		}
	}
}
