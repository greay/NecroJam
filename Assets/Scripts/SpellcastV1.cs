using UnityEngine;
using System.Collections;

public class SpellcastV1 : MonoBehaviour {
	
//	public SpellElement visualIndicator;
//	public Transform startTransform;
//	public Transform endTransform;
	
	public SpellElement elementPrefab;
	public int elementCount;
	public AudioClip[] elementClips;
	public SpellElement[] elements;
	public Transform[] startTransforms;
	public Transform[] endTransforms;
	
	public float innerRadius = 1f;
	public float outerRadius = 4f;
	
	bool showSpellInterface = false;
	
	public MouseLook[] mouseLookControls;

	// Use this for initialization
	public void CreateSpellInterface (int parameterCount) {
		if (showSpellInterface == true) {
			return;
		}
		
		showSpellInterface = true;

		if (mouseLookControls.Length > 0) {
			for (int i = 0; i < mouseLookControls.Length; i++) {
				mouseLookControls[i].enabled = false;
			}
		}
				
		elementCount = parameterCount;
		float radianBetweenElements = (Mathf.PI*2)/elementCount;
		elements = new SpellElement[elementCount];
		startTransforms = new Transform[elementCount];
		endTransforms = new Transform[elementCount];
		
		// position all elements around the inner radius
		for (int i = 0; i < elementCount; i++) {
			Transform container = new GameObject ("Spell Element " + i).transform;
			container.parent = transform;
			container.localPosition = Vector3.up*0.9f;
			container.localRotation = Quaternion.identity;
			
			Vector3 elementPosition = Vector3.forward*2;
			// Start position / inner radius
			elementPosition.x = Mathf.Cos (radianBetweenElements*i) * innerRadius;
			elementPosition.y = Mathf.Sin (radianBetweenElements*i) * innerRadius;
			startTransforms[i] = new GameObject("Start Position " + i).transform;
			startTransforms[i].parent = container;
			startTransforms[i].localPosition = elementPosition;
			
			
			// End position / outer radius
			elementPosition.x = Mathf.Cos (radianBetweenElements*i) * outerRadius;
			elementPosition.y = Mathf.Sin (radianBetweenElements*i) * outerRadius;
			endTransforms[i] = new GameObject("End Position " + i).transform;
			endTransforms[i].parent = container;
			endTransforms[i].localPosition = elementPosition;
			
			
			// the element itself
			elements[i] = (SpellElement) Instantiate (elementPrefab);
			elements[i].name = "Element " + i;
			elements[i].transform.parent = container;
			elements[i].audio.clip = elementClips[i];
			elements[i].audio.Play();
						
			elements[i].SetManager (this);
//			elements[i].SetStartEndPoints(startTransforms[i].position, endTransforms[i].position);
			
		}
	}
	
	public void DestroySpellInterface () {
		if (!showSpellInterface) {
			return;
		}
		
		showSpellInterface = false;

		if (mouseLookControls.Length > 0) {
			for (int i = 0; i < mouseLookControls.Length; i++) {
				mouseLookControls[i].enabled = true;
			}
		}
		
		for (int i = 0; i < elementCount; i++) {
			Destroy (elements[i].transform.parent.gameObject);
			Destroy (elements[i].gameObject);
			Destroy (startTransforms[i].gameObject);
			Destroy (endTransforms[i].gameObject);
		}
		
		elements = new SpellElement[0];
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			CreateSpellInterface(elementCount);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			DestroySpellInterface();
		}
		
		for (int i = 0; i < elements.Length; i++) {
			elements[i].transform.localPosition = Vector3.Lerp (startTransforms[i].localPosition, endTransforms[i].localPosition, elements[i].positionPercentage);
		}
	}
		
	void OnDrawGizmos () {
		Gizmos.DrawWireSphere (transform.position, innerRadius);
		Gizmos.DrawWireSphere (transform.position, outerRadius);
	}
}
