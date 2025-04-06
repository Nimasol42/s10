using UnityEngine;
public class PlayerColorChanger : MonoBehaviour
{
    void Start()
    {
       
        GetComponent<Renderer>().material.color = Color.green;
    }

    public void ChangeColor(Color newColor)
    {
        GetComponent<Renderer>().material.color = newColor;
    }
}