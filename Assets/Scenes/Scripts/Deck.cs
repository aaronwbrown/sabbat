using System.Collections;
using System.Collections.Generic;

public class Deck {

  public List<string> cardIds;

  public void Suffle() {

  }

  public string Top() {
  	return "";
  }

  public string PeakAt(int idx) {
  	return "";
  }

  public string TakeAt(string idx) {
  	return "";
  }

  public string TakeRand() {
  	return "";
  }

  public void AddTop(string cardId) {

  }

  public void AddBottom(string cardId) {

  }

  public int IdxFor(string cardId) {
  	return -1;
  }

  public bool Has(string cardId) {
  	return IdxFor(cardId) != -1;
  }

  public void AddAt(int idx, string cardId) {

  }

  public void Swap(int idx1, int idx2) {

  }
}
