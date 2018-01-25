using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void closeOnClick()
    {
        Destroy(gameObject);
    }
}
