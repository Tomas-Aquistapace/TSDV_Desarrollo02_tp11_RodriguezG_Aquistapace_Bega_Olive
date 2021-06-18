using UnityEngine;
using UnityEngine.SceneManagement;

public class Presentation : MonoBehaviour
{
    public RectTransform logo;

    private float onTime;
    public float maxTime;
    public float initialScale;
    public float maxScale;
    void Start()
    {
        logo.localScale = new Vector3(initialScale, initialScale, initialScale);
        Invoke(nameof(ChangeScene), maxTime);
    }


    void Update()
    {
        onTime += Time.deltaTime;
        float actualScale = Mathf.Lerp(initialScale, maxScale, onTime / maxTime);
        logo.localScale = new Vector3(actualScale, actualScale, actualScale);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
