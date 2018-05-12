using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCollider : MonoBehaviour {

    public float positionY = 0.81f;
    public Transform[] SPoints;
    public GameObject rout;
    public GameObject bordange;

    void OnTriggerEnter(Collider heurt)
    {
        //player has hit the collider
        if (heurt.gameObject.tag == Constantes.etiquettejoueur)
        {
            //find whether the next path will be straight, left or right
            int Pointalea = Random.Range(0, SPoints.Length);
            for (int i = 0; i < SPoints.Length; i++)
            {
                //instantiate the path, on the set rotation
                if (i == Pointalea)
                    Instantiate(rout, SPoints[i].position, SPoints[i].rotation);
                else
                {
                    //instantiate the border, but rotate it 90 degrees first
                    Vector3 rotation = SPoints[i].rotation.eulerAngles;
                    rotation.y += 90;
                    Vector3 position = SPoints[i].position;
                    position.y += positionY;
                    Instantiate(bordange, position, Quaternion.Euler(rotation));
                }
            }

        }
    }
}
