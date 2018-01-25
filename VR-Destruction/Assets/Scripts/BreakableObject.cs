using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BreakableObject : MonoBehaviour {



    public GameObject areaOfEffect;


    void OnCollisionStay(Collision col) {

        ContactPoint contact = col.contacts[0];
        
        if (col.gameObject.tag == "hammer" || col.gameObject.tag == "pickaxe" || col.gameObject.tag == "Axe")
        {
            if ((gameObject.GetComponent<Rigidbody>().isKinematic == true))
            {
                HammerScript hammer = col.gameObject.GetComponent<HammerScript>();
                hammer.ShowScore();


                StartCoroutine(DestroyWithDelay());


                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                GameObject aoe = Instantiate(areaOfEffect, contact.point, Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y, gameObject.transform.rotation.eulerAngles.z + 90));
                aoe.GetComponent<AreaOfEffect>().setSize(col.relativeVelocity.magnitude);
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
