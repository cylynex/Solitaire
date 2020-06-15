using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameManager : MonoBehaviour {

    // Cards Management
    public List<Card> cards = new List<Card>();
    public Card[] deckOfCards = new Card[52];
    public GameObject[] cardHolders;
    public GameObject drawDeck;

   

}
