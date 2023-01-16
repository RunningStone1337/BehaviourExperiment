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
        //TODO прлдумать отрисовку кортежей
        //etc.EntrancesRolesTemplates = DrawPreferedViewedList("Шаблоны ролей","Пара шаблон-роль","Выделить место для пары","пара", etc.EntrancesRolesTemplates, true);
        CheckDirty();
    }
}
