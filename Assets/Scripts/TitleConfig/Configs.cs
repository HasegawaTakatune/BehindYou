using System;
using System.Collections.ObjectModel;

namespace Configs
{
    public static class ConfigStatus
    {
        /// <summary>
        /// 解像度
        /// </summary>
        public const string RESOLUTION = "RESOLUTION";

        /// <summary>
        /// 解像度段階
        /// </summary>
        public enum RESOLUTIONS
        {
            LOW = 0,
            NORMAL,
            HIGH,
            EPIC,
            MAX,
        }

        /// <summary>
        /// バックグラウンド音量
        /// </summary>
        public const string BGM = "BGM";

        /// <summary>
        /// 効果音量
        /// </summary>
        public const string SE = "SE";

        /// <summary>
        /// 声量
        /// </summary>
        public const string VOICE = "VOICE";

        /// <summary>
        /// テキスト速度
        /// </summary>
        public const string TEXT_SPEED = "TEXT_SPEED";

        /// <summary>
        /// 設定名リスト
        /// </summary>
        /// <value></value>
        public static readonly ReadOnlyCollection<string> ConfigKeys = Array.AsReadOnly(new string[] { RESOLUTION, BGM, SE, VOICE, TEXT_SPEED });

        /// <summary>
        /// 定数名リスト用 ConfigKeys配列と連動させて使う
        /// /// </summary>
        public enum CONFIG_INDEX
        {
            RESOLUTION = 0,
            BGM,
            SE,
            VOICE,
            TEXT_SPEED,
            MAX,
        }
    }
}