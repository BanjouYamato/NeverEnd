using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPoint : MonoBehaviour
{
   public static CamPoint Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
