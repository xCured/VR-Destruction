using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArcadeBreakableObject : MonoBehaviour
{


    PlayerScore playerScore;
    public GameObject scoreKeeper;
    public GameObject areaOfEffect;
    Rigidbody rigid;

    public int multiplier = 4;

 //  public float minForce;
    private static int TimeLeft;
   public static bool moveableobj = true;


    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }
    //basically timer is int when that raches 0 the boolean doesnt change to true and idk why
    void Update()
    {
        //this updates the TimerLeft and syncs it to the timer.timeleft
        TimeLeft = Timer.timeLeft;
    //if the local timer is less than 0. It switches the mobableobj to true which means you cant move any objects
        if(TimeLeft <= 0)
        {
            moveableobj = true;
            //Scoreteller.whatsyourScore = false;
        }
    }

    private void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.tag != "breakable" && col.gameObject.tag != "plane" && col.gameObject.tag != "Untagged")
        {
            // Debug.Log(col.gameObject.name + ": " + col.gameObject.tag);
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), col.collider);
        }

        ContactPoint contact = col.contacts[0];
        if (moveableobj == true)
        {
            if (Timer.started == true)
            {
                {
                    if (col.gameObject.tag == "hammer" || col.gameObject.tag == "pickaxe" || col.gameObject.tag == "Axe" || col.gameObject.tag == "Clock")
                    {
                        if ((gameObject.GetComponent<Rigidbody>().isKinematic == true))
                        {
                            ScoreForEachObject scoreValue = gameObject.GetComponent<ScoreForEachObject>();
                            HammerScript hammer = col.gameObject.GetComponent<HammerScript>();
                            hammer.ShowScore(scoreValue.pointsAwarded);

                            // Get score keeper score
                            playerScore = scoreKeeper.GetComponent<PlayerScore>();

                            //get pointsgiven by object

                            int pointsAdded = scoreValue.pointsAwarded;

                            //add points given to score keeper
                            playerScore.score += pointsAdded;


                            StartCoroutine(DestroyWithDelay());

                            // Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), unity.GetComponent<Collider>());

                            gameObject.GetComponent<Rigidbody>().isKinematic = false;
                            GameObject aoe = Instantiate(areaOfEffect, contact.point, Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y, gameObject.transform.rotation.eulerAngles.z + 90));
                            aoe.GetComponent<AreaOfEffect>().setSize(col.relativeVelocity.magnitude);
                            Destroy(aoe);
                            // rigid.AddForce(col.impulse * (5) + col.impulse.normalized, ForceMode.Impulse);
                            rigid.AddForce(col.impulse * 0.02f, ForceMode.Impulse);


                        }


                    }
                }

            }
        }
    }

    IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
   
}
