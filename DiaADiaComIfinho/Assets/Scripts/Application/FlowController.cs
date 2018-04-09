using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{
    public void LoadScene(int id)
    {
        LoadingScreenManager.LoadScene(id);
    }
}
