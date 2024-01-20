using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

	public float minVelo = 0.1f;
	private Vector3 lastMousePos;

	private Collider2D coll;

	private Rigidbody2D rb;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		coll = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        SetBladeToMouse();
        coll.enabled = IsMouseMoving();
	}

	private void SetBladeToMouse()
	{
		var mousePos = Input.mousePosition;
		mousePos.z = 10; // dist of 10 from the camera
		rb.position = Camera.main.ScreenToWorldPoint(mousePos);
	}

	private bool IsMouseMoving()
	{
		Vector3 currMousePos = transform.position;
		float traveled = (lastMousePos - currMousePos).magnitude;
		lastMousePos = currMousePos;

		if (traveled > minVelo)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
