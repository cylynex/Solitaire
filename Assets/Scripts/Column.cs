using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {

    [SerializeField] public List<GameObject> cardsInColumn = new List<GameObject>();
    [SerializeField] public int startingCards;
    [SerializeField] public Vector2 topCard;
    [SerializeField] public Vector2 cardIncrement;

    [SerializeField] GameObject cardHolder;
    [SerializeField] int currentNumCardsInColumn = 0;
    private void Start() {
        topCard = new Vector2(0, 110);
        cardIncrement = new Vector2(0, -15);
    }

    public GameObject AddCardToColumn(Card card) {
        Vector2 spotToPlaceCard = GetNextCardLocation();
        GameObject thisCard = Instantiate(cardHolder, spotToPlaceCard, Quaternion.identity, transform);
        thisCard.transform.localPosition = spotToPlaceCard;
        thisCard.GetComponent<CardHolder>().thisCard = card;
        currentNumCardsInColumn++;

        CheckBlockCards(thisCard);

        return thisCard;
    }

    Vector2 GetNextCardLocation() {
        float adjustment = topCard.y + (cardIncrement.y * currentNumCardsInColumn);
        return new Vector2(0, adjustment);
    }

    void CheckBlockCards(GameObject thisCard) {
        if (currentNumCardsInColumn > 1) {
            int spotToBlock = currentNumCardsInColumn - 2;
            cardsInColumn[spotToBlock].GetComponent<CardHolder>().blockingCard = thisCard;
        }
    }

    public void SetupFaces() {
        print("setup faces for a column");
        for(int i = 0; i < cardsInColumn.Count; i++) {
            cardsInColumn[i].GetComponent<CardHolder>().SetupCard();
        }
    }

}
