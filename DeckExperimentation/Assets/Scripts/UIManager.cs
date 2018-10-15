using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text DrawText;
	public Text DiscardText;
	public Text HealthText;
	public Text ActionsText;
	public Text EnemyText;
	public Text EnemiesDefeatedText;
	public Text EnemyDamageText;

	private void Update() 
	{
		DrawText.text = DeckManager.instance.Library.Count.ToString();
		DiscardText.text = DeckManager.instance.Discard.Count.ToString();	
		HealthText.text = PlayerManager.instance.currentHealth + " / " + PlayerManager.instance.maxHealth;
		ActionsText.text = PlayerManager.instance.actionsAvailable + "  || " + PlayerManager.instance.actionsPerTurn;
		if(EnemyManager.instance.CurrentEnemy != null)
		{
			EnemyText.text = EnemyManager.instance.CurrentEnemy.currentHealth + " / " + EnemyManager.instance.CurrentEnemy.maxHealth;
		}
		EnemiesDefeatedText.text = "Enemies defeated: " + EnemyManager.instance.enemiesDefeated;
		EnemyDamageText.text = "Damage: " + EnemyManager.instance.enemyDamage;

	}
}
