using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caméra : MonoBehaviour {
	[SerializeField]
	Transform cible;
	Vector3 offset;
	void Start () {
		offset = cible.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 posit = cible.transform.position - offset;
		this.transform.position = Vector3.Lerp (this.transform.position, posit, 1.5f);
	}
}
