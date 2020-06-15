using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameManager : MonoBehaviour {

    // Cards Management
    public List<Card> cards = new List<Card>();
    public Card[] deckOfCards = new Card[52];
    public GameObject[] cardHolders;
    public GameObject drawDeck;

    private void Start() {
        print("here we go");
        SetupDeck();
        DealCards();
    }

    void SetupDeck() {
        for(int i = 0; i < deckOfCards.Length; i++) {
            cards.Add(deckOfCards[i]);
        }
    }

    void DealCards() {
        for(int i = 0; i < cardHolders.Length; i++) {
            int cardToUse = Random.Range(0, cards.Count);
            cardHolders[i].GetComponent<CardHolder>().thisCard = cards[cardToUse];
            cards.RemoveAt(cardToUse);
        }
    }

}
