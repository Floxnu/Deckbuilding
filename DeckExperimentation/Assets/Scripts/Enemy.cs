using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ScriptableObject {

	public int currentHealth = 100;
	public int maxHealth = 100;

	private void Awake() 
	{
		currentHealth = maxHealth;	
	}

	public void TakeDamage(int amount)
	{
		currentHealth += amount * -1;
		if(currentHealth <= 0)
		{
			EnemyManager.instance.NewEnemy(false);
		}
	}

}
