using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public static PlayerManager instance;
	
	[Header("Max Values")]
	public int maxHealth;

	public int actionsPerTurn;
	
	public int currentHealth;
	public int actionsAvailable;
	
	private void Awake() 
	{
		instance = this;	
	}
	void Start () 
	{
		currentHealth = maxHealth;
		actionsAvailable = actionsPerTurn;	
	}
	
	public void Damage(int amount)
	{
		currentHealth -= amount;
	}
	public void ModifyActions(int actionsToAdd)
	{
		actionsAvailable += actionsToAdd;
	}
	public void ModifyHealth(int healthToAdd)
	{
		currentHealth += healthToAdd;
		if(currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}
	}
}
