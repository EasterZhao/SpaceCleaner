using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//https://www.youtube.com/watch?v=9a6GyAbhLUk
public class AutoScroll : MonoBehaviour
{
    float speed = 50.0f;
    float boundaryTextEnd = 141.0f;

    RectTransform myTransform;
    [SerializeField]
    TextMeshProUGUI mainText;

    public GameObject exitPanel;
    void Start()
    {
        myTransform = gameObject.GetComponent<RectTransform>();
        StartCoroutine(AutoScrollText());
    }

    IEnumerator AutoScrollText()
    {
        // Whenever the current y position of the caption is less than the end position
        //The caption moves up until the condition is not met
        while (myTransform.localPosition.y < boundaryTextEnd)
        {
            myTransform.Translate(Vector3.up * speed * Time.deltaTime);
            yield return null;

        }
        // When the y position of the caption is greater than or equal to the end position
        // The Exit button appears
        if (myTransform.localPosition.y >= boundaryTextEnd)
        {
            exitPanel.SetActive(true);
        }
    }

}