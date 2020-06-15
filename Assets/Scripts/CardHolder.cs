using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour {

    [SerializeField] GameObject blockingCard;
    [SerializeField] public Card thisCard;
    bool faceUp = false;

    private void OnMouseDown() {
        print("MouseDown - just start drag");
    }

    private void OnMouseDrag() {
        print("mousedrag");
    }

}
