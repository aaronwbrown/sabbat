using System.Collections;
using System.Collections.Generic;

public class Player {
	public Deck SpellHand;
	public Deck SpellDeck;
	public Deck SpellDiscard;
	public GemsBag Gems;
	public List<Creature> Creatures;

	public int Points() {
		return 0; // total from invoked creatures
	}
}
