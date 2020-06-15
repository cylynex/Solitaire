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
    public GameObject[] columns;
    public GameObject drawDeck;

    private void Start() {
        SetupDeck();
        DealCards();
        SetupHolders();
    }

    void SetupDeck() {

        cardHolders = GameObject.FindGameObjectsWithTag("CardHolder");

        for(int i = 0; i < deckOfCards.Length; i++) {
            cards.Add(deckOfCards[i]);
        }
    }

    void DealCards() {
        
        /*for(int i = 0; i < cardHolders.Length; i++) {
            int cardToUse = Random.Range(0, cards.Count);
            cardHolders[i].GetComponent<CardHolder>().thisCard = cards[cardToUse];
            cards.RemoveAt(cardToUse);
        }*/

        for (int i = 0; i < columns.Length; i++) {
            int startingCards = columns[i].GetComponent<Column>().startingCards;
            print("populating column " + i + " - Gets cards: " +startingCards);
            GiveColumnCards(columns[i], startingCards);


        }
    }

    void GiveColumnCards(GameObject column, int numberOfCards) {
        for(int i = 0; i < numberOfCards; i++) {
            int cardToUse = Random.Range(0, cards.Count);
            //cardHolders[i].GetComponent<CardHolder>().thisCard = cards[cardToUse];
            column.GetComponent<Column>().cardsInColumn.Add(cards[cardToUse]);
            column.GetComponent<Column>().AddCardToColumn(cards[cardToUse]);
            cards.RemoveAt(cardToUse);
        }
    }


    void SetupHolders() {
        for (int i = 0; i < cardHolders.Length; i++) {
            cardHolders[i].GetComponent<CardHolder>().SetupCard();
        }
    }

}
