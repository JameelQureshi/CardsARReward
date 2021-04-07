using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public Animator[] cardAnimators;
    public Material[] frontMaterials;
    public Sprite[] menus;
    public VideoClip[] videoClips;

    public GameObject confetti;
 

    public GameObject videoPlayer;
    public GameObject buyButton;
    public GameObject hologram;


    public static AnimationController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public void Shuffle()
    {
        foreach (Animator animator in cardAnimators)
        {
            animator.enabled = true;
        }
        Invoke(nameof(BringInCenter), 0.5f);
    }

    void BringInCenter()
    {
        GetComponent<Animator>().enabled = true;
       
    }

    public void OnAnimationFinished()
    {
        AnimationEvents.canClick = true;
        foreach (Animator animator in cardAnimators)
        {
            animator.gameObject.GetComponent<AnimationEvents>().RestoreFront();
            animator.SetTrigger("clicked");
        }
    }

    public void OnCardClicked(int index)
    {
        videoPlayer.SetActive(false);
        buyButton.SetActive(false);
        hologram.SetActive(false);

        confetti.GetComponent<AudioSource>().Play();
        confetti.GetComponent<ParticleSystem>().Play();



        

        if (index >= 0 && index <=5)
        {
            videoPlayer.SetActive(true);
            var vp = videoPlayer.GetComponent<VideoPlayer>();
            vp.clip = videoClips[index];
            vp.Play();

        }
        else if (index==6)
        {
            hologram.gameObject.SetActive(true);
        }
        else
        {
            buyButton.SetActive(true);
        }
       
    }

    

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }

    public void Reset()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}
