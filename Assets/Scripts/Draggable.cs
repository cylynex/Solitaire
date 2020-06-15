using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    [SerializeField] Vector2 startingPosition;

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("onbegindrag");
        print("grabbing start location");
        startingPosition = eventData.position;
        print(eventData);
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("dragging");
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("end drag");


    }

    void OnCollisionEnter2D(Collision2D collision) {
        print("here");
    }

}