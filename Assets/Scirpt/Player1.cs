using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour {
	private Rigidbody rb;
	[SerializeField]
	private float speed;

	private Animator anim;

	[SerializeField]
	GameObject platform;

	[SerializeField]
	Text scoreUI;

	int score = 0;

	float _score = 0f;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb = this.GetComponent<Rigidbody>();
		rb.velocity = new Vector3(0f, 0f, speed);
	}
		
	private void ScoreUpdate()
	{
		_score += 5f * Time.deltaTime;
		score = Mathf.RoundToInt(_score);
		scoreUI.text = score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			rb.AddForce (0f, 5f, 0f, ForceMode.Impulse);
			anim.SetBool ("isrunning", false);
			anim.Play("Jumping");
		}

		ScoreUpdate ();
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Water") 
		{
			GameOver ();
		}
	}

	private void GameOver()
	{
		Debug.Log ("Game is over");
	}
}
