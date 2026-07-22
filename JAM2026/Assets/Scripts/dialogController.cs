using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
public class dialogController : MonoBehaviour
{
    private AudioSource audioSource;

   public String[] text;
   public String[] whoIsTalking;
   public Sprite[] person;
   public AudioClip[] voice;
   public TextMeshProUGUI achualText;
   public GameObject canva;
   public SpriteRenderer spriteRenderer;
   private int pos = 0;
    
    private void start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && pos < text.Length)
        {
            audioSource.Stop();
            achualText.SetText(text[pos]);
            spriteRenderer.sprite = person[pos];
            audioSource.PlayOneShot(voice[pos]);

        }

    }

}
