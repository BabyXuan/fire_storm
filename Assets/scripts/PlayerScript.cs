﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	/// <summary>
	/// 1 - The speed of the ship
	/// </summary>
	public Vector2 speed = new Vector2(1, 1);
	public float jumpSpeed = 9000000.0F;


	// 2 - Store the movement and the component
	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		// 4 - Movement per direction
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);

		// 5 - Jumping
		bool jump = Input.GetButtonDown("Jump");
		jump |= Input.GetButtonDown("Jump");
		if (jump){
			Jump();
		}

		// 6 - Shooting
		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		// Careful: For Mac users, ctrl + arrow is a bad idea

		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				// false because the player is not an enemy
				weapon.Attack(false);
			}
		}
	}

	void FixedUpdate()
	{
		// 5 - Get the component and store the reference
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

		// 6 - Move the game object
		rigidbodyComponent.velocity = movement;
	}

	void Jump() 
	{
//		rigidbodyComponent.AddForce(Vector2.up * 10);
//		rigidbodyComponent.AddForce(Vector2.down * 10);

		rigidbodyComponent.velocity = Vector2.zero;
		float timer = 0;
		//Add a constant force every frame of the jump
		rigidbodyComponent.AddForce(Vector2.up * 1000);
	    timer += Time.deltaTime;



	}
		
}