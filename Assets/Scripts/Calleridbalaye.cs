using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calleridbalaye : MonoBehaviour {

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == Constantes.etiquettejoueur)
            Jeumanage.Instance.peutbalayer = true;
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.tag == Constantes.etiquettejoueur)
            Jeumanage.Instance.peutbalayer = false;
    }
}
