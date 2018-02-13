using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cuttableObject : MonoBehaviour
{


   // PlayerScore playerScore;
   // public GameObject scoreKeeper;
    // public GameObject areaOfEffect;
    
   
   

    Vector3 startRot;
    Vector3 startPos;
    Vector3 endRot;
    Vector3 endPos;

    

    //  public float minForce;
   // private static int TimeLeft;
   // public static bool moveableobj = true;


    private void Start()
    {
       
    }
    //basically timer is int when that raches 0 the boolean doesnt change to true and idk why
    void Update()
    {



    }

    private void OnEnter(Collider col)
    {


       /* if (col.gameObject.tag != "breakable" && col.gameObject.tag != "plane" && col.gameObject.tag != "Untagged")
        {
            // Debug.Log(col.gameObject.name + ": " + col.gameObject.tag);*/
            //Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), col.collider);
       

        //ContactPoint contact = col.contact;

        
            if (col.gameObject.tag == "cuttingTool")
            {


                 startRot = col.gameObject.transform.rotation.eulerAngles;
                startPos = col.gameObject.transform.position;

             
            }
        }


    
    


    private void OnTriggerExit(Collider col)
    {

        //if (col.gameObject.tag == "cuttingTool")
       // {


            
            endRot = col.gameObject.transform.rotation.eulerAngles;
            endPos = col.gameObject.transform.position;
            // Vector3 cutRot = (startRot + endRot) / 2;
            Vector3 cutPos = (startPos + endPos)/2;

            // Get score keeper score
           // playerScore = scoreKeeper.GetComponent<PlayerScore>();

            //get pointsgiven by object



            //add points given to score keeper





            // Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), unity.GetComponent<Collider>());

            // gameObject.GetComponent<Rigidbody>().isKinematic = false;
            GameObject blade = Instantiate(Resources.Load("blade"), transform.position,col.gameObject.transform.rotation) as GameObject;
           // Destroy(blade);
            //aoe.GetComponent<AreaOfEffect>().setSize(col.relativeVelocity.magnitude);
            //Destroy(aoe);
            // rigid.AddForce(col.impulse * (5) + col.impulse.normalized, ForceMode.Impulse);
            //rigid.AddForce(col.impulse * 1, ForceMode.Impulse);


       // }
       
    }
}
