using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact();
    void Activate();
    void DeInteract();
}

public interface IPickable
{
    void Pick();
}

public abstract class Interactions: ScriptableObject
{
    public float pressHoldTime = 0.5f;
    public string interactString = "Press E to interact";
    public bool isInteracting = false;

    public abstract void Activate(GameObject go, HudHandler hudHandler);
    public abstract void Deactivate(GameObject go, HudHandler hudHandler);
    public abstract void ShowInteractUI(GameObject go, HudHandler hudHandler);

    
}
