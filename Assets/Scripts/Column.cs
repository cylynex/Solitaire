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
    
    public int nextCardValue;
    public string nextCardColor;

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
        UpdateBottomCard(thisCard);

        return thisCard;
    }

    /***** CARD SETUP STUFF *****/
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
        for(int i = 0; i < cardsInColumn.Count; i++) {
            cardsInColumn[i].GetComponent<CardHolder>().SetupCard();
        }
    }

    void UpdateBottomCard(GameObject thisCard) {
        int cardValue = thisCard.GetComponent<CardHolder>().thisCard.cardValue;
        string cardColor = thisCard.GetComponent<CardHolder>().thisCard.cardColor;

        if (cardColor == "Red") nextCardColor = "Black";
        else nextCardColor = "Red";

        nextCardValue = cardValue - 1;
    }


    private void OnCollisionStay2D(Collision2D collision) {
        print("column being Hit by: " + collision.gameObject.GetComponent<CardHolder>().thisCard.cardValue);

        GameObject newCard = collision.gameObject;
        Card cardData = newCard.GetComponent<CardHolder>().thisCard;

        newCard.GetComponent<BoxCollider2D>().enabled = true;

        if (
            cardData.cardColor == nextCardColor &&
            cardData.cardValue == nextCardValue
            ) {
            print("Match OK");
        }

        newCard.GetComponent<BoxCollider2D>().enabled = false;

    }


}
