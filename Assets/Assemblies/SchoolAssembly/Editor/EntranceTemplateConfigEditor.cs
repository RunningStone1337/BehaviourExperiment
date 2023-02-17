using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



[CustomEditor(typeof(EntranceTemplateConfig))]
public class EntranceTemplateConfigEditor : CustomEditorBase
{
    EntranceTemplateConfig etc;
    private void OnEnable()
    {
        etc = (EntranceTemplateConfig)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        etc.EntrancePlacingTemplate = DrawObjectField("Шаблон размещения", etc.EntrancePlacingTemplate, true);
        etc.EntrancesRolesTemplates = DrawPreferedViewedList(etc.EntrancesRolesTemplates, "Шаблоны ролей", "Пара шаблон-роль", "Добавить пару в лист", "Выделить место для пары", true);
        CheckDirty();
    }
}
