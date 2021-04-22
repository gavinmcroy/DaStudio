using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private RawImage fadeImage;
    private Color _color;
    private bool _fadeOut;
    private bool _fadeIn = true;
    private bool _isTransitioningOnce = true;
    private bool _isLoading;
    private IEnumerator _coroutine;
    public static Fade Instance;
    private Canvas canvas;
    private String _sceneTransition;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }

    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        _color = fadeImage.GetComponent<RawImage>().color;
        fadeImage = fadeImage.GetComponent<RawImage>();
        _coroutine = Check();
    }

    public void StartTransition(String transition)
    {
        _sceneTransition = transition;
        canvas = GetComponent<Canvas>();
        canvas.sortingOrder = 1;
        _coroutine = Check();
        StartCoroutine(_coroutine);
    }

    private void Transition()
    {
        if (_fadeOut && _isTransitioningOnce)
        {
            if(_color.a<=0)
            {
                _fadeOut = false;
                _fadeIn = true;
                _isTransitioningOnce = false;
            }
            _color.a -= Time.deltaTime;
            fadeImage.color = _color;
        }
        else if (_fadeIn && _isTransitioningOnce)
        {
            if (_color.a>=1)
            {
                _fadeIn = false;
                _fadeOut = true;     
            }
            _color.a += Time.deltaTime;
            fadeImage.color = _color;
        }
        if (_color.a >= 1 && !_isLoading)
        {
            SceneManager.LoadScene(_sceneTransition);
            _isLoading = true;
        }
    }

    private void Reset()
    {
        _isTransitioningOnce = true;
        _fadeOut = false;
        _fadeIn = true;
        _isLoading = false;
        canvas.sortingOrder = 0;
    }

    IEnumerator Check()
    {
        while (_isTransitioningOnce)
        {
            yield return new WaitForSeconds(.0005f);
            Transition();
        }
        Reset();
    }
}
