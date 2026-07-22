using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
public class dialogController : MonoBehaviour
{
    public AudioSource audioSource;
    public SceneManagey sceneManagey;
   public String[] text;
   public String[] whoIsTalking;
   public Sprite[] person;
   public AudioClip[] voice;
   public TextMeshProUGUI achualText, whoIsTalkingText;
   public GameObject canva;
   public SpriteRenderer spriteRenderer;
   private int pos = 0;
    
   
    private void Update()
    {
         try
        {
            if(Input.GetKeyDown(KeyCode.Space))
        {
            //audioSource.Stop();
            achualText.SetText(text[pos]);
            whoIsTalkingText.SetText(whoIsTalking[pos]);
            spriteRenderer.sprite = person[pos];
            audioSource.PlayOneShot(voice[pos]);
            pos++;
        }
        }
        catch
        {
            sceneManagey.SwitchScene("Map");
        }   
    }
}
