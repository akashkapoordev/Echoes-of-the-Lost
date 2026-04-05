using UnityEngine;

public class Landmark : Entity, IInteractable
{
    public void Interact()
    {
        Debug.Log("interact");
    }

public override void Reveal()
    {
        base.Reveal();
        Debug.Log($"{gameObject.name} landmark revealed");
    }
}
