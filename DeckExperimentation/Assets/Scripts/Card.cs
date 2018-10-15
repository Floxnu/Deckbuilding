using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBase]
public class Card : MonoBehaviour {
	public string Name;
	public int Cost;
	public RenderManager RenderMan;
	private TextMesh cardText;
	public bool isInPurchase = false;
	public enum Effects {Draw, Deal, Heal, Action}
	public Effects[] cardEffects;

	[Header("Effect Values")]
	public int cardsToDraw;
	public int actionsToGain;
	public int damageToDeal;
	public int healthToHeal;

	private string refreshText()
	{
		string cardTextOutput = null;
		foreach (Effects f in cardEffects)
		{
			switch(f)
			{
				case Effects.Draw:

					cardTextOutput += "Draw " + cardsToDraw + "\n";
					break;

				case Effects.Deal:
					cardTextOutput += "Deal " + damageToDeal + "\n";
					break;

				case Effects.Heal:
					cardTextOutput += "Heal " + healthToHeal + "\n";
					break;

				case Effects.Action:

					cardTextOutput += "Add " + actionsToGain + "\n";
					break;

				default:
					break;
			}
		}	
		return cardTextOutput;
	}
	public void Effect()
	{
		foreach (Effects f in cardEffects)
		{
			switch(f)
			{
				case Effects.Draw:

					DeckManager.instance.Draw(cardsToDraw);
					break;

				case Effects.Deal:
					EnemyManager.instance.CurrentEnemy.TakeDamage(damageToDeal);
					break;

				case Effects.Heal:

					PlayerManager.instance.ModifyHealth(healthToHeal);
					break;

				case Effects.Action:

					PlayerManager.instance.ModifyActions(actionsToGain);
					break;

				default:
					break;
			}
		}
	}

	private void Awake() 
	{
		cardText = GetComponentInChildren<TextMesh>();
		cardText.text = refreshText();
	}

	public void Play()
	{
		if(isInPurchase == true)
		{
			if(EnemyManager.instance.enemiesDefeated >= Cost)
			{
				print("GotBought!!!");
				PurchaseManager.instance.CardPurchased(this);
				EnemyManager.instance.enemiesDefeated -= Cost;
			}
		} else
		{

			if(PlayerManager.instance.actionsAvailable > 0)
			{
				Effect();
				--PlayerManager.instance.actionsAvailable;
				toPlayed();
			}
		}
	
	}

	public void Discard()
	{
		DeckManager.instance.Hand.Remove(this);
		DeckManager.instance.Discard.Add(this);
		EnableEverything(false);
	}
	public void toPlayed()
	{
		DeckManager.instance.Hand.Remove(this);
		DeckManager.instance.PlayedCards.Add(this);
		EnableEverything(false);
	}

	public void EnableEverything(bool b)
	{
		this.gameObject.transform.position = new Vector3(-5, 2, -2);
		RenderMan.EnableCollider(b);
		RenderMan.EnableRenderer(b);
		cardText.gameObject.SetActive(b);
	}

}
