using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BreakableObject : MonoBehaviour
{


    PlayerScore playerScore;
    public GameObject areaOfEffect;
    public GameObject scoreKeeper;

    
    void Start()
    {
        
    }



    //void OnCollisionStay(Collision col)
    //{

    //    ContactPoint contact = col.contacts[0];

    //    if (col.gameObject.tag == "hammer" || col.gameObject.tag == "pickaxe" || col.gameObject.tag == "Axe")
    //    {
    //        if ((gameObject.GetComponent<Rigidbody>().isKinematic == true))
    //        {
    //            HammerScript hammer = col.gameObject.GetComponent<HammerScript>();
    //            hammer.ShowScore();


    //            StartCoroutine(DestroyWithDelay());

    //            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), unity.GetComponent<Collider>());

    //            gameObject.GetComponent<Rigidbody>().isKinematic = false;
    //            GameObject aoe = Instantiate(areaOfEffect, contact.point, Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y, gameObject.transform.rotation.eulerAngles.z + 90));
    //            aoe.GetComponent<AreaOfEffect>().setSize(col.relativeVelocity.magnitude);
    //            Destroy(aoe);
    //        }
    //    }
    //}

   public float minForce;

    public bool Started = false;

    public void MoveAbleObjects()
    {
        
        if(Started != true)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        Started = true;
    }

   
    private void OnCollisionEnter(Collision col)
    {
        if (col.impulse.sqrMagnitude > minForce) {
            return;
        }
        
            if (col.gameObject.tag != "breakable" && col.gameObject.tag != "plane" && col.gameObject.tag != "Untagged")
            {
                Debug.Log(col.gameObject.name + ": " + col.gameObject.tag);
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), col.collider);
            }
            
            ContactPoint contact = col.contacts[0];

        
       // if(Started == true) {
            if (col.gameObject.tag == "hammer" || col.gameObject.tag == "pickaxe" || col.gameObject.tag == "Axe")
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

                }

            }
       // }


    }

    IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}
