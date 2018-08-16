using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider
{
    public class EventController
    {


        /// <summary>
        /// 抓取完成事件
        /// </summary>
        public event EventHandler<EventControllerArgs> OnSpiderDataCompletedEvent;

        /// <summary>
        /// 分析完成时间
        /// </summary>
        public event EventHandler<EventControllerArgs> OnAnalyseDataCompletedEvent;

        /// <summary>
        /// 插入完成时间
        /// </summary>
        public event EventHandler<EventControllerArgs> OnExecPageDBDataCompletedEvent;

        /// <summary>
        /// 所有需要分析的，都完成事件
        /// </summary>
        public event EventHandler<EventControllerArgs> OnAllItemAnalyzeCompletedEvent;

        /// <summary>
        /// 日志输入事件
        /// </summary>
        public event EventHandler<EventControllerArgs> OntxtviewCompletedEvent;

        /// <summary>
        /// 列表页集合
        /// </summary>

        public EventHandler<EventControllerArgs> OnSpiderDataCompleted;
        public EventHandler<EventControllerArgs> OnAnalyseDataCompleted;
        public EventHandler<EventControllerArgs> OnExecPageDBDataCompleted;
        public EventHandler<EventControllerArgs> OnAllItemAnalyzeCompleted;
        public EventHandler<EventControllerArgs> OntxtviewCompleted;

        public EventController()
        {

            OnSpiderDataCompleted = OnSpiderDataCompletedEvent;
            OnAnalyseDataCompleted = OnAnalyseDataCompletedEvent;
            OnExecPageDBDataCompleted = OnAnalyseDataCompletedEvent;
            OnAllItemAnalyzeCompleted = OnAllItemAnalyzeCompletedEvent;
            OntxtviewCompleted = OntxtviewCompletedEvent;
        }

        /// <summary>
        /// 分析事件参数
        /// </summary>
        public class EventControllerArgs : EventArgs
        {
            public EventControllerArgs()
            {
                Total = 0;
                IsSuccess = true;
                Msg = "";
            }
            public bool IsSuccess { get; set; }
            public object Data { get; set; }
            public int Total { get; set; }
            public string Msg { get; set; }
        }

    }
}
