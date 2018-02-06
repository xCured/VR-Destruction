using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class SelectLevel2 : MonoBehaviour
{
    public int SceneIndex = SceneManager.GetActiveScene().buildIndex + 1;



    public GameObject areaOfEffect;

    void OnCollisionStay(Collision col)
    {
        ContactPoint contact = col.contacts[0];

        if (col.gameObject.tag == "hammer" || col.gameObject.tag == "pickaxe" || col.gameObject.tag == "Axe")
        {
            if ((gameObject.GetComponent<Rigidbody>().isKinematic == true))
            {
               


                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                GameObject aoe = Instantiate(areaOfEffect, contact.point, Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y, gameObject.transform.rotation.eulerAngles.z + 90));
                aoe.GetComponent<AreaOfEffect>().setSize(col.relativeVelocity.magnitude);
                Destroy(aoe);

                StartCoroutine(wait());
                
                
   

               
            }
        }
    }

    IEnumerator wait()
    {
    

        yield return new WaitForSeconds(2);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        





    }

}
