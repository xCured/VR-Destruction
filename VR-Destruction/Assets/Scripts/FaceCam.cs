using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCam : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
