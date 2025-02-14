
using UnityEngine;
using UnityEngine.UI;


public class HP_Bar : MonoBehaviour

{
    public Image HPbar;

    // Start is called before the first frame update
    void Start()
    {
        HPbar.fillAmount = 1f;

    }
}
