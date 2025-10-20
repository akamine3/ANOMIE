using System.Collections;
using UnityEngine;

public class SanityManager : MonoBehaviour
{
    public static SanityManager Instance { get; private set; }

    public float maxSanity = 100f;
    public float currentSanity;
    public float decayRate = 0.5f;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ÉVÅ[ÉìÇÇ‹ÇΩÇ¢Ç≈Ç‡îjä¸Ç≥ÇÍÇ»Ç¢ÇÊÇ§Ç…
        }
        else
        {
            Destroy(gameObject); // èdï°ñhé~
        }
    }

    void Start()
    {
        currentSanity = maxSanity;
        StartCoroutine(SanityDecay());
    }

    IEnumerator SanityDecay()
    {
        while (true)
        {
            currentSanity -= decayRate;
            currentSanity = Mathf.Clamp(currentSanity, 0, maxSanity);
            yield return new WaitForSeconds(1f);
        }
    }

    public void ChangeSanity(float amount)
    {
        currentSanity += amount;
        currentSanity = Mathf.Clamp(currentSanity, 0, maxSanity);
    }

    public void SaveSanity()
    {
        PlayerPrefs.SetFloat("Sanity", currentSanity);
        PlayerPrefs.Save();
    }

    public void LoadSanity()
    {
        if (PlayerPrefs.HasKey("Sanity"))
        {
            currentSanity = PlayerPrefs.GetFloat("Sanity");
        }
        else
        {
            currentSanity = maxSanity;
        }
    }

}
