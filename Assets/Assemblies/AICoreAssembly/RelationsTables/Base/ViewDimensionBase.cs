using BehaviourModel;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class StringWrapper
{
    [SerializeField] public string columnsName;
    public StringWrapper()
    {
        
    }
}

[Serializable]
public abstract class ViewDimensionBase<T>
{
    #region common
    [SerializeField, HideInInspector] private List<T[]> highValuesVectors;
    [SerializeField, HideInInspector] private List<T[]> lowValuesVectors;
    [SerializeField, HideInInspector] private List<T[]> middleValuesVectors;
    //[SerializeField] float labelsWidth;
    //[SerializeField] float cellsHeight;
    [SerializeField] protected string dimensionName;
    [SerializeField, ReadOnly] protected int columnsCount;
    [SerializeField, PropertyRange(0f, 10f)] protected float scallingValue = 1f;
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
    public abstract T[] HighAnxietyVector { get; set; }
    public abstract T[] HighCourageVector { get; set; }
    public abstract T[] HighDiplomVector { get; set; }
    public abstract T[] HighDomintationVector { get ; set; }
    public abstract T[] HighDreamVector { get; set ; }
    public abstract T[] HighEmStabVector { get; set; }
    public abstract T[] HighExpressVector { get; set; }
    public abstract T[] HighIntellVector { get; set; }
    public abstract T[] HighNonconformVector { get; set; }

    public abstract T[] HighNormativityVector { get; set; }

    public abstract T[] HighRadicalVector { get; set; }

    public abstract T[] HighSelfControlVector { get; set; }

    public abstract T[] HighSensetVector { get; set; }

    public abstract T[] HighSocialVector { get; set; }

    public abstract T[] HighSuspicionVector { get; set; }

    public abstract T[] HighTensionVector { get; set; }

    public List<T[]> HighValuesVectors { get => highValuesVectors; set => highValuesVectors = value; }

    public abstract T[] LowAnxietyVector { get; set; }

    public abstract T[] LowCourageVector { get; set; }

    public abstract T[] LowDiplomVector { get; set; }

    public abstract T[] LowDomintationVector { get; set; }

    public abstract T[] LowDreamVector { get; set; }

    public abstract T[] LowEmStabVector { get; set; }

    public abstract T[] LowExpressVector { get; set; }

    public abstract T[] LowIntellVector { get; set; }

    public abstract T[] LowNonconformVector { get; set; }

    public abstract T[] LowNormativityVector { get; set; }

    public abstract T[] LowRadicalVector { get; set; }

    public abstract T[] LowSelfControlVector { get; set; }

    public abstract T[] LowSensetVector { get; set; }

    public abstract T[] LowSocialVector { get; set; }

    public abstract T[] LowSuspicionVector { get; set; }

    public abstract T[] LowTensionVector { get; set; }

    public List<T[]> LowValuesVectors { get; set; }

    public abstract T[] MidAnxietyVector { get; set; }

    public abstract T[] MidCourageVector { get; set; }

    public abstract T[] MidDiplomVector { get; set; }

    public List<T[]> MiddleValuesVectors { get => middleValuesVectors; set => middleValuesVectors = value; }

    public abstract T[] MidDomintationVector { get; set; }

    public abstract T[] MidDreamVector { get; set; }

    public abstract T[] MidEmStabVector { get;set ; }

    public abstract T[] MidExpressVector { get ;set ; }

    public abstract T[] MidIntellVector { get; set; }

    public abstract T[] MidNonconformVector { get; set ; }

    public abstract T[] MidNormativityVector { get; set ; }

    public abstract T[] MidRadicalVector { get; set; }

    public abstract T[] MidSelfControlVector { get ; set; }

    public abstract T[] MidSensetVector { get ; set; }

    public abstract T[] MidSocialVector { get ; set; }

    public abstract T[] MidSuspicionVector { get; set; }

    public abstract T[] MidTensionVector { get ; set; }
    public abstract void ExtendVectors(int newVectorsLength);
    public abstract void ReduceVectors(int vectorsLength);
    public abstract void InitVectors(int colsCount);
    public ViewDimensionBase()
    {
        InitVectors(0);
    }
    //public void ResetHighValuesList()
    //{
    //    highValuesVectors = new List<T[]>()
    //        {
    //            HighAnxietyVector,
    //            HighNonconformVector,
    //            HighCourageVector,
    //            HighDiplomVector,
    //            HighDomintationVector,
    //            HighDreamVector,
    //            HighEmStabVector,
    //            HighExpressVector,
    //            HighIntellVector,
    //            HighNormativityVector,
    //            HighRadicalVector,
    //            HighSelfControlVector,
    //            HighSensetVector,
    //            HighSocialVector,
    //            HighSuspicionVector,
    //            HighTensionVector
    //        };
    //}

    //public void ResetLowValuesList()
    //{
    //    lowValuesVectors = new List<T[]>()
    //        {
    //            LowAnxietyVector,
    //            LowNonconformVector,
    //            LowCourageVector,
    //            LowDiplomVector,
    //            LowDomintationVector,
    //            LowDreamVector,
    //            LowEmStabVector,
    //            LowExpressVector,
    //            LowIntellVector,
    //            LowNormativityVector,
    //            LowRadicalVector,
    //            LowSelfControlVector,
    //            LowSensetVector,
    //            LowSocialVector,
    //            LowSuspicionVector,
    //            LowTensionVector
    //        };
    //}

    //public void ResetMidValuesList()
    //{
    //    middleValuesVectors = new List<T[]>() {

    //        MidAnxietyVector,
    //        MidNonconformVector,
    //        MidCourageVector,
    //        MidDiplomVector,
    //        MidDomintationVector,
    //        MidDreamVector,
    //        MidEmStabVector,
    //        MidExpressVector,
    //        MidIntellVector,
    //        MidNormativityVector,
    //        MidRadicalVector,
    //        MidSelfControlVector,
    //        MidSensetVector,
    //        MidSocialVector,
    //        MidSuspicionVector,
    //        MidTensionVector
    //        };
    //}

    public T[] this[CharTraitTypeExtended type]
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
            if (ColumnsNames[i].columnsName.Equals(columnName))
                return i;
        }
        return -1;
    }

}
