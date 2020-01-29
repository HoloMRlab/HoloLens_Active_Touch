using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonInput : MonoBehaviour, IInputClickHandler, IFocusable
{
    public UnityEvent onClick;

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void OnFocusEnter()
    {
    }

    public void OnFocusExit()
    {
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        GameObject.Find("LogText").GetComponent<TextMesh>().text += "clicked " + gameObject.name + "\n";
        if (onClick != null)
            onClick.Invoke();
    }
}