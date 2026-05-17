using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource audioSource;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(hoverSound);
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
}