using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    void OnTriggerEnter(Collider collision)
    {
        //if the player hits one obstacle, it's game over
        if (collision.gameObject.tag == Constantes.etiquettejoueur)
        {
           Jeumanage.Instance.Meurt();
        }
    }
}
