using System;
using UnityEngine;
using CoordinateSystem;
using System.Collections.Generic;
using System.Linq;


public class InstantiateGemPrefabs : MonoBehaviour
{
    public Transform Prefab;
    void Start()
    {
        var game = new GameState();
        var board = game.Board;
        Debug.LogFormat("Board first row: [{0}, {1}, {2}, {3}, {4}]",
        	board.GemAt(0, 0), board.GemAt(1, 0), board.GemAt(2, 0), board.GemAt(3, 0), board.GemAt(4, 0));

        instantiateGems();
    }

    private void instantiateGems()
    {
        var cols = 5;
        var rows = 5;
        var max = 1;
        List<List<Array>> matrix = CoordinateSystem.GetCoordinates.Coordinates(cols, rows, max);
        foreach (var coordinateArray in matrix)
        {
            Instantiate(Prefab, new Vector3(1 * 2.0F, 0, 0), Quaternion.identity);
        }
    }
}
