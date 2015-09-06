using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathsCounter : MonoBehaviour {

    public float fadeTime = 2.0f;
    public float waitTime = 3.0f;

    public static bool isDead = false;

    public static int deathCount;
    private static Text deathCountText;

    private Color textColor;

    void Awake()
    {
        deathCountText = GetComponent<Text>();
        deathCount = 0;
        deathCountText.color = new Color(255.0f, 255.0f, 255.0f, 255.0f);
        textColor = deathCountText.color;
    }

    void Start()
    {
        StartCoroutine(FadeOut());
    }

    private void Update()
    {
        // Dårligt for performance
        if (isDead)
            PlayerDied();
    }

    public void PlayerDied()
    {
        isDead = false;
        deathCount++;

        deathCountText.CrossFadeColor(new Color(255f, 255f, 255f, 255f), fadeTime, true, true);

        deathCountText.text = "Deaths: " + deathCount;

        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        Color textVisible = new Color(255f, 255f, 255f, 255f);
        Color textInvisible = new Color(255f, 255f, 255f, 0f);

        yield return new WaitForSeconds(waitTime);
        deathCountText.CrossFadeColor(textInvisible, fadeTime, true, true);
    }
}