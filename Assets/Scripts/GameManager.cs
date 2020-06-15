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
    public GameObject[] columns;
    public GameObject drawDeck;

    private void Start() {
        SetupDeck();
        DealCards();
        ShowFaces();
    }

    void SetupDeck() {
        for(int i = 0; i < deckOfCards.Length; i++) {
            cards.Add(deckOfCards[i]);
        }
    }

    void DealCards() {
        for (int i = 0; i < columns.Length; i++) {
            int startingCards = columns[i].GetComponent<Column>().startingCards;
            GiveColumnCards(columns[i], startingCards);
        }
    }

    void GiveColumnCards(GameObject column, int numberOfCards) {
        for(int i = 0; i < numberOfCards; i++) {
            int cardToUse = Random.Range(0, cards.Count);
            GameObject thisCard = column.GetComponent<Column>().AddCardToColumn(cards[cardToUse]);
            column.GetComponent<Column>().cardsInColumn.Add(thisCard);
            cards.RemoveAt(cardToUse);
        }
    }

    void ShowFaces() {
        for (int i = 0; i < columns.Length; i++) {
            columns[i].GetComponent<Column>().SetupFaces();
        }


    }

}
