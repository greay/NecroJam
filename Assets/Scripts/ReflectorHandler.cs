using UnityEngine;
using System.Collections;

public class ReflectorHandler : MonoBehaviour {
	
	public AudioClip[] emitAudio;	
	public float reflectLength = .5F;
	public Animation emitAnimationRef;

	
	private bool hasReflected = false;
	private AudioSource audioSourceRef;
	private float audioVolumeMax = 0.25F;
	
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
		hasReflected=true;
		emitAnimationRef.Play();
		
		int randomSound = Random.Range(0, emitAudio.Length);
		audioSourceRef.PlayOneShot(emitAudio[randomSound], Random.Range(0, audioVolumeMax) );
	}
	
}
