using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int enemyMaxHealth = 50;
	public int enemyHealth { get { return enemyCurrentHealth; } }
	public int enemyCurrentHealth;
	public AudioClip cockroachClip;
	public CokroachesKilled deadRoach;
	public void enemyChangeHealth(int amount)
	{
		PlayerController playerAudio = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		enemyCurrentHealth = Mathf.Clamp(enemyCurrentHealth + amount, 0, enemyMaxHealth);
		if (enemyCurrentHealth <= 0)
		{
			Destroy(gameObject);
			deadRoach.roaches -= 1;
			playerAudio.PlaySound(cockroachClip);
		}
	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Bullet")
		{
			enemyChangeHealth(-50);
			Destroy(other.gameObject);
			Debug.Log("Damage Dealt");
			Debug.Log(enemyCurrentHealth);
		}
	}
}
