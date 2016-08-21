using UnityEngine;
using System.Collections;

public class GameGrid : MonoBehaviour {

    public int gridSize = 5;
    public GameObject gridCubeClone;

    public void SetupGrid() {
        if (gridSize % 2 == 0) {
            gridSize++;
        }

        gridSize = Mathf.Max(gridSize, 5);

        float finalGridSize = gridCubeClone.transform.transform.localScale.x * gridSize;
        float halfGridSize = finalGridSize / 2;

        for (int i = 0; i < gridSize; i++) {
            for (int j = 0; j < gridSize; j++) {
                for (int k = 0; k < gridSize; k++) {

                    // Dont add cubes at center of 3d grid
                    if ((k != 0 && k != gridSize - 1) && (j != 0 && j != gridSize - 1) && (i != 0 && i != gridSize - 1)) {
                        continue;
                    }

                    GameObject cube = Instantiate(gridCubeClone);
                    cube.transform.SetParent(transform);

                    Vector3 size = cube.transform.localScale;
                    float offset = halfGridSize - size.x / 2;
                    cube.transform.Translate(i * size.x - offset, j * size.x - offset, k * size.x - offset);
                }
            }
        }
    }
}
