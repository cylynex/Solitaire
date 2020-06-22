using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHolder : MonoBehaviour {

    [SerializeField] public GameObject blockingCard;
    [SerializeField] public Card thisCard;
    bool faceUp = false;
    
    public void SetupCard() {
        if (blockingCard == null) {
            FlipCard();
        }
    }

    void FlipCard() {
        faceUp = true;
        GetComponent<Image>().sprite = thisCard.cardImage;
    }

}
