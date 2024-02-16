using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public GameObject bulletPrefab;
	public Transform gun;
	float timer = 0.5f;
	public float speed = 3.0f;
	public Animator animator;
	public AudioClip gunClip;
	SpriteRenderer sprRend;
	// Start is called before the first frame update
	private void Start()
	{
		sprRend = GetComponent<SpriteRenderer>();
	}
	void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		timer -= Time.deltaTime;
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		PlayerController playerAudio = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		transform.Rotate(0, 0, -3.0f);
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		difference.Normalize();
		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //angle of gun will be the angle between the vector between the mouse position and the gun position
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

		if ((gun.localEulerAngles.z < 90 && gun.localEulerAngles.z >= 0) || (gun.localEulerAngles.z < 360 && gun.localEulerAngles.z > 270))
			sprRend.flipY = false; //checks the angles of the gun to see whether the gun sprite needs to be flipped
		else
			sprRend.flipY = true;

		if (Input.GetMouseButtonDown(0))
		{
			if (timer < 0)
			{

				animator.SetTrigger("isShoot");
				GameObject x = Instantiate(bulletPrefab, gun.position, gun.rotation); //instantiates a bullet at the guns position and rotation
				x.GetComponent<Rigidbody2D>().velocity = gun.right * 15.0f; //gives bullet velocity
				timer = 1.0f;
				playerAudio.PlaySound(gunClip);
			}
		}
		

	}
}
