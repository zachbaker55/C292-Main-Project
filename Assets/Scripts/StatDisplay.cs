using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatDisplay : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI text;

    public void setDamage(int damage) {
        text.SetText($"Dmg: {damage}");
    }
    
}
