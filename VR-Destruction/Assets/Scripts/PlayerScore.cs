using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

  


    //public bool timeUp;  will use this to also write game over, or instanciate a prefab that tells you game over

    // Use this for initialization



   

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ("Score: " + score + " points");

       
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
          

        }
    }
}