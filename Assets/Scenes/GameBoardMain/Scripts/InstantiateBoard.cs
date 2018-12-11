using System;
using UnityEngine;
using System.Collections.Generic;


public class InstantiateBoard : MonoBehaviour
{
    public Transform Prefab;
    void Start()
    {
    	// Get board from GameState
    	GameState gameState = new GameState();
    	var board = gameState.Board;
    	Debug.LogFormat("Board first row: [{0}, {1}, {2}, {3}, {4}]",
    		board.GemAt(0, 0), board.GemAt(1, 0), board.GemAt(2, 0), board.GemAt(3, 0), board.GemAt(4, 0));
        instantiateBoard(board);
    }

    private void instantiateBoard(Board board)
    {
        var matrix = Board.Gems;
        foreach (var coordinateArray in matrix)
        {
            Instantiate(Prefab, new Vector3(1 * 2.0F, 0, 0), Quaternion.identity);
        }
    }
}
