using TMPro;
using UnityEngine;
using System.Collections;

public class TextRenderer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;

    [SerializeField] private float time;
    private Coroutine coroutine;
    [SerializeField] private CanvasGroup canvasGroup;

    private void Start()
    {
        //displayText.text = "Hi world";
        //displayText.maxVisibleCharacters = 10;
        //StartCoroutine(FadeOut());
    }

    IEnumerator AppearText()
    {
        int characterstoDisplay = 0;

        while (characterstoDisplay < displayText.text.Length)
        {
            characterstoDisplay++;
            displayText.maxVisibleCharacters = characterstoDisplay;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator DisappearText()
    {
        int characterstoDisplay = displayText.text.Length;

        while (characterstoDisplay > 0)
        {
            characterstoDisplay--;
            displayText.maxVisibleCharacters = characterstoDisplay;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FadeOut()
    {
        float transparency = canvasGroup.alpha;

        while (transparency > 0)
        {
            transparency -= (float) 0.1;
            canvasGroup.alpha = transparency;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FadeIn()
    {
        float alphaValue = canvasGroup.alpha;
        float transparency = 0;

        while (transparency < alphaValue)
        {
            transparency += (float) 0.1;
            canvasGroup.alpha = transparency;
            yield return new WaitForSeconds(0.1f);
        }
    }

    /*IEnumerator TextFadeIn()
    {
        float t = 0;

        while (t <= 3)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, t / 3);
            yield return null;
        }
    }

    IEnumerator TextFadeOut()
    {
        float t = 0;

        while (t <= 3)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, t / 3);
            yield return null;
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FadeIn());
        StartCoroutine(AppearText());
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(DisappearText());
        StartCoroutine(FadeOut());
    }
}