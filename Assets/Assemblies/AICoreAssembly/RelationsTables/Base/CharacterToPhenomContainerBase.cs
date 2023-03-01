using BehaviourModel;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The base class of a table for the relationship of character traits to phenomena.
/// </summary>
/// <typeparam name="TContent"></typeparam>
public abstract class CharacterToPhenomContainerBase<TView, TContent> : RelationViewBase
    where TView: ViewDimensionBase<TContent>, new()

{
    [SerializeField, HideInInspector, Delayed, PropertyOrder(0)] private int tableDimensions = 1;
    [SerializeField, HideInInspector, Delayed, PropertyOrder(1)] private int columnsCount = 1;

    [SerializeField, HideInInspector] bool showDimensionsSize = false;
    [SerializeField, HideInInspector] bool showColumnsCount = false;
    [ButtonGroup("ColumnsCount", order: 3)]
    void ChangeColumnsCount()
    {
        showColumnsCount = !showColumnsCount;
    }
    [HideIf("@!showColumnsCount"), ShowInInspector, PropertyRange(1, 64), PropertyOrder(3)]
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

    [ButtonGroup("DimensionsSize",order:2)]
    void ChangeDimensionsCount()
    {
        showDimensionsSize = !showDimensionsSize;
    }

    //[HideIf("showConfirm"), ButtonGroup("DimensionsSize",order:3)]
    //void IncreaseDimensionsCount()
    //{
    //}
    [HideIf("@!showDimensionsSize"), ShowInInspector, PropertyRange(1, 64), PropertyOrder(2)]
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
    [SerializeField, PropertyRange(0f, 10f), PropertyOrder(4)] float tableScallingValue = 1f;
    [SerializeField, ListDrawerSettings(IsReadOnly =true, NumberOfItemsPerPage =1), PropertyOrder(5)] private List<TView> dimensions = new List<TView>()
    { new TView()};   

    public float TableScallingValue { get => tableScallingValue; set => tableScallingValue = value; }
   
    
    public List<TView> Dimensions { get => dimensions; set => dimensions = value; }

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
    public List<TContent> GetTableValuesFor<TAgent, TReaction, TFeature, TState, TSensor>(TAgent agent, string pageName, string columnName)
        where TAgent : AgentBase<TAgent, TReaction, TFeature, TState, TSensor>
        where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState
        where TSensor : ISensor
    {
        List<TContent> res = new List<TContent>();
        foreach (var charTrait in agent.CharacterSystem)
        {
            res.Add(GetTableValueFor(pageName, charTrait.ThisConcreteCharType, columnName));
        }
        return res;
    }

    public List<TContent> GetTableValuesFor<TAgent, TReaction, TFeature, TState, TSensor>(TAgent agent, string pageName)
       where TAgent : AgentBase<TAgent, TReaction, TFeature, TState, TSensor>
       where TReaction : IReaction
       where TFeature : IFeature
       where TState : IState
       where TSensor : ISensor
    {
        List<TContent> res = new List<TContent>();
        foreach (var charTrait in agent.CharacterSystem)
        {
            res.AddRange(GetTableVectorFor(pageName, charTrait.ThisConcreteCharType));
        }
        return res;
    }
    public List<TContent> GetTableValuesFor<TAgent, TReaction, TFeature, TState, TSensor>(TAgent agent, int pageIndex)
       where TAgent : AgentBase<TAgent, TReaction, TFeature, TState, TSensor>
       where TReaction : IReaction
       where TFeature : IFeature
       where TState : IState
       where TSensor : ISensor
    {
        List<TContent> res = new List<TContent>();
        foreach (var charTrait in agent.CharacterSystem)
        {
            res.AddRange(GetTableVectorFor(pageIndex, charTrait.ThisConcreteCharType));
        }
        return res;
    }
    public List<TContent> GetTableValuesFor<TAgent, TReaction, TFeature, TState, TSensor>(TAgent agent, int pageIndex, string columnName)
        where TAgent : AgentBase<TAgent, TReaction, TFeature, TState, TSensor>
        where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState
        where TSensor : ISensor
    {
        List<TContent> res = new List<TContent>();
        foreach (var charTrait in agent.CharacterSystem)
        {
            res.Add(GetTableValueFor(pageIndex, charTrait.ThisConcreteCharType, columnName));
        }
        return res;
    }
    public virtual TContent GetTableValueFor(string pageName, CharTraitTypeExtended characterTraitRow, string columnName)
    {
        var dimension = this[pageName];
        if (dimension == null)
            throw new IndexOutOfRangeException($"Dimension with name {pageName} was not found");

        var row = dimension[characterTraitRow];
        if (row == null)
            throw new IndexOutOfRangeException($"Row with type {characterTraitRow} was not found");

        var cellIndex = dimension.GetColumnIndex(columnName);
        if (cellIndex == -1)
            throw new IndexOutOfRangeException($"Column with name {columnName} was not found");

        return row[cellIndex];
    }
    public virtual TContent GetTableValueFor(int pageInex, CharTraitTypeExtended characterTraitRow, string columnName)
    {
        var matrix = this[pageInex];
        if (matrix == null)
            throw new IndexOutOfRangeException($"Matrix with index {pageInex} was not found");

        var row = matrix[characterTraitRow];
        if (row == null)
            throw new IndexOutOfRangeException($"Row with type {characterTraitRow} was not found");

        var cellIndex = matrix.GetColumnIndex(columnName);
        if (cellIndex == -1)
            throw new IndexOutOfRangeException($"Column with name {columnName} was not found");

        return row[cellIndex];
    }
    public virtual TContent GetTableValueFor(int pageInex, CharTraitTypeExtended characterTraitRow, int columnIndex)
    {
        var matrix = this[pageInex];
        if (matrix == null)
            throw new IndexOutOfRangeException($"Matrix with index {pageInex} was not found");

        var row = matrix[characterTraitRow];
        if (row == null)
            throw new IndexOutOfRangeException($"Row with type {characterTraitRow} was not found");

        return row[columnIndex];
    }
    public virtual TContent[] GetTableVectorFor(int pageInex, CharTraitTypeExtended characterTraitRow)
    {
        var matrix = this[pageInex];
        if (matrix == null)
            throw new IndexOutOfRangeException($"Matrix with index {pageInex} was not found");

        var row = matrix[characterTraitRow];
        if (row == null)
            throw new IndexOutOfRangeException($"Row with type {characterTraitRow} was not found");

        return row;
    }
    public virtual TContent[] GetTableVectorFor(string pageName, CharTraitTypeExtended characterTraitRow)
    {
        var dim = this[pageName];
        if (dim == null)
            throw new IndexOutOfRangeException($"Dimension with name {pageName} was not found");

        var row = dim[characterTraitRow];
        if (row == null)
            throw new IndexOutOfRangeException($"Row with type {characterTraitRow} was not found");

        return row;
    }
    public TContent GetTableValueFor(string pageName, CharTraitTypeExtended characterTraitRow, int columnIndex)
    {
        var dim = this[pageName];
        if (dim == null)
            throw new IndexOutOfRangeException($"Dimension with name {pageName} was not found");

        var row = dim[characterTraitRow];
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