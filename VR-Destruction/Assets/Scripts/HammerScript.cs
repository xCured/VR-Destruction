using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public GameObject scoreTextPrefab;

    public void ShowScore(int points)
    {
        Instantiate(scoreTextPrefab, transform.position, Quaternion.identity);
        scoreTextPrefab.transform.LookAt(Camera.main.transform);
        ScoreScript showPoints = scoreTextPrefab.GetComponent<ScoreScript>();
        showPoints.showScore(points);
    }

}
