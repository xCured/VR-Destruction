using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BreakableObject : MonoBehaviour
{


    
    public GameObject areaOfEffect;
    

   public float minForce;
    private static int TimeLeft;
   public static bool moveableobj = true;

    

    //basically timer is int when that raches 0 the boolean doesnt change to true and idk why
    void Update()
    {
        //this updates the TimerLeft and syncs it to the timer.timeleft
        TimeLeft = Timer.timeLeft;
    //if the local timer is less than 0. It switches the mobableobj to true which means you cant move any objects
        if(TimeLeft <= 0)
        {
            moveableobj = false;
            Scoreteller.whatsyourScore = false;
        }
       

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.impulse.sqrMagnitude > minForce)
        {
            return;
        }

        if (col.gameObject.tag != "breakable" && col.gameObject.tag != "plane" && col.gameObject.tag != "Untagged")
        {
           // Debug.Log(col.gameObject.name + ": " + col.gameObject.tag);
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), col.collider);
        }

        ContactPoint contact = col.contacts[0];


        if (moveableobj == true)
        {
            if (col.gameObject.tag == "hammer" || col.gameObject.tag == "pickaxe" || col.gameObject.tag == "Axe")
            {
                if ((gameObject.GetComponent<Rigidbody>().isKinematic == true))
                {
                    HammerScript hammer = col.gameObject.GetComponent<HammerScript>();
                    hammer.ShowScore();



                    StartCoroutine(DestroyWithDelay());

                    // Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), unity.GetComponent<Collider>());

                    gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    GameObject aoe = Instantiate(areaOfEffect, contact.point, Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y, gameObject.transform.rotation.eulerAngles.z + 90));
                    aoe.GetComponent<AreaOfEffect>().setSize(col.relativeVelocity.magnitude);
                    Destroy(aoe);

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
