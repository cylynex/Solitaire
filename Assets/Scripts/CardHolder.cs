using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHolder : MonoBehaviour {

    [SerializeField] public GameObject blockingCard;
    [SerializeField] public Card thisCard;
    bool faceUp = false;
    
    public void SetupCard() {
        print("setupcard: "+thisCard.cardName);
        if (blockingCard == null) {
            FlipCard();
        }
    }

    void FlipCard() {
        print("flip this bitch");
        faceUp = true;
        GetComponent<Image>().sprite = thisCard.cardImage;
    }

}
