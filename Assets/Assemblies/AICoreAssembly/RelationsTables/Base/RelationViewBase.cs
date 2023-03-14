using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// A base class for describing dependencies between phenomena.
/// </summary>
[Searchable]
public abstract class RelationViewBase : SerializedScriptableObject
{
    [SerializeField] private string tableDescription;
    public string TableDescription { get => tableDescription; set => tableDescription = value; }
}
