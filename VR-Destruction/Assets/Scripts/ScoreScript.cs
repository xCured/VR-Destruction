using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DOTween.Init(true, true);
        transform.DOMoveY(transform.position.y + 1, 1).OnComplete(() => Destroy(gameObject));
        transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
