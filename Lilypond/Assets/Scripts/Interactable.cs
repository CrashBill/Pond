using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] Animation interactionAnimation;
    [SerializeField] ChimeManager chimeManager;

    [Header("Interactions - Light")]
    [SerializeField] bool activateLight;
    [SerializeField] Light[] lights;
    bool lit = false;
    
    public void ActivateInteraction()
    {
        if (!interactionAnimation.isPlaying)
        {
            interactionAnimation.Play();
        }

        if (chimeManager != null)
        {
            //Queue new chime
        }

        if (activateLight && !lit)
        {
            ActivateLights();
        }
    }

    void ActivateLights()
    {
        foreach (Light l in lights)
        {
            l.enabled = true;
        }
    }
}
