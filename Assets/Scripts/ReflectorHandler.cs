using UnityEngine;
using System.Collections;

public class ReflectorHandler : MonoBehaviour {
	
	public AudioClip emitAudio;	
	public float reflectLength = .5F;
	public Animation emitAnimationRef;

	
	private bool hasReflected = false;
	private AudioSource audioSourceRef;
	
	// Use this for initialization
	void Start () 
	{
		audioSourceRef = Camera.main.audio;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "reflectorEmission"
			&& collider.gameObject != emitAnimationRef.gameObject
			&& !hasReflected)
		{
			EmitReflection();
		}
	}
	
	void EmitReflection()
	{
		print ("HI!");
		hasReflected=true;
		emitAnimationRef.Play();
		audioSourceRef.PlayOneShot(emitAudio, 1);
	}
	
}
