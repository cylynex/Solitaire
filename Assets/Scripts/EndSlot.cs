using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSlot : MonoBehaviour {

    bool hasSuit = false;
    public string suit;
    public List<Card> cardsOnPile = new List<Card>();
    public int topCardValue = 0;
    public int nextCardValue = 1;
    public Vector2 thisSlot;

    private void Start() {
        thisSlot = new Vector2(transform.position.x, transform.position.y);
    }

    private void OnCollisionStay2D(Collision2D collision) {

        Transform newCard = collision.gameObject.transform;

        // Get the card data
        Card hitCard = collision.gameObject.GetComponent<CardHolder>().thisCard;
        print("Card that hit: " + hitCard.cardSuit + " - " + hitCard.cardValue);

        // if match good, drop it here
        if (hasSuit) {
            if (hitCard.cardSuit == suit && hitCard.cardValue == nextCardValue) {
                print("suit matches, value is good, place the card");
                newCard.transform.position = transform.position;
            } else {
                print("no match, send it home");
                newCard.transform.position = newCard.gameObject.GetComponent<Draggable>().startingPosition;
                newCard.GetComponent<BoxCollider2D>().enabled = false;
            }
        } else {
            print("null suit yet, check for ace");
            if (hitCard.cardValue == 1) {
                print("found an ace!");
                suit = hitCard.cardSuit;
                topCardValue = hitCard.cardValue;
                nextCardValue += 1;
                hasSuit = true;
                GameObject finishedCard = collision.gameObject;
                this.GetComponent<Image>().sprite = finishedCard.GetComponent<Image>().sprite;
                Destroy(finishedCard);
            }
        }

        // if match bad, send it home

    }


}
