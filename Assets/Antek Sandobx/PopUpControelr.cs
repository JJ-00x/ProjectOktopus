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
        yield return new WaitForSeconds(timer);
        popUp.enabled = false;
        StopCoroutine(TextFade());
        yield return null;
     
    }
}
