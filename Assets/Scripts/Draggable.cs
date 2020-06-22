using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    [SerializeField] public Vector2 startingPosition;
    
    void Start() {
        startingPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("onbegindrag");
        //startingPosition = eventData.position;
        print(eventData);
    }

    public void OnDrag(PointerEventData eventData) {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("end drag");
        GetComponent<BoxCollider2D>().enabled = true;
        // Check for valid placement

        // Normalize Placement

        // If failure, put card back
        //transform.position = startingPosition;

    }

    private void OnCollisionStay2D(Collision2D collision) {
        //print("Card Hitting: " + collision.gameObject.tag);
    }


}