using UnityEngine;

public class ButtonSoundEffects : MonoBehaviour
{
    public AudioClip hoverSound;   
    public AudioClip clickSound;  

    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnHoverEnter()
    {
        audioSource.PlayOneShot(hoverSound);
    }

    public void OnButtonClick()
    {
        audioSource.PlayOneShot(clickSound);
    }
}