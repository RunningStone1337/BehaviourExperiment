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

    [HideIf("@!showDimensionsSize"), ShowInInspector, PropertyRange(1, 64), PropertyOrder(2)]
    public int TablePagesCount
    {
        get => tableDimensions; set
        {
            tableDimensions = value;
            if (Pages == null)
                CreateDimensions();
            if (Pages.Count != TablePagesCount)
            {
                if (Pages.Count > TablePagesCount)
                    RemoveDimensions(TablePagesCount);
                else if (Pages.Count < TablePagesCount)
                    AddDimensions(TablePagesCount);
            }
        }
    }
    [SerializeField, ListDrawerSettings(IsReadOnly =true, NumberOfItemsPerPage =1), PropertyOrder(5)] private List<TView> dimensions = new List<TView>()
    { new TView()};   
    
    public List<TView> Pages { get => dimensions; set => dimensions = value; }

    public TView this[int index]
    {
        get
        {
            if (index <= Pages.Count - 1)
                return Pages[index];
            else throw new IndexOutOfRangeException();
        }
    }

    public TView this[string key]
    {
        get
        {
            for (int i = 0; i < Pages.Count; i++)
            {
                if (Pages[i].PageName.Equals(key))
                    return Pages[i];
            }
            return default;
        }
    }

    void AddDimensions(int newDimensionsCount)
    {
        while (newDimensionsCount != Pages.Count)
        {
            var newView = new TView();
            newView.InitVectors(columnsCount);
            Pages.Add(newView);
        }
    }

    void CreateDimensions()
    {
        Pages = new List<TView>(TablePagesCount);
        for (int i = 0; i < Pages.Count; i++)
        {
            Pages[i] = new TView();
            Pages[i].InitVectors(ColumnsCount);
        }
    }

    public void ExtendDimensions( int newLength)
    {
        foreach (var dim in dimensions)
            dim.ExtendVectors(newLength);
    }
    public List<TContent> GetTableValuesFor<TAgent, TReaction, TFeature, TSensor>(TAgent agent, string pageName, string columnName)
        where TAgent : AgentBase<TAgent, TReaction, TFeature, TSensor>
        where TReaction : IAction
        where TFeature : IFeature
        where TSensor : ISensor
    {
        List<TContent> res = new List<TContent>();
        foreach (var charTrait in agent.CharacterSystem)
            res.Add(GetTableValueFor(pageName, charTrait.ThisConcreteCharType, columnName));
        return res;
    }

    public List<TContent> GetTableValuesFor<TAgent, TReaction, TFeature,  TSensor>(TAgent agent, string pageName)
       where TAgent : AgentBase<TAgent, TReaction, TFeature,  TSensor>
       where TReaction : IAction
       where TFeature : IFeature
       where TSensor : ISensor
    {
        List<TContent> res = new List<TContent>();
        foreach (var charTrait in agent.CharacterSystem)
            res.AddRange(GetTableVectorFor(pageName, charTrait.ThisConcreteCharType));
        return res;
    }
    public List<TContent> GetTableValuesFor<TAgent, TReaction, TFeature,  TSensor>(TAgent agent, int pageIndex)
       where TAgent : AgentBase<TAgent, TReaction, TFeature,  TSensor>
       where TReaction : IAction
       where TFeature : IFeature
       where TSensor : ISensor
    {
        List<TContent> res = new List<TContent>();
        foreach (var charTrait in agent.CharacterSystem)
            res.AddRange(GetTableVectorFor(pageIndex, charTrait.ThisConcreteCharType));
        return res;
    }
    public List<TContent> GetTableValuesFor<TAgent, TReaction, TFeature, TSensor>(TAgent agent, int pageIndex, string columnName)
        where TAgent : AgentBase<TAgent, TReaction, TFeature,  TSensor>
        where TReaction : IAction
        where TFeature : IFeature
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

    void ResizeDimensions(int newLength)
    {
        foreach (var dim in dimensions)
            dim.ColumnsCount = newLength;
    }

    void RemoveDimensions(int newDimensionsCount)
    {
        while (newDimensionsCount != Pages.Count)
            Pages.RemoveAt(Pages.Count - 1);
    }
}