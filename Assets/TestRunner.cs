using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRunner : MonoBehaviour {

	void Start () {
		Debug.Log(string.Format("Gem color is: {0}", Gem.Red));
	}
}
