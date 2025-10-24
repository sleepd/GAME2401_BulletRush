using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "GameData/ItemData")]
public class ItemData : ScriptableObject
{
    public string Id;
    public string DisplayName;
    public Sprite Icon;
    public int MaxStack = 1;
}