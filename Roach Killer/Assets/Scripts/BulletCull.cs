using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCull : MonoBehaviour
{
	void FixedUpdate()
	{
		Destroy(this.gameObject, 3);
	}
	
}
