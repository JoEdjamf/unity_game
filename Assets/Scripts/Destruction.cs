using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Detruit", tpsdevie);
    }

    void Detruit()
    {
        if (Jeumanage.Instance.Etatjeu != Etatjeu.Mort)
            Destroy(gameObject);
    }


    public float tpsdevie = 10f;
}
