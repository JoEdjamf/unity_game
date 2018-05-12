using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class sucre : MonoBehaviour {

    // Use this for initialization
    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * vitessederotation);
    }

    void OnTriggerEnter(Collider col)
    {
        Manage.Instance.ajourScore(PointsScore);
        Destroy(this.gameObject);
    }

    public int PointsScore = 100;
    public float vitessederotation = 50f;
}
