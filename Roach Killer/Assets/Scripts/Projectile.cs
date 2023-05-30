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
		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

		if ((gun.localEulerAngles.z < 90 && gun.localEulerAngles.z >= 0) || (gun.localEulerAngles.z < 360 && gun.localEulerAngles.z > 270))
			sprRend.flipY = false;
		else
			sprRend.flipY = true;

		if (Input.GetMouseButtonDown(0))
		{
			if (timer < 0)
			{

				animator.SetTrigger("isShoot");
				GameObject x = Instantiate(bulletPrefab, gun.position, gun.rotation);
				x.GetComponent<Rigidbody2D>().velocity = gun.right * 15.0f;
				timer = 1.0f;
				playerAudio.PlaySound(gunClip);
			}
		}
		

	}
}
