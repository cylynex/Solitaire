using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {

    [SerializeField] public List<Card> cardsInColumn = new List<Card>();
    [SerializeField] public int startingCards;
    [SerializeField] public Vector2 topCard;
    [SerializeField] public Vector2 cardIncrement;

    [SerializeField] GameObject cardHolder;
    [SerializeField] int currentNumCardsInColumn = 0;
    private void Start() {
        topCard = new Vector2(0, 110);
        cardIncrement = new Vector2(0, -15);
        print("column alive");
    }

    public void AddCardToColumn(Card card) {
        Vector2 spotToPlaceCard = GetNextCardLocation();
        print("Place card at: " + spotToPlaceCard);
        GameObject thisCard = Instantiate(cardHolder, spotToPlaceCard, Quaternion.identity, transform);
        thisCard.transform.localPosition = spotToPlaceCard;
        thisCard.GetComponent<CardHolder>().thisCard = card;
        currentNumCardsInColumn++;
    }

    Vector2 GetNextCardLocation() {
        float adjustment = topCard.y + (cardIncrement.y * currentNumCardsInColumn);
        return new Vector2(0, adjustment);
    }

}
