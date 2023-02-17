using BehaviourModel;
using System;
using UnityEngine;

[CreateAssetMenu(menuName ="RelationshipTables/CharacterIntLists", fileName ="NewIntLists")]
public class CharacterToPhenomIntRelationsLists : CharacterToPhenomContainerBase<ListsViewDimension<int>, int>
{
    public override int GetTableValueFor(string pageName, CharTraitTypeExtended characterTraitRow, string columnName)
    {
        var matrix = this[pageName];
        if (matrix == null)
            throw new IndexOutOfRangeException($"Matrix with name {pageName} was not found");

        var row = matrix[characterTraitRow];
        if (row == null)
            throw new IndexOutOfRangeException($"Row with type {characterTraitRow} was not found");

        var cellIndex = matrix.GetColumnIndex(columnName);
        if (cellIndex == -1)
            throw new IndexOutOfRangeException($"Column with name {columnName} was not found");

        return Mathf.RoundToInt(row[cellIndex] * matrix.ScallingValue);
    }
}