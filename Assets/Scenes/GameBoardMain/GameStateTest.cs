using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateTest : MonoBehaviour {

    // This script is used in a test scene to exercise the GameState utility object
    void Start () {
        // var game = new GameState();

        test("One is equal to one", () => {
            if (1 != 1) {
                throw new Exception("Expected 1 to be == 1");
            }
        });
    }

    void test(string title, Action testBlock) {
        Debug.LogFormat("TEST: {0}", title);
        testBlock();
    }
}

