using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    [CreateAssetMenu(menuName = "EntranceTemplatesConfig/Config", fileName = "Config")]
    public class EntranceTemplateConfig : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private MatrixTemplate entrancePlacingTemplate;
        [SerializeField] private List<(MatrixTemplate, EntranceRoleBase)> entrancesRolesTemplates;
        [SerializeField] [HideInInspector] List<MatrixTemplate> rolesTemplates;
        [SerializeField] [HideInInspector] List<EntranceRoleBase> roles;
        public MatrixTemplate EntrancePlacingTemplate { get => entrancePlacingTemplate; set => entrancePlacingTemplate = value; }
        public List<(MatrixTemplate, EntranceRoleBase)> EntrancesRolesTemplates { get => entrancesRolesTemplates; set => entrancesRolesTemplates = value; }

        public void OnAfterDeserialize()
        {
            entrancesRolesTemplates = new List<(MatrixTemplate, EntranceRoleBase)>();
            for (int i = 0; i < rolesTemplates.Count; i++)
            {
                entrancesRolesTemplates.Add((rolesTemplates[i],roles[i]));
            }
            rolesTemplates = null;
            roles = null;
        }

        public void OnBeforeSerialize()
        {
            rolesTemplates = new List<MatrixTemplate>();
            roles = new List<EntranceRoleBase>();
            foreach (var pair in entrancesRolesTemplates)
            {
                rolesTemplates.Add(pair.Item1);
                roles.Add(pair.Item2);
            }
        }
    }
}