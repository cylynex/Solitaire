using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour {

    [SerializeField] public List<GameObject> blockingCards = new List<GameObject>();

    private void OnMouseDown() {
        print("MouseDown - just start drag");
    }

    private void OnMouseDrag() {
        print("mousedrag");
    }

}
