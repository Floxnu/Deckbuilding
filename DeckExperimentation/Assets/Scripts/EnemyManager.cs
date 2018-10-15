using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public static EnemyManager instance;
	public Enemy CurrentEnemy;
	public int enemiesDefeated;
	public int enemyDamage;

	private void Awake() {
		instance = this;
	}
	public void DealDamage()
	{
		PlayerManager.instance.ModifyHealth(enemyDamage * -1);
	}

	public void NewEnemy(bool isFirst)
	{
		if(CurrentEnemy != null)
		{
			Destroy(CurrentEnemy);
		}
		CurrentEnemy = ScriptableObject.CreateInstance<Enemy>();
		if(!isFirst)
		{
			enemiesDefeated++;
		}
		enemyDamage += 5;
	}

}
