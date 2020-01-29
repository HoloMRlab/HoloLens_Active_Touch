using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System.Collections;

internal class CylinderRotator : MonoBehaviour, IManipulationHandler
{
    //[HideInInspector]
    public float RotationSensitivity;

    private float Resist = 0;
    private AudioSource audioSource;

    [HideInInspector]
    public AudioClip audioClip;

    public float delta = 0.0f;
    private float rotdelta = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    public void Update()
    {
        if (delta == 0)
            return;
        float r = Resist * 100 * RotationSensitivity *
            Mathf.Clamp(delta, -0.01f, 0.01f);

        transform.Rotate(r, 0, 0);
        rotdelta += r;

        /*if (Mathf.Abs(rotdelta) < 10)
        {
            Resist = 0.8f;
        }*/
        if (Mathf.Abs(rotdelta) <= 30)
        {
            Resist = 0.5f;
        }
        /*else if (Mathf.Abs(rotdelta) < 30)
        {
            Resist = 0.8f;
        }*/
        else if (Mathf.Abs(rotdelta) > 30)
        {
            rotdelta = 0;
            if (audioSource != null && audioSource.clip != null)
                audioSource.Play();
        }
    }

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        foreach (var item in FindObjectsOfType<CylinderRotator>())
        {
            if (!item.Equals(this))
            {
                item.delta = 0;
            }
        }
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        delta = eventData.CumulativeDelta.y;
    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
        delta = 0;
    }

    public void OnManipulationCanceled(ManipulationEventData eventData)
    {
        delta = 0;
    }
}