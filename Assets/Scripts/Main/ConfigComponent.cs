using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigComponent : MonoBehaviour
{
    [SerializeField] private bool _isCursorVisible;
    
    private void Start()
    {
        Cursor.visible = _isCursorVisible;
    }
}
