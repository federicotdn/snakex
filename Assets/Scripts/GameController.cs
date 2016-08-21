using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameGrid gameGrid;

	void Start () {
        gameGrid.SetupGrid();
	}
	
	void Update () {
	
	}
}
