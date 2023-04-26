using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
        {
            Destroy(gameObject);
        }

    }


    [SerializeField] private AudioSource _effectSource;

    public void PlaySound(AudioClip clip){
        _effectSource.PlayOneShot(clip);
    }
}
