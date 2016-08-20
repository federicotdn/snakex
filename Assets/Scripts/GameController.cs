using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public uint gridSize = 5;
    public GameObject gridOrigin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void createGrid() {
        for (uint i = 0; i < gridSize; i++) {
            for (uint j = 0; j < gridSize; j++) {
                for (uint k = 0; k < gridSize; k++) {

                    if (i > 0 || i < gridSize - 1 || j > 0 || j < gridSize - 1 || k > 0 || k < gridSize - 1) {
                        // Skip the inside of the cube
                        continue;
                    }


                }
            }
        }
    }
}
