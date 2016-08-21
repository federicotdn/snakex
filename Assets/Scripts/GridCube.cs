using UnityEngine;
using System.Collections;

public class GridCube : MonoBehaviour {

    private CubeState currentState = CubeState.EMPTY;

    public enum Direction {
        UP, DOWN, LEFT, RIGHT, NONE
    }

    public enum CubeState {
        BODY, HEAD, APPLE, EMPTY
    }

    public void SetCubeState(CubeState state) {
        Renderer ren = GetComponent<MeshRenderer>();
        currentState = state;

        switch (state) {
            case CubeState.BODY:
                ren.material.color = Color.blue;
                break;
            case CubeState.HEAD:
                ren.material.color = Color.blue;
                break;
            case CubeState.APPLE:
                ren.material.color = Color.red;
                break;
            case CubeState.EMPTY:
            default:
                ren.material.color = Color.grey;
                break;
        }
    }

    public bool IsApple() {
        return currentState == CubeState.APPLE;
    }

    public bool IsSnake() {
        return currentState == CubeState.BODY || currentState == CubeState.HEAD;
    }

    public GridCube GetNextCube(Direction dir, out bool changedSide) {
        changedSide = false;
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

        GridCube neighbour = GetNeighbourAt(direction);
        if (neighbour == null) {
            // Get neighbour on the other side of the cube (back)
            changedSide = true;
            return GetNeighbourAt(new Vector3(0, 0, 1));
        }

        return neighbour;
    }

    private GridCube GetNeighbourAt(Vector3 direction) {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, direction);
        if (Physics.Raycast(ray, out hit)) {
            GameObject go = hit.collider.gameObject;
            return go.GetComponent<GridCube>();
        }

        return null;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
