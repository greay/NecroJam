using UnityEngine;
using System.Collections;

public class SpellcastV1 : MonoBehaviour {
	
//	public SpellElement visualIndicator;
//	public Transform startTransform;
//	public Transform endTransform;
	
	public SpellElement elementPrefab;
	public int elementCount;
	public SpellElement[] elements;
	public Transform[] startTransforms;
	public Transform[] endTransforms;
	
	public float innerRadius = 1f;
	public float outerRadius = 4f;

	// Use this for initialization
	void Start () {
//		startTransform.renderer.enabled = false;
//		endTransform.renderer.enabled = false;
//		visualIndicator.SetManager (this);
//		visualIndicator.SetStartEndPoints(startTransform.position, endTransform.position);
		
		float radianBetweenElements = (Mathf.PI*2)/elementCount;
		elements = new SpellElement[elementCount];
		startTransforms = new Transform[elementCount];
		endTransforms = new Transform[elementCount];
		
		// position all elements around the inner radius
		for (int i = 0; i < elementCount; i++) {
			Transform container = new GameObject ("Spell Element " + i).transform;
			container.parent = transform;
			container.localPosition = Vector3.zero;
			
			Vector3 elementPosition = transform.position;
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
						
			elements[i].SetManager (this);
//			elements[i].SetStartEndPoints(startTransforms[i].position, endTransforms[i].position);
			
		}
	}
	
	// Update is called once per frame
	void Update () {
//		visualIndicator.transform.position = Vector3.Lerp (startTransform.position, endTransform.position, visualIndicator.positionPercentage);
		for (int i = 0; i < elementCount; i++) {
			elements[i].transform.localPosition = Vector3.Lerp (startTransforms[i].localPosition, endTransforms[i].localPosition, elements[i].positionPercentage);
		}
	}
	
	void OnDrawGizmos () {
		Gizmos.DrawWireSphere (transform.position, innerRadius);
		Gizmos.DrawWireSphere (transform.position, outerRadius);
	}
}
