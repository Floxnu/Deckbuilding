using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour {


	public int startPosition = 0;
	public int endPosition = 20;
	private List<Card> handRef;
	private void Update() 
	{
		handRef = DeckManager.instance.Hand;
		if(handRef.Count != 0){
			float newCardPosition = endPosition * ((1.0f/(handRef.Count+1)));
			for(int i = 1; i <= handRef.Count; i++)
			{
				handRef[i-1].gameObject.transform.position = Vector3.Lerp(handRef[i-1].transform.position, new Vector3(newCardPosition * i,i -1,0), 0.1f);
			}	
		}
	}
}
