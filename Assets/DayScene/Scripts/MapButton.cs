using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    [SerializeField] private MapController mapCtrl;
    [SerializeField] private TextMeshProUGUI labelText;
    [SerializeField] public string modifierName;
    [SerializeField] public string locationName;
    [SerializeField] private GameObject activeMarker;

    void Start()
    {
        mapCtrl = GetComponentInParent<MapController>();
        labelText = GetComponentInChildren<TextMeshProUGUI>();

        GetComponent<Button>().onClick.AddListener(OnClick);
        labelText.SetText(locationName);
    }

    void OnClick()
    {
        mapCtrl.OnButtonClick(this);
    }

    public void Deactivate() {
        activeMarker.SetActive(false);
    }

    public void Activate() {
        activeMarker.SetActive(true);
    }
}
