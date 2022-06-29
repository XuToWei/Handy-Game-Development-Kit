using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace UGF
{
    public class BuiltinComponent : GameFrameworkComponent
    {
        [SerializeField]
        private TextAsset m_BuildInfoTextAsset;

        [SerializeField]
        private TextAsset m_DefaultDictionaryTextAsset;

        [SerializeField]
        private BuiltinUpdateResourceForm m_UpdateResourceFormTemplate;
        
        [SerializeField]
        private BuiltinDialogForm m_DialogFormTemplate;

        private BuildInfo m_BuildInfo;
        
        public BuildInfo BuildInfo => m_BuildInfo;

        public BuiltinUpdateResourceForm UpdateResourceFormTemplate => m_UpdateResourceFormTemplate;

        public BuiltinDialogForm DialogFormTemplate => m_DialogFormTemplate;

        public void InitBuildInfo()
        {
            if (m_BuildInfoTextAsset == null || string.IsNullOrEmpty(m_BuildInfoTextAsset.text))
            {
                Log.Info("Build info can not be found or empty.");
                return;
            }

            m_BuildInfo = Utility.Json.ToObject<BuildInfo>(m_BuildInfoTextAsset.text);
            if (m_BuildInfo == null)
            {
                Log.Warning("Parse build info failure.");
                return;
            }
        }

        public void InitDefaultDictionary()
        {
            if (m_DefaultDictionaryTextAsset == null || string.IsNullOrEmpty(m_DefaultDictionaryTextAsset.text))
            {
                Log.Info("Default dictionary can not be found or empty.");
                return;
            }

            if (!GameEntry.Localization.ParseData(m_DefaultDictionaryTextAsset.text))
            {
                Log.Warning("Parse default dictionary failure.");
                return;
            }
        }

        public BuiltinDialogForm OpenDialogForm(BuiltinDialogParams dialogParams)
        {
            BuiltinDialogForm dialogForm = Instantiate(m_DialogFormTemplate);
            dialogForm.Open(dialogParams);
            return dialogForm;
        }

        public BuiltinUpdateResourceForm OpenUpdateResourceForm()
        {
            BuiltinUpdateResourceForm updateResourceForm = Instantiate(m_UpdateResourceFormTemplate);
            return updateResourceForm;
        }
    }
}
