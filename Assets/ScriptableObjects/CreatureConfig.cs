using UnityEngine;

[CreateAssetMenu(fileName ="NewCreature",menuName ="Echoes/Creatureconfig")]
public class CreatureConfig : ScriptableObject
{
    [field: SerializeField] public string creatureName { get; private set; }
    [field: SerializeField] public float maxHealth { get; private set; }
    [field: SerializeField] public float maxSpeed { get; private set; }
    [field: SerializeField] public float detectionRange { get; private set; }
    [field: SerializeField] public CreatureType creatureType { get; private set; }
}