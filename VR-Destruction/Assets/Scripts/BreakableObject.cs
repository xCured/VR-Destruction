using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BreakableObject : MonoBehaviour {
    
    public GameObject scoreTextPrefab; 
    public GameObject areaOfEffect;
    public int score = 0;
    

    void OnStart()
    {
       
    }

    void OnCollisionEnter(Collision col) {

        ContactPoint contact = col.contacts[0];


        if (col.gameObject.tag == "hammer")
        {
            if ((col.relativeVelocity.magnitude > 0.4) && (gameObject.GetComponent<Rigidbody>().isKinematic == true))
            {
                HammerScript hammer = col.gameObject.GetComponent<HammerScript>();
                hammer.ShowScore();

                StartCoroutine(DestroyWithDelay());

                score = score + 200;
              
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                GameObject aoe = Instantiate(areaOfEffect, contact.point, Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y, gameObject.transform.rotation.eulerAngles.z + 90));
                aoe.GetComponent<AreaOfEffect>().setSize(col.relativeVelocity.magnitude);
                Debug.Log("hit");
                Destroy(aoe);
            }
        }
    }

    IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }
}
