using UnityEngine;
using System.Collections;

public class InstantiateGemPrefabs : MonoBehaviour
{
    public Transform Prefab;
    void Start()
    {

    	// Get board from GameState
    	var gameState = GameObject.Find("GameState").GetComponent<GameState>();
    	var board = gameState.Board;
    	Debug.LogFormat("Board first row: [{0}, {1}, {2}, {3}, {4}]",
    		board.GemAt(0, 0), board.GemAt(1, 0), board.GemAt(2, 0), board.GemAt(3, 0), board.GemAt(4, 0));

        for (int i = 0; i < 10; i++)
        {
            Instantiate(Prefab, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        }
    }
}
