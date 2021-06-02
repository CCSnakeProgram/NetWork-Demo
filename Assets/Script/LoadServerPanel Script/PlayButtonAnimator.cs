using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonAnimator : MonoBehaviour
{
    private Animator _animator;
    public GameObject LoadText;
    public static PlayButtonAnimator playButtonAnimator;
    
    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        playButtonAnimator = this;
    }

    public void PlayAnimator()
    {
        _animator.SetBool("isload",true);
        LoadText.SetActive(false);
    }
}
