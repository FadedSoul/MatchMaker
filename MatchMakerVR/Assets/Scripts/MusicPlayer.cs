using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public delegate void finishedPlaying();
	public static event finishedPlaying OnFinishedPlaying;

	AudioSource audioSource;

	void OnEnable()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		if(!audioSource.isPlaying){
			if(OnFinishedPlaying != null){
				OnFinishedPlaying();
			}
		}
	}
}
