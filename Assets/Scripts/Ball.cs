using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	
	private bool hasStarted = false;

	private Vector3 padddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		padddleToBallVector = this.transform.position - paddle.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			this.transform.position = paddle.transform.position + padddleToBallVector;
			
			if(Input.GetMouseButtonDown(0)){
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2(2f,15f);
			}
		}	
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		
		Vector2 tweak = new Vector2(Random.Range(-0.5f,0.5f), Random.Range(-0.5f,0.5f));  
		if(hasStarted){
			rigidbody2D.velocity += tweak;
			audio.Play();
		}
		
	}
}
