using System.Collections;
using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

public class FadeInAndOutCanvasAtStart : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _delayStartTime = 1f;
    [SerializeField] private float _fadeInTime = 0.5f;
    [SerializeField] private float _holdTime = 1f;
    [SerializeField] private float _fadeOutTime = 0.5f;

    private void Start ()
	{
	    if (!_canvasGroup)
	        _canvasGroup = GetComponent<CanvasGroup>();
	    if (_canvasGroup)
            StartCoroutine(CoFadeInAndOut());
	}

    private IEnumerator CoFadeInAndOut()
    {
        yield return new WaitForSeconds(_delayStartTime);
        yield return StartCoroutine(CoFadeCanvas(0f, 1f, _fadeInTime));
        yield return new WaitForSeconds(_holdTime);
        yield return StartCoroutine(CoFadeCanvas(1f, 0f, _fadeOutTime));
    }

    private IEnumerator CoFadeCanvas(float start, float end, float duration = 0.5f)
    {
        _canvasGroup.alpha = start;
        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            _canvasGroup.alpha = (Mathf.Lerp(start,end,timer/duration));
            yield return null;
        }

        _canvasGroup.alpha = end;
    }
}
