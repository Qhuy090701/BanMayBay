using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointPlayer : MonoBehaviour {
  [SerializeField] private TextMeshProUGUI pointText;
  private int point;

  private void Start() {
    pointText.text = "Point:" + point.ToString();
  }

  public void AddPoint(int point) {
    this.point += point;
    pointText.text = "Point:" + point.ToString();
  }
}