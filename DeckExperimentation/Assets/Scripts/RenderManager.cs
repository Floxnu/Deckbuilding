using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderManager : MonoBehaviour {

	public MeshRenderer RenderRef;
	public BoxCollider ColliderRef;
	public Card cardRef;

	private void Awake() 
	{
		if(RenderRef == null || ColliderRef == null)
		{
			RenderRef = gameObject.GetComponent<MeshRenderer>();
			ColliderRef = gameObject.GetComponent<BoxCollider>();	
		}
	}

	public void EnableCollider(bool b)
	{
		if(b)
		{
			ColliderRef.enabled = true;
		}else
		{
			ColliderRef.enabled = false;
		}
	}
	public void EnableRenderer(bool b)
	{
		if(b)
		{
			RenderRef.enabled = true;
		}else
		{
			RenderRef.enabled = false;
		}
	}
	private void OnMouseDown() 
	{
		cardRef.Play();	
	}
}
