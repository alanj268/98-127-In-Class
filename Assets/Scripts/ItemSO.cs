using UnityEngine;

[CreateAssetMenu(fileName="ItemSO", menuName = "Item")]
public class ItemSO : ScriptableObject
{
    public string name;

    public enum Type
    {
        Weapon, 
        Food, 
        Resource
    }

    public Type type;
    public Sprite sprite;
    public string description;
    
    public float weight;
    public float value;

    public bool isStackable;
}
