using UnityEngine;
using UnityEngine.UI;
public class VolumeControll : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 0.5f);
            load();
        }
        else
        {
            load();
        }
    }
    public void onVolumeChange()
    {
        audioSource.volume = slider.value;
        save();
    }

    private void save()
    {
        PlayerPrefs.SetFloat("MusicVolume", slider.value);

    }

    private void load()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume");
    }
}
