using BehaviourModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuildTester : MonoBehaviour
{
    [SerializeField] RawCharacterValuesHandler characterBuilder;
    [SerializeField] PupilAgent agentToBuild;

    [ContextMenu("ApplyCharacter")]
    public void ApplyNewCharacter()
    {
        agentToBuild.CharacterSystem.RemoveTraits();
        agentToBuild.CharacterSystem.Initiate(characterBuilder);
        Debug.Log($"New character:\n {agentToBuild.CharacterSystem}");
    }
    private void Start()
    {
        ApplyNewCharacter();
    }
    [ContextMenu("Randomize")]
    public void Randomize()
    {
        characterBuilder.Randomize();
    }
}
