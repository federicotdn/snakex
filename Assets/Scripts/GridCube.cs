using UnityEngine;
using System.Collections;

public class GridCube : MonoBehaviour {

    public enum Direction {
        UP, DOWN, LEFT, RIGHT
    }

	// Use this for initialization
	void Start () {
	
	}

    public GridCube GetNextCube(Direction dir) {
        RaycastHit hit;
        Vector3 direction;
        switch (dir) {
            case Direction.UP:
                direction = new Vector3(0, 1, 0);
                break;
            case Direction.DOWN:
                direction = new Vector3(0, -1, 0);
                break;
            case Direction.LEFT:
                direction = new Vector3(-1, 0, 0);
                break;
            case Direction.RIGHT:
                direction = new Vector3(1, 0, 0);
                break;
            default:
                return null;
        }

        return null;//remove
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
