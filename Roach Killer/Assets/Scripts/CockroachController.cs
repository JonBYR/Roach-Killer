using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockroachController : MonoBehaviour
{
	public Transform position1, position2;
	public float speed = 1.0f;
	public Transform startPosition;
	public Animator animator;
	SpriteRenderer sprRend;
	Vector3 nextPosition;

	

	// Start is called before the first frame update
	void Start()
	{
		sprRend = GetComponent<SpriteRenderer>();
		nextPosition = startPosition.position;
	}

	// Update is called once per frame
	void Update()
	{


		if (Vector3.Distance(transform.position, nextPosition) < 0.1f)
		{
			nextPosition = nextPosition == position1.position ? position2.position : position1.position;
			sprRend.flipX = !sprRend.flipX;
		}

		transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

	}
	private void OnDrawGizmos()
	{
		Gizmos.DrawLine(position1.position, position2.position);
	}

}
