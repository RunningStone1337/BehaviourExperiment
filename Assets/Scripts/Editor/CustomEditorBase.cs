using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUILayout;
using static UnityEditor.EditorGUI;
using Object = UnityEngine.Object;
using System.Linq;
using System.Reflection;
using Extensions;

public abstract class CustomEditorBase : Editor
{
    private static List<Type> inheritors;
    private static bool showInheritorsOptions;
    static string abstractTypeFullName;
    static int index;
    public override void OnInspectorGUI()
    {
        CheckDirty();
    }
    protected static void DrawSeperatorLine()
    {
        LabelField("________________________________________________________________________________________________________________________________________________________________________________________________");
    }
    /// <summary>
    /// Отрисовывает селектор типов для наследников baseType. Строка отображается в лейбле.
    /// Редактировать вводом нельзя, только выбор перечисления.
    /// </summary>
    /// <param name="label"></param>
    /// <param name="targetString"></param>
    /// <param name="baseType"></param>
    /// <param name="editorSelectionIndex"></param>
    /// <param name="editorShowSelector"></param>
    /// <returns></returns>
    protected (string selectedType, int editorSelectionIndex, bool editorShowSelector) DrawInheritorsTypeSelector(string label, string targetString, Type baseType, int editorSelectionIndex, bool editorShowSelector)
    {
        LabelField(label);
        GUILayout.BeginHorizontal("box");
        var btnLabel = editorShowSelector ? "Скрыть" : "Выбрать тип";
        if (GUILayout.Button(btnLabel))
            editorShowSelector = !editorShowSelector;
        GUILayout.EndHorizontal();
        if (!string.IsNullOrEmpty(targetString))
        {
            var selectedType = Type.GetType(targetString);
            if (selectedType != null)
                LabelField(selectedType.Name);
            else
                HelpBox("Тип не выбран!", MessageType.Warning, true);
        }
        else
            HelpBox("Тип не выбран!", MessageType.Warning, true);
        if (editorShowSelector)
        {
            List<Type> inheritors = Assembly.GetAssembly(baseType).GetInheritors(baseType);
            (string typeFullName, int index, _) = DrawTypeSelector(inheritors, targetString, editorSelectionIndex);
            return (typeFullName, index, editorShowSelector);
        }
        else
            return (targetString, editorSelectionIndex, editorShowSelector);

    }
    protected virtual void CheckDirty()
    {
        if (UnityEngine.GUI.changed)
            EditorUtility.SetDirty(target);
    }
    protected List<T> DrawList<T>(string title, string listMemberName, string givePlaceFOR, string emptyEntityName, List<T> list, bool drawItemsEditors) where T : Object
    {
        LabelField(title);
        if (list == null)
            list = new List<T>();
        if (list.Count > 0)
        {
            for (int index = 0; index < list.Count; index++)
                DrawListItem(list, listMemberName, index, drawItemsEditors);
        }
        else
            LabelField($"Список объектов {emptyEntityName} пуст");
        DrawPreferedAddingButtons(list, givePlaceFOR);
        return list;
    }

    /// <summary>
    /// Отрисовывает селектор типов на основании typesForSelector если переключатель установлен в true, иначе тип селектора = null
    /// </summary>
    /// <param name="toggleLabel">Лейбл тоггла</param>
    /// <param name="typesForSelector">Типы, которые предлагаются к выбору в выпадающем списке</param>
    /// <param name="drawSelectorToggle">Булька-переключатель</param>
    /// <param name="selectorTypeFullName">Полное имя тип</param>
    /// <param name="selectorIndex">Индекс селектора</param>
    /// <param name="selectorTypeShortName">Отображаемое имя в селекторе</param>
    /// <returns></returns>
    protected ((string selectorTypeFullName, int selectorIndex, string selectorTypeShortName), bool drawSelector)
        DrawTypeSelectorIfToggle(string toggleLabel, List<Type> typesForSelector, bool drawSelectorToggle, string selectorTypeFullName, int selectorIndex, string selectorTypeShortName)
    {
        drawSelectorToggle = Toggle(toggleLabel, drawSelectorToggle);
        if (drawSelectorToggle)
            (selectorTypeFullName, selectorIndex, selectorTypeShortName) = DrawTypeSelector(typesForSelector, selectorTypeFullName, selectorIndex);
        else
            selectorTypeFullName = null;
        return ((selectorTypeFullName, selectorIndex, selectorTypeShortName), drawSelectorToggle);
    }

    public T DrawObjectField<T>(string label, T obj, bool drawObjEditor = false) where T : Object
    {
        obj = (T)ObjectField(label, obj, typeof(T), true);
        if (drawObjEditor && obj != null)
        {
            //if (typeof(T).IsSubclassOf(typeof(ScriptableObject)))
            {
                BeginVertical("box");
                var ed = CreateEditor(obj);
                ed.OnInspectorGUI();
                EndVertical();
            }
        }
        return obj;
    }
    public int DrawObjectField(string label, int val)
    {
        return IntField(label, val);
    }
    public float DrawObjectField(string label, float val)
    {
        return FloatField(label, val);
    }

    protected void DrawPreferedAddingButtons<T>(ref List<T> list, Action<T, int> afterAddingDelegate, string addNAMEinPLACE, string givePlaceFOR) where T : ScriptableObject
    {
        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button(addNAMEinPLACE))
        {
            var asset = CreateAsset<T>(typeof(T).Name);
            list.Add(asset);
            afterAddingDelegate?.Invoke(asset, list.IndexOf(asset));
        }
        if (GUILayout.Button(givePlaceFOR))
        {
            list.Add(null);
            afterAddingDelegate?.Invoke(null, -1);
        }
        GUILayout.EndHorizontal();
    }
    private void DrawPreferedAddingButtons<T>(List<T> list, string givePlaceFOR) where T : Object
    {
        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button(givePlaceFOR))
            list.Add(null);
        GUILayout.EndHorizontal();
    }
    private void DrawPreferedAddingButtons<T1,T2>(List<(T1,T2)> list, string givePlaceFOR) where T1 : Object where T2 : Object
    {
        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button(givePlaceFOR))
            list.Add(default);
        GUILayout.EndHorizontal();
    }
    protected void DrawPreferedAddingButtons<T>(List<T> list, MonoBehaviour callerScript, Action<T, int> afterAddingDelegate, string addNAMEinPLACE, string givePlaceFOR) where T : MonoBehaviour
    {
        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button(addNAMEinPLACE))
        {
            var newMonoBeh = callerScript.gameObject.AddComponent<T>();
            list.Add(newMonoBeh);
            afterAddingDelegate?.Invoke(newMonoBeh, list.IndexOf(newMonoBeh));
        }
        if (GUILayout.Button(givePlaceFOR))
        {
            list.Add(null);
            afterAddingDelegate?.Invoke(null, -1);
        }
        GUILayout.EndHorizontal();
    }

    public static T CreateAsset<T>(string assetName, string path = "AutoGeneratedAssets") where T : ScriptableObject
    {
        int counter = 0;
        var type = typeof(T);
        string fullName = $"Assets/Resources/{path}/{assetName}.asset";
        while (File.Exists(fullName))
        {
            fullName = $"Assets/Resources/{path}/{assetName}_{counter}.asset";
            counter++;
        }
        var inst = CreateInstance(type);
        DirectoryInfo di = new DirectoryInfo($"Assets/Resources/{path}");
        if (!di.Exists)
            Directory.CreateDirectory($"Assets/Resources/{path}");
        AssetDatabase.CreateAsset(inst, fullName);
        return (T)inst;
    }

    protected (string selectedTypeFullName, int selectedIndex, string selectedTypeShortName) DrawTypeSelector(List<Type> selectionTypes, Type checkedType, int index)
    {
        return DrawTypeSelector(selectionTypes, checkedType.AssemblyQualifiedName, index);
    }

    /// <summary>
    /// Селектор типов из списка types.
    /// </summary>
    /// <param name="types">Типы для выбора</param>
    /// <param name="listNames">Лист полных имён классов</param>
    /// <param name="indexesList">Лист индексов для каждого выпадающего списка</param>
    /// <param name="listShortNames">Лист коротких имён классов</param>
    /// <param name="afterAddingDelegate">Делегат после добавления нового элемента</param>
    /// <param name="afterDrawingSelectorDelegate">Делегат после отрисовки селектора</param>
    /// <param name="afterRemovingSelectorDelegate">Делегат после удаления элемента из списка</param>
    /// <returns></returns>
    protected (List<string> fullNames, List<int> indexes, List<string> shortNames)
        DrawTypesSelectors(List<Type> types, List<string> listNames, List<int> indexesList, List<string> listShortNames,
        Action afterAddingDelegate = null, Action<int> afterDrawingSelectorDelegate = null, Action<int> afterRemovingSelectorDelegate = null)
    {
        if (listNames == null)
            listNames = new List<string>();
        if (indexesList == null)
            indexesList = new List<int>();
        if (listShortNames == null)
            listShortNames = new List<string>();
        if (listNames.Count > 0)
        {
            if (listNames.Count == indexesList.Count && indexesList.Count == listShortNames.Count)
            {
                for (int index = 0; index < listNames.Count; index++)
                {
                    GUILayout.BeginHorizontal("box");
                    (listNames[index], indexesList[index], listShortNames[index]) = DrawTypeSelector(types, listNames[index], indexesList[index]);
                    if (GUILayout.Button("x", GUILayout.Width(25)))
                    {
                        listNames.RemoveAt(index);
                        indexesList.RemoveAt(index);
                        listShortNames.RemoveAt(index);
                        afterRemovingSelectorDelegate?.Invoke(index);
                        break;
                    }
                    GUILayout.EndHorizontal();
                    afterDrawingSelectorDelegate?.Invoke(index);
                }
            }
            else
            {
                listNames.Clear();
                indexesList.Clear();
                listShortNames.Clear();
            }
        }
        else
            GUILayout.Label("Список пуст");
        BeginHorizontal("box");
        if (GUILayout.Button("Добавить тип"))
        {
            listNames.Add(null);
            indexesList.Add(0);
            listShortNames.Add(null);
            afterAddingDelegate?.Invoke();
        }
        if (GUILayout.Button("Сбросить список"))
        {
            listNames.Clear();
            indexesList.Clear();
            listShortNames.Clear();
        }
        EndHorizontal();
        return (listNames, indexesList, listShortNames);
    }



    protected (string typeFullName, int index, string typeShortName) DrawTypeSelector(List<Type> selectionTypes, string typeAssemblyQualifiedName, int index)
    {
        var names = selectionTypes.Select(x => x.Name).ToArray();
        var fullNames = selectionTypes.Select(x => x.AssemblyQualifiedName).ToList();
        if (fullNames.Count == 0)//нет наследников абстрактного класса
            return default;
        if (!string.IsNullOrEmpty(typeAssemblyQualifiedName))//тип уже определён
        {
            try
            {
                //убеждаемся, что индексы не уехали из-за добавления новых подтипов
                //под выбранным индексом в списке тот же тип, что и хранимый
                if (fullNames[index].Equals(typeAssemblyQualifiedName))
                    index = Popup(index, names);
                else
                    index = Popup(fullNames.IndexOf(typeAssemblyQualifiedName), names);
                return (fullNames[index], index, names[index]);
            }
            catch (IndexOutOfRangeException)
            {
                return (fullNames[0], 0, names[0]);
            }
            catch (ArgumentOutOfRangeException)
            {
                return (fullNames[0], 0, names[0]);
            }
        }
        else
        {
            index = Popup(index, names);
            return (fullNames[index], index, names[0]);
        }
    }

    public static ScriptableObject CreateAsset(Type type, string assetName, string path = "AutoGeneratedAssets")
    {
        int counter = 0;
        string fullName = $"Assets/Resources/{path}/{assetName}.asset";
        while (File.Exists(fullName))
        {
            fullName = $"Assets/Resources/{path}/{assetName}_{counter}.asset";
            counter++;
        }
        var inst = CreateInstance(type);
        DirectoryInfo di = new DirectoryInfo($"Assets/Resources/{path}");
        if (!di.Exists)
            Directory.CreateDirectory($"Assets/Resources/{path}");
        AssetDatabase.CreateAsset(inst, fullName);
        return inst;
    }

    protected int[] DrawMultyIntField(params (string label, int value)[] values)
    {
        var last = GUILayoutUtility.GetLastRect();
        var cont = new GUIContent[values.Length];
        for (int i = 0; i < values.Length; i++)
            cont[i] = new GUIContent(values[i].label);
        var intVals = new int[values.Length];
        for (int i = 0; i < intVals.Length; i++)
            intVals[i] = values[i].value;
        MultiIntField(new Rect(last.x, last.y + 20, Screen.width - 30, last.height), cont, intVals);
        GUILayout.Space(20);
        return intVals;
    }

    /// <summary>
    /// Метод отрисовки листа по определённому шаблону с возможностью опциональных вставок до отрисовки основного контента.
    /// </summary>
    /// <typeparam name="T">Наследуется от ScriptableObject.</typeparam>
    /// <param name="list">Коллекция для отрисовки.</param>
    /// <param name="listMemberName">Название коллекции.</param>
    /// <param name="emptyEntityName">Имя для элемента листа, отображаемое, когда список пуст.</param>
    /// <param name="addNAMEinPLACE">Название сущности, которая добавляется при нажатии кнопки Добавить /.../ в ...".</param>
    /// <param name="givePlaceFOR">Название сущности, для которой выделяется место при нажатии кнопки "Выделить место для /.../"</param>
    /// <param name="inputTuple"></param>
    /// <param name="afterRemovingDelegate">Делегат, выполяемый после удалении элемента из коллекции.
    /// Используется для удаления из связанных с удалённым элементом коллекций.</param>
    /// <param name="afterAddingDelegate"></param>
    /// <param name="typeCheckingDelegate"></param>
    /// <param name="beforeDrawingItemDelegate">Делегат, выполняемый перед отрисовкой элемента коллекции.</param>
    /// <param name="typeCheckingDelegate">Делегат проверки соответсвия типов для элементов коллекции.</param>
    /// <param name="afterAddingDelegate">Делегат, выполняемый после добавления нового элемента или резервирования места для него.</param>
    /// Используется для добавления в связанные с добавленным элементом коллекции.</param>
    /// <returns>Кортеж имени предлагаемого к созданию типа, индекс выбранного типа, короткое имя типа, флаг показа вариантов создания типа.
    /// ДЛЯ ПРОСТЫХ КОЛЛЕКЦИЙ ВОЗВРАЩАЕМЫЙ ПАРАМЕТР НЕ НУЖЕН</returns>

    protected virtual ((string typeFullName, int index, string typeShortName), bool showInheritorsSelector, List<T> resList)
        DrawPreferedViewedList<T>(List<T> list, string listMemberName, string emptyEntityName, string addNAMEinPLACE, string givePlaceFOR, bool showInheritorsOptions = default, (int index, string abstractTypeFullName) inputTuple = default,
        Action<int> afterRemovingDelegate = null, Action<T, int> afterAddingDelegate = null, Action<T> typeCheckingDelegate = null, Action<int> beforeDrawingItemDelegate = null) where T : ScriptableObject
    {
        if (list == null)
            list = new List<T>();
        if (list.Count > 0)
        {
            for (int index = 0; index < list.Count; index++)
            {
                DrawListItem(ref list, listMemberName, index, afterRemovingDelegate, typeCheckingDelegate, beforeDrawingItemDelegate);

                //beforeDrawingItemDelegate?.Invoke(index);
                //BeginHorizontal("box");
                //if (GUILayout.Button("x", GUILayout.Width(25)))
                //{
                //    list.RemoveAt(index);
                //    afterRemovingDelegate?.Invoke(index);
                //    break;
                //}
                //if (list[index] != null)
                //{
                //    list[index] = DrawObjectField($"{listMemberName} {index + 1}", list[index]);
                //    EndHorizontal();
                //    BeginVertical("box");
                //    var ed = CreateEditor(list[index]);
                //    ed.OnInspectorGUI();
                //    typeCheckingDelegate?.Invoke(list[index]);
                //    EndVertical();
                //}
                //else
                //{
                //    list[index] = DrawObjectField("Зарезервированное место", list[index]);
                //    EndHorizontal();
                //}
            }
        }
        else
            LabelField($"Список объектов {emptyEntityName} пуст");
        var type = typeof(T);
        if (!type.IsAbstract)
        {
            DrawPreferedAddingButtons(ref list, afterAddingDelegate, addNAMEinPLACE, givePlaceFOR);
            return (default, default, list);
        }
        else
            return DrawPreferedAddingButtonsForAbstract(list, afterAddingDelegate, addNAMEinPLACE, givePlaceFOR, inputTuple, showInheritorsOptions);
    }

    protected virtual List<(T1,T2)> DrawPreferedViewedList<T1,T2>(List<(T1,T2)> list, string listMemberName, string emptyEntityName, string addNAMEinPLACE, string givePlaceFOR, bool showInheritorsOptions = default, (int index, string abstractTypeFullName) inputTuple = default,
       Action<int> afterRemovingDelegate = null, Action<(T1,T2), int> afterAddingDelegate = null, Action<(T1, T2)> typeCheckingDelegate = null, Action<int> beforeDrawingItemDelegate = null) where T1 : Object where T2 : Object
    {
        if (list == null)
            list = new List<(T1, T2)>();
        if (list.Count > 0)
        {
            for (int index = 0; index < list.Count; index++)
            {
                DrawListItem(ref list, listMemberName, index, afterRemovingDelegate, typeCheckingDelegate, beforeDrawingItemDelegate);
            }
        }
        else
            LabelField($"Список объектов {emptyEntityName} пуст");
        return DrawTupleAddingButtons(ref list, givePlaceFOR);
    }

    private List<(T1, T2)> DrawTupleAddingButtons<T1, T2>
        (ref List<(T1, T2)> list, string givePlaceFOR)
        where T1 : Object
        where T2 : Object
    {      
        ((string, int, string), bool, List<(T1, T2)>) res = (default,default,list);
        //if (!type1.IsAbstract)
        //{
        //    DrawPreferedAddingButtons(ref list, afterAddingDelegate, addNAMEinPLACE, givePlaceFOR);
        //    res=(default, default, list);
        //}
        //else
        //    res= DrawPreferedAddingButtonsForAbstract(list, afterAddingDelegate, addNAMEinPLACE, givePlaceFOR, inputTuple, showInheritorsOptions);
        DrawPreferedAddingButtons(list, givePlaceFOR);
        return list;
    }

    /// <summary>
    /// Метод отрисовки листа по определённому шаблону с возможностью опциональных вставок до отрисовки основного контента.
    /// </summary>
    /// <typeparam name="T">Наследуется от ScriptableObject.</typeparam>
    /// <param name="list">Коллекция для отрисовки.</param>
    /// <param name="listMemberName">Название коллекции.</param>
    /// <param name="emptyEntityName">Имя для элемента листа, отображаемое, когда список пуст.</param>
    /// <param name="addNAMEinPLACE">Название сущности, которая добавляется при нажатии кнопки Добавить /.../ в ...".</param>
    /// <param name="givePlaceFOR">Название сущности, для которой выделяется место при нажатии кнопки "Выделить место для /.../"</param>
    /// <param name="inputTuple"></param>
    /// <param name="afterRemovingDelegate">Делегат, выполяемый после удалении элемента из коллекции.
    /// Используется для удаления из связанных с удалённым элементом коллекций.</param>
    /// <param name="afterAddingDelegate"></param>
    /// <param name="typeCheckingDelegate"></param>
    /// <param name="beforeDrawingItemDelegate">Делегат, выполняемый перед отрисовкой элемента коллекции.</param>
    /// <param name="typeCheckingDelegate">Делегат проверки соответсвия типов для элементов коллекции.</param>
    /// <param name="afterAddingDelegate">Делегат, выполняемый после добавления нового элемента или резервирования места для него.</param>
    /// Используется для добавления в связанные с добавленным элементом коллекции.</param>
    /// <returns>Кортеж имени предлагаемого к созданию типа, индекс выбранного типа, короткое имя типа, флаг показа вариантов создания типа.
    /// ДЛЯ ПРОСТЫХ КОЛЛЕКЦИЙ ВОЗВРАЩАЕМЫЙ ПАРАМЕТР НЕ НУЖЕН</returns>

    protected ((string typeFullName, int index, string typeShortName), bool showInheritorsSelector, int screenIndex, List<T> list)
        DrawScreensViewedList<T>(List<T> list, string listMemberName, string emptyEntityName, string addNAMEinPLACE, string givePlaceFOR, int screenIndex, (int index, string abstractTypeFullName) inputTuple = default, bool showInheritorsOptions = default,
        Action<int> afterRemovingDelegate = null, Action<T, int> afterAddingDelegate = null, Action<T> typeCheckingDelegate = null, Action<int> beforeDrawingItemDelegate = null) where T : ScriptableObject
    {
        if (list == null)
            list = new List<T>();
        if (list.Count > 0)
        {
            BeginHorizontal("box");
            if (GUILayout.Button($"? {typeof(T).Name}"))
            {
                screenIndex = Mathf.Clamp(screenIndex - 1 < 0 ? list.Count - 1 : screenIndex - 1, 0, list.Count - 1);
                return (default, default, screenIndex, list);
            }
            if (GUILayout.Button($"{typeof(T).Name} ?"))
            {
                screenIndex = Mathf.Clamp(screenIndex + 1 > list.Count - 1 ? 0 : screenIndex + 1, 0, list.Count - 1);
                return (default, default, screenIndex, list);
            }
            EndHorizontal();
            screenIndex = Mathf.Clamp(screenIndex, 0, list.Count - 1);
            DrawListItem(ref list, listMemberName, screenIndex, afterRemovingDelegate, typeCheckingDelegate, beforeDrawingItemDelegate);
        }
        else
            LabelField($"Список объектов {emptyEntityName} пуст");
        var type = typeof(T);
        if (!type.IsAbstract)
        {
            DrawPreferedAddingButtons(ref list, afterAddingDelegate, addNAMEinPLACE, givePlaceFOR);
            return (default, default, screenIndex, list);
        }
        var res = DrawPreferedAddingButtonsForAbstract(list, afterAddingDelegate, addNAMEinPLACE, givePlaceFOR, inputTuple, showInheritorsOptions);
        return (res.Item1, res.showInheritorsSelector, screenIndex, res.listResult);
    }

    private void DrawListItem<T>(ref List<T> list, string listMemberName, int itemIndex, Action<int> afterRemovingDelegate, Action<T> typeCheckingDelegate, Action<int> beforeDrawingItemDelegate) where T : ScriptableObject
    {
        beforeDrawingItemDelegate?.Invoke(itemIndex);
        BeginHorizontal("box");
        if (GUILayout.Button("x", GUILayout.Width(25)))
        {
            list.RemoveAt(itemIndex);
            afterRemovingDelegate?.Invoke(itemIndex);
            return;
        }
        if (list[itemIndex] != null)
        {
            list[itemIndex] = DrawObjectField($"{listMemberName} {itemIndex + 1}", list[itemIndex]);
            EndHorizontal();
            BeginVertical("box");
            var ed = CreateEditor(list[itemIndex]);
            ed.OnInspectorGUI();
            typeCheckingDelegate?.Invoke(list[itemIndex]);
            EndVertical();
        }
        else
        {
            list[itemIndex] = DrawObjectField("Зарезервированное место", list[itemIndex]);
            EndHorizontal();
        }
    }
    private void DrawListItem<T1,T2>(ref List<(T1,T2)> list, string listMemberName, int itemIndex, Action<int> afterRemovingDelegate, Action<(T1, T2)> typeCheckingDelegate, Action<int> beforeDrawingItemDelegate) where T1 : Object where T2 : Object
    {
        beforeDrawingItemDelegate?.Invoke(itemIndex);
        if (GUILayout.Button("x", GUILayout.Width(25)))
        {
            list.RemoveAt(itemIndex);
            afterRemovingDelegate?.Invoke(itemIndex);
            return;
        }
        T1 item1;
        T2 item2;
        if (list[itemIndex].Item1 != null)
            item1= DrawObjectField($"{listMemberName} {itemIndex + 1}", list[itemIndex].Item1);
        else
            item1 = DrawObjectField("Зарезервированное место", list[itemIndex].Item1);
        if (list[itemIndex].Item2 != null)
            item2 = DrawObjectField($"{listMemberName} {itemIndex + 1}", list[itemIndex].Item2);
        else
            item2 = DrawObjectField("Зарезервированное место", list[itemIndex].Item2);
        if (item1 != null)
        {
            BeginVertical("box");
            var ed = CreateEditor(item1);
            ed.OnInspectorGUI();
            typeCheckingDelegate?.Invoke(list[itemIndex]);
            EndVertical();
        }
        if (item2 != null)
        {
            BeginVertical("box");
            var ed = CreateEditor(item2);
            ed.OnInspectorGUI();
            typeCheckingDelegate?.Invoke(list[itemIndex]);
            EndVertical();
        }
        list[itemIndex] = (item1, item2);
    }
    private void DrawListItem<T>(List<T> list, string listMemberName, int itemIndex, bool drawItemEditor) where T : Object
    {
        BeginHorizontal("box");
        if (GUILayout.Button("x", GUILayout.Width(25)))
        {
            list.RemoveAt(itemIndex);
            return;
        }
        if (list[itemIndex] != null)
        {
            list[itemIndex] = DrawObjectField($"{listMemberName} {itemIndex + 1}", list[itemIndex]);
            EndHorizontal();
            if (drawItemEditor)
            {
                BeginVertical("box");
                var ed = CreateEditor(list[itemIndex]);
                ed.OnInspectorGUI();
                EndVertical();
            }
        }
        else
        {
            list[itemIndex] = DrawObjectField("Зарезервированное место", list[itemIndex]);
            EndHorizontal();
        }
    }

    private ((string typeFullName, int index, string typeShortName), bool showInheritorsSelector, List<T> listResult) DrawPreferedAddingButtonsForAbstract<T>(List<T> list, Action<T, int> afterAddingDelegate, string addNAMEinPLACE, string givePlaceFOR,
        (int index, string abstractTypeFullName) inputTuple, bool showInheritorsOptions) where T : ScriptableObject
    {
        addNAMEinPLACE = showInheritorsOptions ? "Скрыть" : addNAMEinPLACE;
        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button(addNAMEinPLACE))
            showInheritorsOptions = !showInheritorsOptions;
        if (GUILayout.Button(givePlaceFOR))
        {
            list.Add(null);
            afterAddingDelegate?.Invoke(null, list.IndexOf(null));
            showInheritorsOptions = false;
        }
        GUILayout.EndHorizontal();
        if (showInheritorsOptions)
            return DrawAbstractInheritorsCreation(ref list, afterAddingDelegate, inputTuple, ref showInheritorsOptions);
        else
            return (default, default, list);
    }

    private ((string typeFullName, int index, string typeShortName), bool showInheritorsSelector, List<T> list)
        DrawAbstractInheritorsCreation<T>(ref List<T> list, Action<T, int> afterAddingDelegate, (int index, string abstractTypeFullName) inputTuple, ref bool show) where T : ScriptableObject
    {
        var type = typeof(T);
        var inheritors = Assembly.GetAssembly(type).GetInheritors(type, false);
        if (inheritors.Count > 0)
            return DrawAbstractInheritorsOptions(ref list, afterAddingDelegate, inputTuple, ref show, inheritors);
        else
        {
            HelpBox($"Абстрактный класс {typeof(T).Name} не имеет наследников", MessageType.Warning);
            return ((null, -1, null), show, null);
        }
    }

    private ((string typeFullName, int index, string typeShortName), bool showInheritorsSelector, List<T> list) DrawAbstractInheritorsOptions<T>(ref List<T> list, Action<T, int> afterAddingDelegate, (int index, string abstractTypeFullName) inputTuple, ref bool show, List<Type> inheritors) where T : ScriptableObject
    {
        var (typeFullName, index, typeShortName) = DrawTypeSelector(inheritors, inputTuple.abstractTypeFullName, inputTuple.index);
        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button("Создать объект"))
        {
            var type = Type.GetType(typeFullName);
            var newAsset = CreateAsset(type, type.Name);
            list.Add((T)newAsset);
            afterAddingDelegate?.Invoke((T)newAsset, list.IndexOf((T)newAsset));
            show = !show;
        }
        GUILayout.EndHorizontal();
        return ((typeFullName, index, typeShortName), show, list);
    }

    public static T DrawEnum<T>(string label, T enm) where T : Enum =>
        (T)EnumPopup(label, enm);

    public static string DrawStringFieldWithDefaultFiller(string fieldLabel, string targetString, string defailtFiller = "missing", float width = -1)
    {
        if (width == -1)
            width = Screen.width;
        if (string.IsNullOrEmpty(targetString))
            return TextField(fieldLabel, defailtFiller, GUILayout.Width(width));
        else
            return TextField(fieldLabel, targetString, GUILayout.Width(width));
    }  

    protected T DrawObjectOrCreateIfNullField<T>(string label, T drawableObj, string creationNewNAMEbtnTitle, bool drawObjEditor = false) where T : ScriptableObject
    {
        drawableObj = DrawObjectField(label, drawableObj, drawObjEditor);
        if (drawableObj == null)
        {
            var type = typeof(T);
            if (type.IsAbstract)
                drawableObj = DrawCreatingButtonsForAbstract<T>(creationNewNAMEbtnTitle);
            else
            {
                GUILayout.BeginHorizontal("box");
                if (GUILayout.Button(creationNewNAMEbtnTitle))
                    return CreateAsset<T>(typeof(T).Name);
                GUILayout.EndHorizontal();
            }
        }
        return drawableObj;
    }

    private T DrawCreatingButtonsForAbstract<T>(string creationName) where T : ScriptableObject
    {
        creationName = showInheritorsOptions ? "Скрыть" : creationName;
        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button(creationName))
        {
            var type = typeof(T);
            inheritors = Assembly.GetAssembly(type).GetInheritors(type, false);
            showInheritorsOptions = !showInheritorsOptions;
        }
        GUILayout.EndHorizontal();
        if (showInheritorsOptions)
        {
            if (inheritors.Count > 0)
                return DrawAbstractInheritorsCreation<T>();
            else
            {
                HelpBox($"Абстрактный класс {typeof(T).Name} не имеет наследников", MessageType.Warning);
                return default;
            }
        }
        else
            return default;
    }

    private T DrawAbstractInheritorsCreation<T>() where T : ScriptableObject
    {
        (abstractTypeFullName, index, _) = DrawTypeSelector(inheritors, abstractTypeFullName, index);
        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button("Создать объект"))
        {
            var type = Type.GetType(abstractTypeFullName);
            var newAsset = (T)CreateAsset(type, type.Name);
            showInheritorsOptions = false;
            return newAsset;
        }
        GUILayout.EndHorizontal();
        return default;
    }

    public static void DeleteAsset<T>(T asset) where T : ScriptableObject =>
        AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(asset));
}
