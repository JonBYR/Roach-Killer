using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
	public int rotationOffset = 90;
	SpriteRenderer spriteRenderer;
	// Update is called once per frame
	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	void Update()
	{
		//Vector3 newScale = transform.localScale;
		//newScale.x *= -1;
		//transform.localScale = newScale;
		transform.Rotate(0, 0, -3.0f);
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		difference.Normalize();
		//if (newScale.x - difference.x < 0)
		//{
		//	spriteRenderer.flipX = true;
		//}
		//if (newScale.x - difference.x > 0)
		//{
		//	spriteRenderer.flipX = false;
		//}
		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		rotZ = Mathf.Clamp(rotZ, 0, 180);
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 90);
		
	}
}
