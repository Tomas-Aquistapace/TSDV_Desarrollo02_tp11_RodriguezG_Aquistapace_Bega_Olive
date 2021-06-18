using UnityEngine;

public class UiNameAnimation : MonoBehaviour
{
    private bool enable;
    public float timePerText;
    private RectTransform rTransform;
    private float speed;
    private float onTime;
    public float initialScale;

    private void Awake()
    {
        rTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        gameObject.SetActive(false);
    }
    
    private void OnEnable()
    {
        if (enable)
        {
            GetComponent<RectTransform>().localScale = new Vector3(initialScale, initialScale, initialScale);
            onTime = 0;
        }
        enable = true;
    }

    void Update()
    {
        if (enable)
        {
            onTime += Time.deltaTime / timePerText;
            Debug.Log("onTime: " + onTime);
            float scaleAux = Mathf.Lerp(initialScale, 1, onTime);
            Debug.Log("scaleAux: " + scaleAux);
            rTransform.localScale = new Vector3(scaleAux, scaleAux, scaleAux);

            if (scaleAux < 1.002f)
            {
                Destroy(this);
            }
        }
    }
}