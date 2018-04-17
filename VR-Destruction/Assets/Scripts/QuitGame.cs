using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionStay(Collision col)
    {


        ContactPoint contact = col.contacts[0];

        if (col.gameObject.tag != "breakable" && col.gameObject.tag != "plane" && col.gameObject.tag != "Untagged")
        {
            // Debug.Log(col.gameObject.name + ": " + col.gameObject.tag);
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), col.collider);
        }

        if (col.gameObject.tag == "hammer" || col.gameObject.tag == "pickaxe" || col.gameObject.tag == "Axe")
        {
            if ((gameObject.GetComponent<Rigidbody>().isKinematic == true))
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                Application.Quit();
            }
        }
    }
}
