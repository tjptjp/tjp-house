using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class videocontroller : MonoBehaviour 
{
	public VideoPlayer sads;
	public VideoClip n1;
	public VideoClip n2;
	public VideoClip n3;
	// Use this for initialization
	public void playStart (int inf) 
	{
		switch (inf)
		{
			case 1:
			sads.clip=n1;
			break;
			case 2:
			sads.clip=n2;
			break;
			case 3:
			sads.clip=n3;
			break;
			default:
			break;
		}
		// gameObject.SetActive(true);
		sads.targetCameraAlpha = 1F;
		sads.loopPointReached+=EndReached;
		sads.Play();
	}
	void EndReached(VideoPlayer vPlayer)
	{
		// vPlayer.Stop();
		// vPlayer.time=0;
		vPlayer.targetCameraAlpha=0F;
		// gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
