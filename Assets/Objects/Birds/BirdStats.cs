using UnityEngine;

[CreateAssetMenu(fileName = "BirdStats", menuName = "Scriptable Objects/BirdStats")]
public class BirdStats : ScriptableObject
{
    public float jumpStrength;
    public Sprite[] spriteSetYellow;
    public Sprite[] spriteSetRed;
    public Sprite[] spriteSetGreen;
    public Sprite[] spriteSetBlue;
}
