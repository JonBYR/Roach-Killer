using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Vector2 movement;
	public Animator animator;
	public float speed = 5.0f;
	public Rigidbody2D rigidbody2d;
	AudioSource audioSource;
	KeyCode right = KeyCode.RightArrow;
	KeyCode left = KeyCode.LeftArrow;
	// Start is called before the first frame update
	void Start()
    {
		audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
		movement.x = Input.GetAxisRaw("Horizontal");
		if (movement.x > 0)
		{
			animator.SetInteger("DirectionX", 1);
		}
		else if (movement.x < 0)
		{
			animator.SetInteger("DirectionX", -1);
		}
		else
		{
			animator.SetInteger("DirectionX", 0);
		}
	}
	private void FixedUpdate()
	{
		rigidbody2d.MovePosition(rigidbody2d.position + movement * speed * Time.fixedDeltaTime);
	}
	public void PlaySound(AudioClip clip)
	{
		audioSource.PlayOneShot(clip);
	}
}
