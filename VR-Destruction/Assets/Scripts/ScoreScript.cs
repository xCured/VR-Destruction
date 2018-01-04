using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScoreScript : MonoBehaviour {

    
    //public int scoreGained = 200;


    // Use this for initialization



    void Start () {
        DOTween.Init(true, true);

        //DOTween.To(() => transform.position.y, y => transform.position.y = y, transform.position.y + 0.5, 1);
        transform.DOMoveY(transform.position.y + 1, 1).OnComplete(() => Destroy(gameObject));
	}
}
