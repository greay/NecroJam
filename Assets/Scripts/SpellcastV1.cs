using UnityEngine;
using System.Collections;

public class SpellcastV1 : MonoBehaviour {
	
	public SpellElement visualIndicator;
	public Transform startTransform;
	public Transform endTransform;

	// Use this for initialization
	void Start () {
		startTransform.renderer.enabled = false;
		endTransform.renderer.enabled = false;
		visualIndicator.SetManager (this);
		visualIndicator.SetStartEndPoints(startTransform.position, endTransform.position);
	}
	
	// Update is called once per frame
	void Update () {
		visualIndicator.transform.position = Vector3.Lerp (startTransform.position, endTransform.position, visualIndicator.positionPercentage);
	}
}
