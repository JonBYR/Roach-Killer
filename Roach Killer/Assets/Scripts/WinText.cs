using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class WinText : MonoBehaviour
{
	public Text winText;
	void cockroachFree()
	{
		Countdown remainingTime = GetComponent<Countdown>();
		winText.text = ("Congratdulations! You have smooshed all the roaches! You had this many seconds left:" + (60 - remainingTime.timeLeft));
	}
}
