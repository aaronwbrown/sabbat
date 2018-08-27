using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour {
	public Dictionary<CardId, Spell> Registry;

	void Start () {
		// initialize spells Registry, with each subclass
		Registry = new Dictionary<CardId, Spell>();
		Register(new TwoLovers());
		// ...
	}

	void Register(Spell spell) {
		Registry.Add(spell.Id, spell);
	}
}

// Players use Spells to perform actions, often collecting gems from the board.
public abstract class Spell {
	public CardId Id;
	public string Name;
	public string Desc;

	// methods to do actions, etc ...
}

public class TwoLovers : Spell {
	public TwoLovers() {
		Id = CardId.TwoLovers;
		Name = "Two Lovers";
		Desc = "Colect two adjacent gems of the same color.";
	}
}
