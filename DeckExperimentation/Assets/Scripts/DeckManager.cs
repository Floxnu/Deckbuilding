using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour {

	public List<GameObject> Decklist;
	public List<Card> Discard = new List<Card>();
	public Stack<Card> Library = new Stack<Card>();
	public List<Card> Hand = new List<Card>();
	public static DeckManager instance;
	public List<Card> PlayedCards;


	private void Awake() 
	{
		instance = this;
	}
	private void Start() 
	{
		foreach (GameObject c in Decklist)
		{
			GameObject current = Instantiate(c);
			current.GetComponent<Card>().EnableEverything(false);
			Discard.Add(current.GetComponent<Card>());
		}
		Library = Shuffle(Discard);	
		EndTurn();
		EnemyManager.instance.NewEnemy(true);
	}
	public Stack<Card> Shuffle(List<Card> toShuffle)
	{
		Stack<Card> ShuffledList = new Stack<Card>(); 
		while (toShuffle.Count > 0)
		{
			int randomIndex = Mathf.RoundToInt(Random.Range(0, toShuffle.Count));
			ShuffledList.Push(toShuffle[randomIndex]);
			toShuffle.RemoveAt(randomIndex);
		}
		return ShuffledList;
	}
	public void Draw(int amount)
	{
		for (int i = 1; i <= amount; i++ )
		{	
			if(Library.Count <= 0 && Discard.Count != 0)
			{
				Library = Shuffle(Discard);
				Card cardDrawn = Library.Pop(); 
				cardDrawn.EnableEverything(true);
				Hand.Add(cardDrawn);
			}
			else if(Library.Count == 0 && Discard.Count == 0)
			{
				
			} else
			{
				Card cardDrawn = Library.Pop(); 
				cardDrawn.EnableEverything(true);
				Hand.Add(cardDrawn);
			}
		}
		
	}

	public void EndTurn()
	{
		if(Hand.Count > 0)
		{
			int toDiscard = Hand.Count;
			for(int i = 0; i < toDiscard; i++)
			{
				print(Hand[0].name);
				Hand[0].Discard();
			}
		}
		if(PlayedCards.Count > 0)
		{
			foreach (Card c in PlayedCards)
			{
				Discard.Add(c);	
			}
			PlayedCards.Clear();
		}
		PlayerManager.instance.Damage(EnemyManager.instance.enemyDamage);
		Draw(5);
		PlayerManager.instance.actionsAvailable = PlayerManager.instance.actionsPerTurn;
	}

	private void Update() 
	{
		if(Input.GetKeyDown(KeyCode.D))
		{
			if(Library.Count>0)
			{
				Draw(1);
			}
		}

	}
	
	
}
