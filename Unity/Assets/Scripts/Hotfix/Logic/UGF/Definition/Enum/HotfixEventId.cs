namespace Hotfix.Logic
{
    public class HotfixEventId
    {
        /// <summary>
        /// 进入地图
        /// </summary>
        public const int OnSelectMap = 10001;

        /// <summary>
        /// 经理金币
        /// </summary>
        public const int MapCoinChange = 10002;

        /// <summary>
        /// 区域金币
        /// </summary>
        public const int GameCoinChange = 10003;
        
        /// <summary>
        /// 数据存储时候
        /// </summary>
        public const int OnSettingSave = 10004;

        /// <summary>
        /// 建筑业务改变时候（物品）
        /// </summary>
        public const int BuildingBusinessChange = 10005;

        /// <summary>
        /// 站点天赋变化
        /// </summary>
        public const int SitePointChange = 10006;

        /// <summary>
        /// 三消积分变化时
        /// </summary>
        public const int SanXiaoScoreChange = 10007;

        /// <summary>
        /// 回合开始
        /// </summary>
        public const int SanXiaoRoundStart = 10008;
        
        /// <summary>
        /// 回合的消除数变化
        /// </summary>
        public const int RoundEliminateNumChange = 10009;
        
        /// <summary>
        /// 三消展示时间
        /// </summary>
        public const int SanXiaoShowTime = 10010;
        
        /// <summary>
        /// 三消暂停时间
        /// </summary>
        public const int SanXiaoPauseTime = 10011;
        
        /// <summary>
        /// 三消操作事件
        /// </summary>
        public const int SanXiaoOperate = 10012;
        
        /// <summary>
        /// 三消时间刷新事件
        /// </summary>
        public const int SanXiaoUpdateTime = 10013;
        
        /// <summary>
        /// 三消操作超时
        /// </summary>
        public const int SanXiaoOperateTimeOut = 10014;

        /// <summary>
        /// 三消操作次数变化
        /// </summary>
        public const int SanXiaoOperateCountChange = 10015;

        /// <summary>
        /// 三消战斗开始
        /// </summary>
        public const int SanXiaoFightStart = 10016;
        
        /// <summary>
        /// 操作一次的Combo数
        /// </summary>
        public const int InputEliminateComboNumChange = 10017;
        
        /// <summary>
        /// 回合中最大的一次操作Combo数
        /// </summary>
        public const int RoundMaxInputEliminateComboNum = 10018;
        
        /// <summary>
        /// 新一次输入
        /// </summary>
        public const int NewInput = 10019;
        
    }
}