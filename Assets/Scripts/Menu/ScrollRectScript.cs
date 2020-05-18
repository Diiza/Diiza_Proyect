using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectScript : MonoBehaviour {
    private ScrollRect scrollRect;
    private bool mouseDown, buttonRight, buttonLeft;

    void Start () {
        scrollRect = GetComponent<ScrollRect> ();
    }

    void Update () {
        if (mouseDown == true) {
            if (buttonRight == true) {
                ScrollRight ();
            } else if (buttonLeft == true) {
                ScrollLeft ();
            }
        }

    }

    public void buttonRightIsPressed () {
        mouseDown = true;
        buttonRight = true;
    }

    public void buttonLeftIsPressed () {
        mouseDown = true;
        buttonLeft = true;
    }

    private void ScrollRight () {
        if (Input.GetMouseButtonUp (0)) {
            mouseDown = false;
            buttonRight = false;
        } else {
            scrollRect.horizontalNormalizedPosition -= 0.01f;
        }
    }

    private void ScrollLeft () {
        if (Input.GetMouseButtonUp (0)) {
            mouseDown = false;
            buttonLeft = false;
        } else {
            scrollRect.horizontalNormalizedPosition += 0.01f;
        }
    }
}