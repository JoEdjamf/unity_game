using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		//if the player hits one obstacle, it's game over
		if(col.gameObject.tag == Constants.PlayerTag)
		{
			GameManager.Instance.Die();
		}
	}
}
