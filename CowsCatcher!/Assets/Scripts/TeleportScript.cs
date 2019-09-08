using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{

	public static Transform teleportOut;

	public static Vector3 outPosition;

	public static GameObject player;
    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		teleportOut = transform.GetChild(0);
		outPosition = teleportOut.position;
    }

	public static void TeleportPlayer()
	{
		player.transform.position = outPosition;
	}
}
