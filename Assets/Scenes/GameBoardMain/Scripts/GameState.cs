using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
	public int Turn; // First turn is 1. Player1 plays on odd turns. Player2 plays on even.

	public Player Player1;
	public Player Player2;
	public Board Board;
	public InvocationArea InvocationArea;

	void Start () {
		Turn = 1;

		Player1 = new Player();
		Player2 = new Player();
		InvocationArea = new InvocationArea();
		Board = new Board();

		TestStuff();
	}

	// Cheap way of testing random stuff using Debug.LogFormat statements.
	void TestStuff() {
		Debug.LogFormat("Top card for Player1: {0}", Player1.Deck.PeakTop());
		Debug.LogFormat("Top card for Player2: {0}", Player2.Deck.PeakTop());
		Debug.LogFormat("Top-Left gem on the board: {0}", Board.GemAt(0, 0));
	}

	// Calculate current score for player1 and player2.
	// Points are calculated as the sum of points of the invoked creatures.
	// Some creatures have extra bonus points depending on the state of the board or the other player.
	private VictoryPoints CalculateVictoryPoints() {
		// TODO: implementation example (pseudocode) ...
		// for each cardId in Player1's creatures deck:
		//     creture = Creatures.Registry.Get(cardId)
		//     points += creture.CalculatePoints(Player1, Player2, Board, InvocationArea);
		return new VictoryPoints(){Player1 = 0, Player2 = 0};
	}
}

public struct VictoryPoints {
	public int Player1;
	public int Player2;
}

// Player
// Represents the state of either the local or remote player.
// It has the spells deck, spells in hand, discard pile, collected gems and invoked creatures.
public class Player {
	public Deck Deck;
	public Deck Hand;
	public Deck DiscardPile;
	public Deck Creatures;
	public GemsBag Gems;

	public Player() {
		Deck = new DefaultSpellsDeck();
		Deck.Shuffle();

		Hand = new Deck();
		Hand.AddToTop(Deck.TakeTop(3));

		DiscardPile = new Deck();

		Gems = new GemsBag();

		Creatures = new Deck();
	}
}

// Gem
// Gems are simply represented by their color. They are placed in the Board or in a GemsBag.
public enum Gem {
	Red,
	Gold,
	Green,
	Blue,
	Black
};

// CardId
// All the available cards in the game.
public enum CardId {
	Blank, // Zero-value blank card

	// Creatures
	Werewolf,
	Vampire,
	Blob,
	// ...

	// Spells
	TwoLovers,
	GemstoneRitual,
	Necronomicon
	// ...
}

// GemsBag
// Set of gems of different colors, with methods to add and remove gems from it.
// Initialized with zero gems by default, but can use color chain methods, for example:
// var gems = new GemsBag().Red(4).Green(6); // bag with 4 red and 6 green gems.
public class GemsBag {
	private Dictionary<Gem, int> gemCounts;

	public GemsBag() {
		gemCounts = new Dictionary<Gem, int>();
		Red(0).Gold(0).Green(0).Blue(0).Black(0);
	}

	public GemsBag Red(int gems) {
		gemCounts[Gem.Red] = gems; return this;
	}
	public GemsBag Gold(int gems) {
		gemCounts[Gem.Gold] = gems; return this;
	}
	public GemsBag Green(int gems) {
		gemCounts[Gem.Green] = gems; return this;
	}
	public GemsBag Blue(int gems) {
		gemCounts[Gem.Blue] = gems; return this;
	}
	public GemsBag Black(int gems) {
		gemCounts[Gem.Black] = gems; return this;
	}

	public void Add(Gem gem) {
		gemCounts[gem] += 1;
	}

	public Gem? Take(Gem gem) {
		return null;
	}

	public bool Has(Gem gem) {
		return false;
	}


	public int Count(Gem gem) {
		return 0;
	}

	public int CountTotal() {
		return 0;
	}
}

// InvocationArea
// Creatures that are available for invocation.
public class InvocationArea {
	public Deck Creatures; // 3 Creatures available for invocation.
	public Deck Pool; // all other Creatures in a queue to be revealed.
}

// Board
// 5x5 Matrix with the gems and methods to easily manipilate and read the board.
public class Board {
	private Gem[,] Gems;

	public Board() {
		Randomize();
	}

	public void Randomize() {
		Gems = new Gem[5,5]{
			{RandomGem(), RandomGem(), RandomGem(), RandomGem(), RandomGem()},
			{RandomGem(), RandomGem(), RandomGem(), RandomGem(), RandomGem()},
			{RandomGem(), RandomGem(), RandomGem(), RandomGem(), RandomGem()},
			{RandomGem(), RandomGem(), RandomGem(), RandomGem(), RandomGem()},
			{RandomGem(), RandomGem(), RandomGem(), RandomGem(), RandomGem()}
		};
	}

	// RandomGem
	static Gem[] _gemsColors = {Gem.Red, Gem.Gold, Gem.Green, Gem.Blue, Gem.Black};
	public static Gem RandomGem() {
		return _gemsColors[Random.Range(0,5)];
	}

	public Gem GemAt(int x, int y) {
	  return Gems[x, y];
	}


	public void AddAt(int x, int y) {

	}

	public void Swap(int x1, int y1, int x2, int y2) {

	}
}


public class Deck {
	private List<CardId> ids;

	public Deck() {
		ids = new List<CardId>();
	}

	public int Count() {
		return ids.Count;
	}

	public void Shuffle() {
		for (var i = 0; i < ids.Count; i++) {
            Swap(i, Random.Range(i, ids.Count));
		}
	}

	public CardId PeakTop() {
		return PeakAt(0);
	}

	public CardId PeakBottom() {
		return PeakAt(Count()-1);
	}

	public CardId PeakAt(int index) {
		return CardId.Blank; // TODO
	}

	public CardId TakeTop() {
		return TakeAt(0);
	}

	public Deck TakeTop(int count) {
		var taken = new Deck();
		for (int i = 0; i < count; i++) {
			taken.AddToBottom(TakeTop());
		}
		return taken;
	}

	public CardId TakeBottom() {
		return TakeAt(Count()-1);
	}

	public CardId TakeAt(int index) {
		return CardId.Blank; // TODO
	}

	public CardId TakeRand() {
		return TakeAt(Random.Range(0, Count()));
	}

	public void AddToTop(CardId id) {
		AddAt(0, id);
	}

	public void AddToTop(Deck deck) {
		for (int i = 0; i < deck.Count(); i++) {
			AddToTop(deck.TakeBottom());
		}
	}

	public void AddToBottom(CardId id) {
		AddAt(Count()-1, id);
	}

	public void AddAt(int index, CardId id) {
		// TODO
	}

	public int IndexOf(CardId id) {
		return ids.IndexOf(id);
	}

	public bool Has(CardId id) {
		return IndexOf(id) != -1;
	}

	public void Swap(int index1, int index2) {
		var temp = ids[index1];
		ids[index1] = ids[index2];
		ids[index2] = temp;
	}
}

public class DefaultSpellsDeck : Deck {
	public DefaultSpellsDeck() : base() {
		// Default Spells Deck
		AddToBottom(CardId.TwoLovers);
		AddToBottom(CardId.TwoLovers);
		AddToBottom(CardId.GemstoneRitual);
		AddToBottom(CardId.Necronomicon);
	}
}
