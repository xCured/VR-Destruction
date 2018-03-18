using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static int  timeLeft = 60;
    public Text countdownText;
    public static int TimeLeft2;

    

    public bool chris = true;
    public AudioClip beep;
    public AudioClip gameOverV;
    public AudioClip gameOverJ;
    public AudioSource clips;
    public static bool started = false;
   


    //

        

    //public bool timeUp;  will use this to also write game over, or instanciate a prefab that tells you game over

    // Use this for initialization
  void Start()
    {
        
       //StartCoroutine("LoseTime");
        
       // Debug.Log(timeLeft);
    }


    public void TimerStart()
    {

        StartCoroutine("LoseTime");
        clips = GetComponent<AudioSource>();
        started = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        // TimeLeft2 = timeLeft;
        LoseTime();
        countdownText.text = ("Time Left: " + timeLeft + " seconds");

        if (timeLeft <= 0)
        {
            
            StopCoroutine("LoseTime");
            countdownText.text = "Times Up!";
            if (chris == true)
            {
                clips.PlayOneShot(gameOverJ, 0.7F);
                clips.PlayOneShot(gameOverV, 0.7F);
                chris = false;
            }
        }
    }

     

    IEnumerator LoseTime()
    {
        while (true)
        {
            timeLeft--;
            yield return new WaitForSeconds(1);
           // timeLeft--;

            if(timeLeft > 0 && timeLeft < 11 ) {
                clips.PlayOneShot(beep, 0.7F);
            }
            //if (timeLeft <= 0) {
            //    clips.PlayOneShot(gameOverJ, 0.7F);
            //    clips.PlayOneShot(gameOverV, 0.7F);
                
            //}

        }
    }
}