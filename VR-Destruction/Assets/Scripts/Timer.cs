using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeLeft = 60;
    public Text countdownText;

    public AudioClip beep;
    public AudioClip gameOverV;
    public AudioClip gameOverJ;
    public AudioSource clips;


    //public bool timeUp;  will use this to also write game over, or instanciate a prefab that tells you game over

    // Use this for initialization
  


    public void TimerStart()
    {
        StartCoroutine("LoseTime");
        clips = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = ("Time Left: " + timeLeft + " seconds");

        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            countdownText.text = "Times Up!";
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;

            if(timeLeft > 0 && timeLeft < 11 ) { clips.PlayOneShot(beep, 0.7F); }
            if (timeLeft <= 0) {
                clips.PlayOneShot(gameOverJ, 0.7F);
                clips.PlayOneShot(gameOverV, 0.7F);
            }

        }
    }
}