using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreteller : MonoBehaviour {

    //public GameObject AfterEnd;
    public static bool whatsyourScore = true;

   // BreakableObject.movableobj
    // Use this for initialization

        //if its false it dont move.
        //if its true it moves.
    void Start () {
       

	}
	
	// Update is called once per frame
	void Update () {
     
        if (whatsyourScore == false)
        {
            Appear();
        }

		
	}

    void Appear() {
      gameObject.SetActive(true);
       

    }

}
