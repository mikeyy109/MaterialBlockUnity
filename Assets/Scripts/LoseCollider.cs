﻿using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	void OnTriggerEnter2D(Collider2D Collider){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.LoadLevel("Lose");
	}

	/*void OnCollisionEnter2D(Collision2D colllision){
		print("Collision");
	}*/
}