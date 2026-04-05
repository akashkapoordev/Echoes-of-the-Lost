using UnityEngine;

public class Entity : MonoBehaviour, IRevealable
{
    protected bool IsRevealed = false;

public virtual void Reveal()
    {
        IsRevealed = true;
    }
}

