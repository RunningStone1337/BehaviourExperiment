using BehaviourModel;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class StringWrapper
{
    [SerializeField] public string columnName;
    public StringWrapper()
    {
        
    }
}


[Serializable]
public abstract class ViewDimensionBase<TContent>
{
    #region common
    [SerializeField, HideInInspector] private List<TContent[]> highValuesVectors;
    [SerializeField, HideInInspector] private List<TContent[]> lowValuesVectors;
    [SerializeField, HideInInspector] private List<TContent[]> middleValuesVectors;
    //[SerializeField] float labelsWidth;
    //[SerializeField] float cellsHeight;
    [SerializeField] protected string dimensionName;
    [SerializeField, ReadOnly] protected int columnsCount;
    [SerializeField, PropertyRange(0f, 10f)] protected float scallingValue = 1f;

    [SerializeField, HideInInspector]
    protected StringWrapper[] columnsNames;

    public abstract StringWrapper[] ColumnsNames { get; set; }

   
    #endregion
    public string DimensionName { get => dimensionName; set => dimensionName = value; }
    public float ScallingValue { get => scallingValue; set => scallingValue = value; }
    public int ColumnsCount
    {
        get => columnsCount;
        set
        {
            if (value > columnsCount)
                ExtendVectors(value);
            else if (value < columnsCount)
                ReduceVectors(value);
            columnsCount = value;
        }
    }
    public abstract TContent[] HighAnxietyVector { get; set; }
    public abstract TContent[] HighCourageVector { get; set; }
    public abstract TContent[] HighDiplomVector { get; set; }
    public abstract TContent[] HighDomintationVector { get ; set; }
    public abstract TContent[] HighDreamVector { get; set ; }
    public abstract TContent[] HighEmStabVector { get; set; }
    public abstract TContent[] HighExpressVector { get; set; }
    public abstract TContent[] HighIntellVector { get; set; }
    public abstract TContent[] HighNonconformVector { get; set; }

    public abstract TContent[] HighNormativityVector { get; set; }

    public abstract TContent[] HighRadicalVector { get; set; }

    public abstract TContent[] HighSelfControlVector { get; set; }

    public abstract TContent[] HighSensetVector { get; set; }

    public abstract TContent[] HighSocialVector { get; set; }

    public abstract TContent[] HighSuspicionVector { get; set; }

    public abstract TContent[] HighTensionVector { get; set; }

    public List<TContent[]> HighValuesVectors { get => highValuesVectors; set => highValuesVectors = value; }

    public abstract TContent[] LowAnxietyVector { get; set; }

    public abstract TContent[] LowCourageVector { get; set; }

    public abstract TContent[] LowDiplomVector { get; set; }

    public abstract TContent[] LowDomintationVector { get; set; }

    public abstract TContent[] LowDreamVector { get; set; }

    public abstract TContent[] LowEmStabVector { get; set; }

    public abstract TContent[] LowExpressVector { get; set; }

    public abstract TContent[] LowIntellVector { get; set; }

    public abstract TContent[] LowNonconformVector { get; set; }

    public abstract TContent[] LowNormativityVector { get; set; }

    public abstract TContent[] LowRadicalVector { get; set; }

    public abstract TContent[] LowSelfControlVector { get; set; }

    public abstract TContent[] LowSensetVector { get; set; }

    public abstract TContent[] LowSocialVector { get; set; }

    public abstract TContent[] LowSuspicionVector { get; set; }

    public abstract TContent[] LowTensionVector { get; set; }

    public List<TContent[]> LowValuesVectors { get; set; }

    public abstract TContent[] MidAnxietyVector { get; set; }

    public abstract TContent[] MidCourageVector { get; set; }

    public abstract TContent[] MidDiplomVector { get; set; }

    public List<TContent[]> MiddleValuesVectors { get => middleValuesVectors; set => middleValuesVectors = value; }

    public abstract TContent[] MidDomintationVector { get; set; }

    public abstract TContent[] MidDreamVector { get; set; }

    public abstract TContent[] MidEmStabVector { get;set ; }

    public abstract TContent[] MidExpressVector { get ;set ; }

    public abstract TContent[] MidIntellVector { get; set; }

    public abstract TContent[] MidNonconformVector { get; set ; }

    public abstract TContent[] MidNormativityVector { get; set ; }

    public abstract TContent[] MidRadicalVector { get; set; }

    public abstract TContent[] MidSelfControlVector { get ; set; }

    public abstract TContent[] MidSensetVector { get ; set; }

    public abstract TContent[] MidSocialVector { get ; set; }

    public abstract TContent[] MidSuspicionVector { get; set; }

    public abstract TContent[] MidTensionVector { get ; set; }

    public abstract void ReduceVectors(int vectorsLength);


    public abstract void ExtendVectors(int newVectorsLength);


    public abstract void InitVectors(int vectorsSize);
    public ViewDimensionBase()
    {
        InitVectors(0);
    }

    public TContent[] this[CharTraitTypeExtended type]
    {
        get
        {
            return type switch
            {
                CharTraitTypeExtended.LowCalmnessAnxiety => LowAnxietyVector,
                CharTraitTypeExtended.MidCalmnessAnxiety => MidAnxietyVector,
                CharTraitTypeExtended.HighCalmnessAnxiety => HighAnxietyVector,
                CharTraitTypeExtended.LowClosenessSociability => LowSocialVector,
                CharTraitTypeExtended.MidClosenessSociability => MidSocialVector,
                CharTraitTypeExtended.HighClosenessSociability => HighSocialVector,
                CharTraitTypeExtended.LowConformismNonconformism => LowNonconformVector,
                CharTraitTypeExtended.MidConformismNonconformism => MidNonconformVector,
                CharTraitTypeExtended.HighConformismNonconformism => HighNonconformVector,
                CharTraitTypeExtended.LowConservatismRadicalism => LowRadicalVector,
                CharTraitTypeExtended.MidConservatismRadicalism => MidRadicalVector,
                CharTraitTypeExtended.HighConservatismRadicalism => HighRadicalVector,
                CharTraitTypeExtended.LowCredulitySuspicion => LowSuspicionVector,
                CharTraitTypeExtended.MidCredulitySuspicion => MidSuspicionVector,
                CharTraitTypeExtended.HighCredulitySuspicion => HighSuspicionVector,
                CharTraitTypeExtended.LowEmotionalInstabilityStability => LowEmStabVector,
                CharTraitTypeExtended.MidEmotionalInstabilityStability => MidEmStabVector,
                CharTraitTypeExtended.HighEmotionalInstabilityStability => HighEmStabVector,
                CharTraitTypeExtended.LowIntelligence => LowIntellVector,
                CharTraitTypeExtended.MidIntelligence => MidIntellVector,
                CharTraitTypeExtended.HighIntelligence => HighIntellVector,
                CharTraitTypeExtended.LowNormativityOfBehaviour => LowNormativityVector,
                CharTraitTypeExtended.MidNormativityOfBehaviour => MidNormativityVector,
                CharTraitTypeExtended.HighNormativityOfBehaviour => HighNormativityVector,
                CharTraitTypeExtended.LowPracticalityDreaminess => LowDreamVector,
                CharTraitTypeExtended.MidPracticalityDreaminess => MidDreamVector,
                CharTraitTypeExtended.HighPracticalityDreaminess => HighDreamVector,
                CharTraitTypeExtended.LowRelaxationTension => LowTensionVector,
                CharTraitTypeExtended.MidRelaxationTension => MidTensionVector,
                CharTraitTypeExtended.HighRelaxationTension => HighTensionVector,
                CharTraitTypeExtended.LowRestraintExpressiveness => LowExpressVector,
                CharTraitTypeExtended.MidRestraintExpressiveness => MidExpressVector,
                CharTraitTypeExtended.HighRestraintExpressiveness => HighExpressVector,
                CharTraitTypeExtended.LowRigiditySensetivity => LowSensetVector,
                CharTraitTypeExtended.MidRigiditySensetivity => MidSensetVector,
                CharTraitTypeExtended.HighRigiditySensetivity => HighSensetVector,
                CharTraitTypeExtended.LowSelfcontrol => LowSelfControlVector,
                CharTraitTypeExtended.MidSelfcontrol => MidSelfControlVector,
                CharTraitTypeExtended.HighSelfcontrol => HighSelfControlVector,
                CharTraitTypeExtended.LowStraightforwardnessDiplomacy => LowDiplomVector,
                CharTraitTypeExtended.MidStraightforwardnessDiplomacy => MidDiplomVector,
                CharTraitTypeExtended.HighStraightforwardnessDiplomacy => HighDiplomVector,
                CharTraitTypeExtended.LowSubordinationDomination => LowDomintationVector,
                CharTraitTypeExtended.MidSubordinationDomination => MidDomintationVector,
                CharTraitTypeExtended.HighSubordinationDomination => HighDomintationVector,
                CharTraitTypeExtended.LowTimidityCourage => LowCourageVector,
                CharTraitTypeExtended.MidTimidityCourage => MidCourageVector,
                CharTraitTypeExtended.HighTimidityCourage => HighCourageVector,
                _ => default,
            };
        }
    }
    public int GetColumnIndex(string columnName)
    {
        for (int i = 0; i < ColumnsNames.Length; i++)
        {
            if (ColumnsNames[i].columnName.Equals(columnName))
                return i;
        }
        return -1;
    }

}
