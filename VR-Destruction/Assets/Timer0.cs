using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer0 : MonoBehaviour {

    
    public GameObject Menu;
    public int MenuShower;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        //Timer.timeLeft = MenuShower;

        if(Timer.timeLeft == 0)
        {
            
            Menu.SetActive(true);
            // gameObject.SetActive(true);
        }

        
    }
}
