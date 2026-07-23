using UnityEngine;

[CreateAssetMenu(fileName = "MapObjects", menuName = "Scriptable Objects/MapObjects")]
public class MapObjects : ScriptableObject
{
    public string sceneName;
    public string locationName;
    public int walkEnergyCost, walkHealthGain, walkTimeCost;
    public int carEnergyCost, carTimeCost, carPriceCost;
}