﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
   
    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("onbegindrag");
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("dragging");
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("end drag");
    }

}