using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bordure : MonoBehaviour {

    // Use this for initialization
    void OnTriggerEnter(Collider ol)
    {
        if (ol.gameObject.tag == Constantes.etiquettejoueur)
            Jeumanage.Instance.Meurt();
    }
}
