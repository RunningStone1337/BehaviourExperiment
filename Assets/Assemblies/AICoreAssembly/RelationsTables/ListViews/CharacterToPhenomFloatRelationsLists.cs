using BehaviourModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Square table for character floats values.
/// </summary>
[CreateAssetMenu(menuName = "RelationshipTables/CharacterFloatLists", fileName = "NewFloatLists")]
public class CharacterToPhenomFloatRelationsLists : CharacterToPhenomContainerBase<SimpleFoldoutListsViewDimension<float>, float>
{
    public override float GetTableValueFor(string pageName, CharTraitTypeExtended characterTraitRow, string columnName)
    {
        var matrix = this[pageName];
        if (matrix == null)
            throw new IndexOutOfRangeException($"Matrix with name {name} was not found");

        var row = matrix[characterTraitRow];
        if (row == null)
            throw new IndexOutOfRangeException($"Row with type {characterTraitRow} was not found");

        var cellIndex = matrix.GetColumnIndex(columnName);
        if (cellIndex == -1)
            throw new IndexOutOfRangeException($"Column with name {columnName} was not found");

        return row[cellIndex] * matrix.ScallingValue;
    }
}
