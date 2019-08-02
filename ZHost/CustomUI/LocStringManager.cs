using System.Reflection;
using System.Resources;

namespace ZHost.CustomUI
{
    public static class LocStringManager
    {
        #region Properties

        static bool singleton = false;

        #region public

        public static string Question_str;
        public static string Error_str;
        public static string Close_str;
        public static string Warning_str;
        public static string Information_str;

        public static string StationDepthIsNotEnough_str;
        public static string StationInfo_str;
        public static string SetActualStationDepth_str;
        public static string ActualDepth_str;

        public static string RemoteCommand_str;
        public static string RemoteAddressChange_str;
        public static string ResponderZeroDepthAdjust_str;
        public static string SelectALogFileToEmulate_str;
        public static string LogFiles_str;
        public static string LogRestarted_str;
        public static string RestartLogPrompt_str;
        public static string ClearLogsPrompt_str;
        public static string EntriesWereDeleted_str;
        public static string SaveTracksAs_str;
        public static string ClearTracksAfterSavePrompt_str;
        public static string ClearTracksPrompt_str;

        public static string Settings_str;
        public static string SettingsSavedRestartPrompt_str;
        public static string Collapse_str;
        public static string Expand_str;
        public static string AnalysissOf_str;
        public static string IsComplete_str;

        public static string ResetToDefaultSettingsPrompt_str;
        public static string Salinity_str;
        public static string SoundSpeed_str;

        #endregion

        #endregion

        #region Methods

        public static void Init(string baseName, Assembly assembly)
        {
            if (!singleton)
            {
                ResourceManager locRM = new ResourceManager(baseName, assembly);

                Question_str = locRM.GetString("_Question");
                Error_str = locRM.GetString("_Error");
                Close_str = locRM.GetString("_Close");
                Warning_str = locRM.GetString("_Warning");
                Information_str = locRM.GetString("_Information");

                StationDepthIsNotEnough_str = locRM.GetString("_StationDepthIsNotEnough");
                StationInfo_str = locRM.GetString("_StationInfo");
                SetActualStationDepth_str = locRM.GetString("_SetActualStationDepth");
                ActualDepth_str = locRM.GetString("_ActualDepth");

                RemoteCommand_str = locRM.GetString("_RemoteCommand");
                RemoteAddressChange_str = locRM.GetString("_RemoteAddressChange");
                ResponderZeroDepthAdjust_str = locRM.GetString("_ResponderZeroDepthAdjust");
                SelectALogFileToEmulate_str = locRM.GetString("_SelectALogFileToEmulate");
                LogFiles_str = locRM.GetString("_LogFiles");
                LogRestarted_str = locRM.GetString("_LogRestarted");
                RestartLogPrompt_str = locRM.GetString("_RestartLogPrompt");
                ClearLogsPrompt_str = locRM.GetString("_ClearLogsPrompt");
                EntriesWereDeleted_str = locRM.GetString("_EntriesWereDeleted");
                SaveTracksAs_str = locRM.GetString("_SaveTracksAs");
                ClearTracksAfterSavePrompt_str = locRM.GetString("_ClearTracksAfterSavePrompt");
                ClearTracksPrompt_str = locRM.GetString("_ClearTracksPrompt");

                Settings_str = locRM.GetString("_Settings");
                SettingsSavedRestartPrompt_str = locRM.GetString("_SettingsSaveRestartPrompt");
                Collapse_str = locRM.GetString("_Collapse");
                Expand_str = locRM.GetString("_Expand");
                AnalysissOf_str = locRM.GetString("_AnalysisOf");
                IsComplete_str = locRM.GetString("_IsComplete");

                ResetToDefaultSettingsPrompt_str = locRM.GetString("_ResetToDefaultSettingsPrompt");

                Salinity_str = locRM.GetString("_Salinity");
                SoundSpeed_str = locRM.GetString("_SoundSpeed");

                singleton = true;
            }
        }

        #endregion
    }
}
