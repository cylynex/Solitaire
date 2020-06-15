using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHolder : MonoBehaviour {

    [SerializeField] public GameObject blockingCard;
    [SerializeField] public Card thisCard;
    bool faceUp = false;

    private void OnMouseDown() {
        //print("MouseDown - just start drag");
    }

    private void OnMouseDrag() {
        //print("mousedrag");
    }

    public void SetupCard() {
        if (blockingCard == null) {
            FlipCard();
        }
    }

    void FlipCard() {
        faceUp = true;
        //GetComponent<SpriteRenderer>().sprite = thisCard.cardImage;
        GetComponent<Image>().sprite = thisCard.cardImage;
    }

}
