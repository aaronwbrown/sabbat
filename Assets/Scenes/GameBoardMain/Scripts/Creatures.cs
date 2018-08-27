using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creatures : MonoBehaviour {
	public Dictionary<CardId, Creature> Registry;

	void Start () {
		// initialize creatures Registry, with each subclass
		Registry = new Dictionary<CardId, Creature>();
		Register(new Vampire());
		// ...
	}

	void Register(Creature creature) {
		Registry.Add(creature.Id, creature);
	}
}

// Players invoke creatures using their gems, Creatures add victory points and other in-game advantages.
public abstract class Creature {
	public CardId Id;
	public string Name;
	public string Desc;
	public int Points; // initial points, the final value may be different
	public GemsBag InvocationCost;

	public int CalculatePoints(Player owner, Player opponent, Board board, InvocationArea invocationArea) {
		return Points; // overriden by subclasses
	}
}

public class Vampire : Creature {
	public Vampire() {
		Id = CardId.Vampire;
		Name = "Vampire";
		Desc = "When your opponent collects Red gems, you take one of those Reg gems.";
		Points = 3;
		InvocationCost = new GemsBag().Red(6).Black(3);
	}
}
