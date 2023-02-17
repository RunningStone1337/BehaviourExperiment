using UnityEngine;

public class OneLineAttribute : PropertyAttribute
{
    public float labelWidth;
    public string labelText;
    public OneLineAttribute(float labelWidth = 50, string label = null)
    {
        this.labelWidth = labelWidth;
        labelText = label;
    }
}