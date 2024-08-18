using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    private readonly float FadeOut = 0f;
    private readonly float FadeIn = 1f;
    private readonly float ScaleDuration = 1f;
    private readonly float NewScale = 1f;

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _playButton;

    [SerializeField] private Image[] _frames;
    [SerializeField] private CanvasGroup _blackout;
    [SerializeField] private float _fadeDuration;
    [SerializeField] private SuperGodlyCutsceneClass _animation;

    private int _currentFrameIndex;
    private float _startScale;

    private void OnEnable()
    {
        if (_startButton == null)
        {
            throw new ArgumentNullException(nameof(_startButton));
        }

        if (_continueButton == null)
        {
            throw new ArgumentNullException(nameof(_continueButton));
        }

        if (_frames.Length == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(_frames));
        }

        if (_blackout == null)
        {
            throw new ArgumentNullException(nameof(_blackout));
        }

        if (_playButton == null)
        {
            throw new ArgumentNullException(nameof(_playButton));
        }

        _startButton.onClick.AddListener(OnStart);
        _continueButton.onClick.AddListener(OnContinue);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStart);
        _continueButton.onClick.RemoveListener(OnContinue);
    }

    private void OnStart()
    {
        /*_startButton.gameObject.SetActive(false);
        _blackout.DOFade(FadeIn, _fadeDuration).OnComplete(() =>
        {
            _blackout.alpha = 0f;
            _frames[_currentFrameIndex].gameObject.SetActive(true);
            _currentFrameIndex++;
            _continueButton.transform.DOScale(NewScale, ScaleDuration);
        });*/
        _animation.gameObject.SetActive(true);
    }

    private void OnContinue()
    {
        int lastIndex = _frames.Length - 1;
        
        _continueButton.transform.localScale = Vector3.zero;

        _blackout.DOFade(FadeIn, _fadeDuration).OnComplete(() =>
        {
            _blackout.alpha = 0f;
            _frames[_currentFrameIndex].gameObject.SetActive(true);
            
            if (_currentFrameIndex == lastIndex)
            {
                _continueButton.gameObject.SetActive(false);
                _playButton.transform.DOScale(NewScale, ScaleDuration);
                return;
            }

            _currentFrameIndex++;
            _continueButton.transform.DOScale(NewScale, ScaleDuration);
        });
    }
}