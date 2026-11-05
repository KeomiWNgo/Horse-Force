using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
/*
 * Author: Jasmine Guzeldere
 * Date Created:11/04/2026
 * Date Edited: 11/05/2026
 * Edited By: Jasmine Guzeldere
 * Description: Image flashes red when player takes damage. Modular, uses coroutines.
 */
public class DamageFlash : MonoBehaviour
{
    public Image flashImage;
    public Color flashColor = new Color(1f, 0f, 0f, 0.6f); //red with some transparency, like me
    public float flashDuration = 0.5f;

    private Coroutine flashRoutine;

    public void TriggerFlash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(DoFlash());
    }

    private IEnumerator DoFlash()
    {
        float elapsedTime = 0f;
        //fade in quickly
        Color startColor = new Color(flashColor.r, flashColor.g, flashColor.b, 1f);
        Color endColor = new Color(flashColor.r, flashColor.g, flashColor.b, 0f);

        flashImage.color = startColor;

        while (elapsedTime < flashDuration)
        {
            elapsedTime += Time.deltaTime;
            flashImage.color = Color.Lerp(startColor, endColor, elapsedTime / flashDuration);
            yield return null;
        }

        flashImage.color = endColor;
    }
}
