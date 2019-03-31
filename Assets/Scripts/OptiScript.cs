using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OptiScript : MonoBehaviour
{
	public Tilemap tilemap;
	public Tile tileEmpty;
	public Tile tileFull;
	public Tile tileAntBlue;
	public Tile tileAntRed;
	public Tile tileAntGreen;
	public Tile tileAntYellow;
	public Tile tileAntPink;
	public int sizeMap = 100;
	public float UpdateTime = 0.025f;
	private Ant[] ants;
	private LangstonTileMap langmap;

	private void tickAnt(Ant ant)
	{
		langmap.changeTile(ant.getX(), ant.getY());
		if (langmap.getTile(ant.getX(), ant.getY()) == false)
		{
			ant.rotate(false);
			tilemap.SetTile(new Vector3Int(ant.getX() - (sizeMap / 2), ant.getY() - (sizeMap / 2), 0), tileEmpty);
		}
		else if (langmap.getTile(ant.getX(), ant.getY()) == true)
		{
			ant.rotate(true);
			tilemap.SetTile(new Vector3Int(ant.getX() - (sizeMap / 2), ant.getY() - (sizeMap / 2), 0), tileFull);
		}
		ant.move();
		checkBorders(ant);
	}

	private void checkBorders(Ant ant)
	{
		if (ant.getX() < 0)
			ant.setX(sizeMap - 1);
		else if (ant.getX() > sizeMap - 1)
			ant.setX(0);
		if (ant.getY() < 0)
			ant.setY(sizeMap - 1);
		else if (ant.getY() >  sizeMap - 1)
			ant.setY(0);
	}

	private IEnumerator TickRate()
	{
		while (true)
		{
			//LOGIQUE

			tickAnt(ants[0]);
			tickAnt(ants[1]);
			tickAnt(ants[2]);
			tickAnt(ants[3]);
			tickAnt(ants[4]);

			//AFFICHAGE
			tilemap.SetTile(new Vector3Int(ants[0].getX() - (sizeMap / 2), ants[0].getY() - (sizeMap / 2), 0), tileAntBlue);
			tilemap.SetTile(new Vector3Int(ants[1].getX() - (sizeMap / 2), ants[1].getY() - (sizeMap / 2), 0), tileAntRed);
			tilemap.SetTile(new Vector3Int(ants[2].getX() - (sizeMap / 2), ants[2].getY() - (sizeMap / 2), 0), tileAntGreen);
			tilemap.SetTile(new Vector3Int(ants[3].getX() - (sizeMap / 2), ants[3].getY() - (sizeMap / 2), 0), tileAntYellow);
			tilemap.SetTile(new Vector3Int(ants[4].getX() - (sizeMap / 2), ants[4].getY() - (sizeMap / 2), 0), tileAntPink);
			yield return new WaitForSeconds(UpdateTime);
		}
	}

	void Start()
	{
		ants = new Ant[5];
		ants[0] = new Ant(0, 0);
		ants[1] = new Ant(0, 0);
		ants[2] = new Ant(0, 0);
		ants[3] = new Ant(0, 0);
		ants[4] = new Ant(0, 0);
		ants[0].setX(200);
		ants[0].setY(200);
		ants[1].setX(300);
		ants[1].setY(200);
		ants[2].setX(200);
		ants[2].setY(300);
		ants[3].setX(300);
		ants[3].setY(300);
		ants[4].setX(250);
		ants[4].setY(250);
		langmap = new LangstonTileMap(sizeMap);
		for (int i = 0 ; i < sizeMap ; i++)
		{
			for (int j = 0 ; j < sizeMap ; j++)
			{
				tilemap.SetTile(new Vector3Int(i - (sizeMap / 2), j - (sizeMap / 2), 0), tileEmpty);
			}
		}
		StartCoroutine(TickRate());
	}
}
