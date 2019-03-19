using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiskAmountScript : MonoBehaviour
{
    [SerializeField]
    private Slider diskCountSlider;
    [SerializeField]
    private TextMeshProUGUI diskCountText;
    private TextMeshProUGUI diskCountValue;

    void Awake() {
        diskCountValue = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeTextValue() {
        Globals.instance.diskCountAmount = (int)diskCountSlider.value;
        diskCountValue.text = diskCountSlider.value.ToString();
        FindObjectOfType<Globals>().Play("UIClick");
    }
}
