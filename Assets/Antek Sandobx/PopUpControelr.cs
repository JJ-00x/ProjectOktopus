using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpControelr : MonoBehaviour
{
    [SerializeField] private float timer = 2f;

    [SerializeField] private TextMeshProUGUI popUp;
    // Start is called before the first frame update
    void Awake()
    {
        popUp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (popUp.enabled == true)
        {
            StartCoroutine(TextFade());
        }
    }

    IEnumerator TextFade()
    {
        Color originalColor = popUp.color; // Store the original color of the TextMeshProUGUI component

        float elapsedTime = 0f; // Initialize the elapsed time

        while (elapsedTime < timer)
        {
            elapsedTime += Time.deltaTime; // Increase the elapsed time by the time passed since the last frame

            // Calculate the current alpha value based on the elapsed time and the fade duration
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / timer);

            // Set the alpha value in the vertex color
            Color fadedColor = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            popUp.color = fadedColor;

            yield return null;
        }

        // Ensure the alpha value is set back to 1 when the fade out is complete
        Color fullyOpaqueColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
        popUp.color = fullyOpaqueColor;

        popUp.enabled = false; // Disable the TextMeshProUGUI component after the fading is complete
    }

}
