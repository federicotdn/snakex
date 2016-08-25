using UnityEngine;
using System.Collections;
using System;

public class GridCube : MonoBehaviour {

    private CubeState currentState = CubeState.EMPTY;
    public CubeSide cubeSide = 0;

    [Flags]
    public enum CubeSide {
        FRONT = 1,
        BACK = 2,
        TOP = 4,
        BOTTOM = 8,
        LEFT = 16,
        RIGHT = 32
    }

    public enum Direction {
        UP, DOWN, LEFT, RIGHT, NONE
    }

    public enum CubeState {
        SNAKE, APPLE, EMPTY, HOLE
    }

    public void AddCubeSide(CubeSide s) {
        cubeSide |= s;
    }

    public bool SameSideAs(GridCube other) {
        return (other.cubeSide & cubeSide) != 0;
    }

    public void SetCubeState(CubeState state) {
        Renderer ren = GetComponent<MeshRenderer>();
        currentState = state;

        switch (state) {
            case CubeState.SNAKE:
                ren.material.color = Color.blue;
                break;
            case CubeState.APPLE:
                ren.material.color = Color.red;
                break;
            case CubeState.HOLE:
                ren.material.color = Color.black;
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

    public bool IsHole() {
        return currentState == CubeState.HOLE;
    }

    public bool IsSnake() {
        return currentState == CubeState.SNAKE;
    }

    public bool isEmpty() {
        return currentState == CubeState.EMPTY;
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
