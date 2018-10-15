using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseManager : MonoBehaviour {

	public static PurchaseManager instance;
	public List<Card> CardsForPurchase;
	public List<GameObject> allCardsAvailable;
	
	[SerializeField]
	private GameObject PurchaseScreen;
	[SerializeField]
	private List<TextMesh> cardTexts;
	private bool isEnabled = false;


	private void Awake() 
	{
		instance = this;	
	}
	private void Start() 
	{
		for(int i = 0; i < 4; i++)
		{
			int randomIndex = Random.Range(0, allCardsAvailable.Count);
			print(randomIndex);	
			GameObject currentCard = Instantiate(allCardsAvailable[randomIndex],Vector3.zero, Quaternion.identity);
			print(currentCard.GetComponent<Card>().Name);
			if(currentCard != null)
			{
				Card cardInCurrent = currentCard.GetComponent<Card>();
				CardsForPurchase.Add(cardInCurrent);
				cardTexts[i].text = "Cost: " + CardsForPurchase[i].Cost.ToString() + " enemies";
				CardsForPurchase[i].isInPurchase = true;
			}
		}
		ShowPurchaseScreen(false);
		
	}
	
	public void CardPurchased(Card purch)
	{
		DeckManager.instance.Discard.Add(purch);
		CardsForPurchase.Remove(purch);
		purch.isInPurchase = false;
		purch.EnableEverything(false);

		Card CurrentCard = Instantiate(allCardsAvailable[Random.Range(0, allCardsAvailable.Count)]).GetComponent<Card>();
		CardsForPurchase.Add(CurrentCard);
		CurrentCard.EnableEverything(true);
		
		for(int i = 0; i < 4; i++)
		{
			cardTexts[i].text = "Cost: " + CardsForPurchase[i].Cost.ToString() + " enemies";
			CardsForPurchase[i].isInPurchase = true;	
		}

	}
	
	public void ShowPurchaseScreen(bool activate)
	{
		PurchaseScreen.SetActive(activate);
		foreach(Card c in CardsForPurchase)
		{
			c.EnableEverything(activate);
			c.isInPurchase = true;
		}
		foreach(TextMesh t in cardTexts)
		{
			t.gameObject.SetActive(activate);
		}
		foreach(Card c in DeckManager.instance.Hand)
		{
			c.EnableEverything(!activate);
		}
	}

	public void ButtonScreen()
	{
		if(isEnabled)
		{
			ShowPurchaseScreen(false);
		} else
		{
			ShowPurchaseScreen(true);
		}
	}

	private void Update() 
	{
		for (int i = 0; i < CardsForPurchase.Count; i++)
		{
			CardsForPurchase[i].gameObject.transform.position = new Vector3(3 + 3*i, 0,0);
		}	
	}
}
