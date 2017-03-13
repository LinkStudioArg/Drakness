using UnityEngine;
using System.Collections;

public class TileSpawn : MonoBehaviour {
    [SerializeField]
    private int defaultTileNumber = 10;
    [SerializeField]
    private tile[] tilePrefabs;
    [SerializeField]
    private bool isInfinite;
    private int currentSpawnedTiles = 0;
	private float positionToMove = 0;

    //public bool extend_on_x_or_z = true; //if true, we extend on z, else, on x.

    private enum Direction { LEFT, FORWARD,  RIGHT };   
    private Direction dir = Direction.FORWARD;   
    private Vector3 extendDirection;
    private GameObject tiles;
    [SerializeField]
    private Color[] colors;
    [SerializeField]
    private Color[] darkenColors;
    private int colorIndex;    
    [SerializeField]
    private GameObject[] items;
    private GameObject newTile;


    [System.Serializable]
    public struct tile
    {
        public GameObject tilePrefab;
        public Vector2 timeContraints;
    }
    
    

    void Start () {
        colorIndex = Random.Range(0, colors.Length);
       
        dir = Direction.FORWARD;
		if(tilePrefabs.Length != 0){
			positionToMove = tilePrefabs[0].tilePrefab.transform.localScale.z;
		}
		else{
			Debug.LogError("There are no Tile Prefabs");
			Debug.Break();
		}
        tiles = new GameObject("Tiles");
	}
	
	void Update () {
		if(currentSpawnedTiles < defaultTileNumber)
		{
            SelectNewTile();
			CreateTile(newTile);
			ReposSpawner();
		}
	}
    void SelectNewTile()
    {
        int index = Random.Range(0, tilePrefabs.Length);
        newTile = tilePrefabs[index].tilePrefab;
    }
    void DecodeDirection()
    {
        switch (dir)
        {
            case Direction.RIGHT:
                extendDirection = Vector3.right;
                break;
            case Direction.LEFT:
                extendDirection = -Vector3.right;
                break;
            default:
                extendDirection = Vector3.forward;
                break;
        }
    }

	private void ReposSpawner()
	{
        SelectNextDirection();
        DecodeDirection();
        transform.position = transform.position + extendDirection * 2;
	}

    private void SelectNextDirection()
    {
        switch (dir)
        {
            case Direction.RIGHT:
                dir = (Direction)Random.Range(1, 3);
                break;
            case Direction.LEFT:
                dir = (Direction)Random.Range(0,2);
                break;
            default:
                dir = (Direction)Random.Range(0, 3);
                break;
        }
    }

    private void CreateTile(GameObject tile)
	{
		if(tilePrefabs.Length != 0)
		{
			currentSpawnedTiles++;			
            GameObject go = (GameObject)Instantiate(tile, transform.position, Quaternion.identity);
            go.transform.SetParent( tiles.transform);
            CreateItem(go);
            ChangeColor(go);
        }
	}

    void ChangeColor(GameObject go)
    {
        go.GetComponentInChildren<MeshRenderer>().material.color =  colors[colorIndex];
        colorIndex++;
        if (colorIndex >= colors.Length)
        {
            colorIndex = 0;
        }
    }

    private void CreateItem(GameObject go)
    {
        int randomPower = Random.Range(0, items.Length);
        int randomProb = Random.Range(0, 10);
        if (randomProb > 7)
        {
            GameObject item = Instantiate(items[randomPower], go.transform.position + Vector3.up * 0.5f, Quaternion.identity);
            item.transform.SetParent(go.transform);
        }

    }

    public Color GetDarkColor()
    {
        if (darkenColors.Length > 0)
        {
            return darkenColors[Random.Range(0, darkenColors.Length)];
        }
        else
            return Color.black;
    }

    public void DecreaseTileNumber()
	{
        if(isInfinite)
		    currentSpawnedTiles--;		
	}
}
