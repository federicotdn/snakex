using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameGrid gameGrid;
    public float inputCooldown = 1;
    public int appleCount = 5;
    public bool enableRotation = true;

    private GridCube.Direction lastDirection = GridCube.Direction.RIGHT;
    private float lastInputTime = 0;

    void Start() {
        gameGrid.SetupGrid(enableRotation, appleCount);
        SetupCamera();
	}
	
	void Update() {
        lastInputTime += Time.deltaTime;
        if (lastInputTime > inputCooldown) {
            lastInputTime = 0;

            GridCube.Direction dir = ReadInput();

            if (dir == GridCube.Direction.NONE || AreOpposite(dir, lastDirection)) {
                dir = lastDirection;
            }

            lastDirection = dir;

            Debug.Log("Read direction:");
            Debug.Log(dir);

            GameGrid.MoveResult result = gameGrid.MoveHead(dir);
            switch (result) {
                case GameGrid.MoveResult.DIED:
                    Debug.Log("You died!");
                    gameObject.SetActive(false);
                    break;
                case GameGrid.MoveResult.ERROR:
                    Debug.Log("An error occured.");
                    gameObject.SetActive(false);
                    break;
                case GameGrid.MoveResult.ROTATING:
                default:
                    // pass
                    break;
            }
        }
	}

    void SetupCamera() {
        float frustumHeight = gameGrid.GetGridSizeWorld();
        float distance = frustumHeight / Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);
        Camera.main.transform.Translate(0, 0, -distance);
    }

    private bool AreOpposite(GridCube.Direction a, GridCube.Direction b) {
        if ((a == GridCube.Direction.DOWN && b == GridCube.Direction.UP) || 
            (a == GridCube.Direction.UP && b == GridCube.Direction.DOWN)) {
            return true;
        }

        if ((a == GridCube.Direction.RIGHT && b == GridCube.Direction.LEFT) ||
            (a == GridCube.Direction.LEFT && b == GridCube.Direction.RIGHT)) {
            return true;
        }

        return false;
    }

    private GridCube.Direction ReadInput() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            return GridCube.Direction.UP;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            return GridCube.Direction.DOWN;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            return GridCube.Direction.RIGHT;
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            return GridCube.Direction.LEFT;
        }

        return GridCube.Direction.NONE;
    }
}
