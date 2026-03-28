using UnityEngine;

public class Landmark : Entity, IInteractable, IRevealable
{
    public void Intercat()
    {
        Debug.Log("interact");
    }

    public override void Reveal()
    {
        base.Reveal();
    }
}
