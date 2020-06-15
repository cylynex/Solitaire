using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {

    [SerializeField] public List<Card> cardsInColumn = new List<Card>();

    private void Start() {
        print("column alive");
    }

}
