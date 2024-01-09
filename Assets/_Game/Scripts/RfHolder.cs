using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RfHolder : Singleton<RfHolder> {
  public PointPlayer pointPlayer;

  private void OnValidate() {
    if (pointPlayer == null) {
      pointPlayer = FindObjectOfType<PointPlayer>();
    }
  }
}