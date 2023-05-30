using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class CokroachesKilled : MonoBehaviour
{
	public int roaches;
	public Text roachesText;
	private void Start()
	{
		roaches = 18;
	}
	private void Update()
	{
		roachesText.text = ("Roaches to smoosh:" + roaches);
		if (roaches <= 0)
		{
			SceneManager.LoadScene("Win");
		}
	}
}
