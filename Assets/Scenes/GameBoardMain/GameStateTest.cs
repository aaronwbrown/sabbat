using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateTest : MonoBehaviour {

    // This script is used in a test scene to exercise the GameState utility object
    void Start () {
        var game = new GameState();

        test("Player has at least one card", () => {
            if (1 != 1) {
                throw new Exception("foobar");
            }
        });
    }

    void test(string title, Action testBlock) {
        p("TEST: {0}", title);
        testBlock();
    }
    void p(string format, params object[] args) {
        Debug.LogFormat(format, args);
    }
}

