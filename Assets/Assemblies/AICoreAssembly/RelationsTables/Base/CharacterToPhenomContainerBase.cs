using BehaviourModel;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The base class of a square table for the relationship of character traits to phenomena.
/// </summary>
/// <typeparam name="TCOntent"></typeparam>
public abstract class CharacterToPhenomContainerBase<TView, TCOntent> : RelationViewBase
    where TView: ViewDimensionBase<TCOntent>, new()

{
    [SerializeField, HideInInspector, Delayed, PropertyOrder(0)] private int tableDimensions = 1;
    [SerializeField, HideInInspector, Delayed, PropertyOrder(1)] private int columnsCount = 1;
    [ShowInInspector, PropertyRange(1, 64), PropertyOrder(3)]
    public int ColumnsCount
    {
        get => columnsCount;
        set
        {
            if (value != columnsCount)
            {
                ResizeDimensions(value);
            }
            columnsCount = value;
        }
    }
    [ShowInInspector, PropertyRange(1, 64), PropertyOrder(2)]
    public int TableDimensions
    {
        get => tableDimensions; set
        {
            tableDimensions = value;
            if (Dimensions == null)
                CreateDimensions();
            if (Dimensions.Count != TableDimensions)
            {
                if (Dimensions.Count > TableDimensions)
                    RemoveDimensions(TableDimensions);
                else if (Dimensions.Count < TableDimensions)
                    AddDimensions(TableDimensions);
            }
        }
    }
    //[SerializeField] public float cellWidth = 25f;
    //[SerializeField] internal int currentDimensionIndex;
    //[SerializeField] public float labelsWidth = 100f;
    [SerializeField, PropertyRange(0f, 10f), PropertyOrder(4)] float tableScallingValue = 1f;
    //[SerializeField] MatrixDimension<T> displayedDimension;
    [SerializeField, ListDrawerSettings(IsReadOnly =true, NumberOfItemsPerPage =1), PropertyOrder(5)] private List<TView> dimensions = new List<TView>()
    { new TView()};   

    public float TableScallingValue { get => tableScallingValue; set => tableScallingValue = value; }
    //internal int DisplayedDimensionIndex { get => currentDimensionIndex; set => currentDimensionIndex = value; }
   
    
    public List<TView> Dimensions { get => dimensions; set => dimensions = value; }
   
    //public MatrixDimension<T> DisplayedDimension { get=> displayedDimension; set=> displayedDimension = value; }

    public TView this[int index]
    {
        get
        {
            if (index <= Dimensions.Count - 1)
            {
                return Dimensions[index];
            }
            else throw new IndexOutOfRangeException();
        }
    }

    public TView this[string key]
    {
        get
        {
            for (int i = 0; i < Dimensions.Count; i++)
            {
                if (Dimensions[i].DimensionName.Equals(key))
                {
                    return Dimensions[i];
                }
            }
            return default;
        }
    }

    public void AddDimensions(int newDimensionsCount)
    {
        var currentSize = Dimensions?.Count ?? 0;
        //var newDims = new List<MatrixDimension<T>>(newDimensions);
        //for (int i = 0; i < currentSize; i++)
        //    newDims[i] = Dimensions[i];
        while (newDimensionsCount != Dimensions.Count)
        {
            var newView = new TView();
            newView.InitVectors(currentSize);
            Dimensions.Add(newView);
        }
    }

    public void CreateDimensions()
    {
        Dimensions = new List<TView>(TableDimensions);
        for (int i = 0; i < Dimensions.Count; i++)
        {
            Dimensions[i] = new TView();
            Dimensions[i].InitVectors(ColumnsCount);
        }
    }

    public void ExtendDimensions( int newLength)
    {
        foreach (var dim in dimensions)
            dim.ExtendVectors(newLength);
    }

    public virtual TCOntent GetTableValueFor(string pageName, CharTraitTypeExtended characterTraitRow, string columnName)
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

        return row[cellIndex];
    }
    public TCOntent GetTableValueFor(string pageName, CharTraitTypeExtended characterTraitRow, int columnIndex)
    {
        var matrix = this[pageName];
        if (matrix == null)
            throw new IndexOutOfRangeException($"Matrix with name {name} was not found");

        var row = matrix[characterTraitRow];
        if (row == null)
            throw new IndexOutOfRangeException($"Row with type {characterTraitRow} was not found");

        return row[columnIndex];
    }

    public void ResizeDimensions(int newLength)
    {
        foreach (var dim in dimensions)
        {
            dim.ColumnsCount = newLength;
        }
    }

    void RemoveDimensions(int newDimensionsCount)
    {
        //var newDims = new List<MatrixDimension<T>>(newDimensionsCount);
        //for (int i = 0; i < newDimensionsCount; i++)
        //    newDims[i] = Dimensions[i];
        //Dimensions = newDims;
        while (newDimensionsCount != Dimensions.Count)
        {
            Dimensions.RemoveAt(Dimensions.Count - 1);
        }
    }
}