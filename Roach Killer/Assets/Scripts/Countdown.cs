using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
	public int timeLeft = 60;
	public Text countdown;
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine("LoseTime");
		Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
		countdown.text = ("Time Left:" + timeLeft);
		if (timeLeft <= 0)
		{
			SceneManager.LoadScene("GameOver");
		}
    }
	IEnumerator LoseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			timeLeft--;
		}
	}
}
