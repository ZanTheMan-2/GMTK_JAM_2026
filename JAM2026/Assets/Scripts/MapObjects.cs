using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "MapObjects", menuName = "Scriptable Objects/MapObjects")]
public class MapObjects : ScriptableObject
{
    public Scene areaScene;
    public int walkEnergyCost, walkHealthGain, walkTimeCost, carEnergyCost, carTimeCost;
    public string locationName;
}
