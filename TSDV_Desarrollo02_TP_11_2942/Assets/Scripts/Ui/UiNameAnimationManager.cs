using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiNameAnimationManager : MonoBehaviour
{
    public List<UiNameAnimation> texts = new List<UiNameAnimation>();
    public GameObject panelBlockRaycast;
    private float onTime;
    public float maxTimeTitle;
    private float timePerText;
    private int actualIndex;
    public float maxScale;

    void Start()
    {
        if (panelBlockRaycast) panelBlockRaycast.SetActive(true);
        timePerText = maxTimeTitle / texts.Count;
    }

    void Update()
    {
        onTime += Time.deltaTime;
        for (int i = actualIndex; i < texts.Count; i++)
        {
            if (onTime > timePerText * i)
            {
                texts[i].gameObject.SetActive(true);
                texts[i].GetComponent<UiNameAnimation>().initialScale = maxScale;
                texts[i].GetComponent<UiNameAnimation>().timePerText = timePerText;
                actualIndex++;
            }
            break;
        }

        if (onTime > maxTimeTitle)
        {
            if (panelBlockRaycast) panelBlockRaycast.SetActive(false);
            Destroy(this);
        }
    }
}