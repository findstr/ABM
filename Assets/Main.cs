using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {
	public GameObject ROOT;
	// Use this for initialization
	void Start () {
		ABM.start("G:/windows/MAIN.bundle");
		while (ABM.init())
			;
		GOM.start();
		var img = GOM.instantiate("Assets/foo.prefab", ROOT.transform) as GameObject;
		Debug.Log("XXX:" + img);
	//	GOM.Destroy(img2);
	//	GOM.Destroy(img);
	}

	// Update is called once per frame
	void Update () {

	}
}
