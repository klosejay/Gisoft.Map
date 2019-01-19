using Gisoft.Map.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map
{

    /// <summary>
    /// 耗时处理任务
    /// </summary>
    public interface IProcessTask
    {
        /// <summary>
        /// 任务名
        /// </summary>
        string TaskId { get; }

        /// <summary>
        /// 开始时间
        /// </summary>
        DateTime? StartTime { get; }

        /// <summary>
        /// 结束时间
        /// </summary>
        DateTime? EndTime { get; }

        /// <summary>
        /// 开始处理
        /// </summary>
        /// <param name="progressHandler">进度变化回调</param>
        void StartAsync(IProgressHandler progressHandler = null);

        /// <summary>
        /// 取消
        /// </summary>
        void Cancel();

        /// <summary>
        /// 进度变化
        /// </summary>
        event ProgressEventHandler Progress;

        /// <summary>
        /// 状态
        /// </summary>
        ProcessStatus Status { get; set; }
    }
    public abstract class ProcessTaskBase : IProcessTask
    {
        public abstract string TaskId { get; }

        public DateTime? StartTime { get; protected set; }

        public DateTime? EndTime { get; protected set; }

        public ProcessStatus Status { get; set; } = ProcessStatus.NotStart;

        public event ProgressEventHandler Progress;

        protected IProgressHandler ProgressHandler { get; set; }

        public virtual void Cancel()
        {
            IsCancel = true;
        }
        protected bool IsCancel = false;
        public virtual async void StartAsync(IProgressHandler progressHandler = null)
        {
            Status = ProcessStatus.Processing;
            StartTime = DateTime.Now;
            ProgressHandler = progressHandler;
            SendProgressMessage(TaskId, 0, "处理开始");
            try
            {
               await DoProcess();
            }
            catch(ProcessTaskCanceledException cancelException)
            {
                EndTime = DateTime.Now;
                Status = ProcessStatus.Canceled;
                SendProgressMessage(TaskId, 100, "任务已取消");
            }
            catch(ProcessTaskErrorException errorException)
            {
                EndTime = DateTime.Now;
                Status = ProcessStatus.Error;
                SendProgressMessage(TaskId, 0, $"错误：{errorException.Description}");
            }
            EndTime = DateTime.Now;
            Status = ProcessStatus.Completed;
            SendProgressMessage(TaskId, 100, "处理完成");

        }
        /// <summary>
        /// 发送处理信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="percent"></param>
        /// <param name="message"></param>
        protected void SendProgressMessage(string key, int percent, string message)
        {
            ProgressHandler?.OnProgress(key, percent, message);
            Progress?.Invoke(new ProgressEventArgs() { Key = key, Percent = percent, Message = message });
        }
        protected abstract Task DoProcess();
    }
    public enum ProcessStatus
    {
        /// <summary>
        /// 未开始
        /// </summary>
        NotStart = 0,
        /// <summary>
        /// 运行中
        /// </summary>
        Processing = 1,
        /// <summary>
        /// 已完成
        /// </summary>
        Completed = 2,
        /// <summary>
        /// 已取消
        /// </summary>
        Canceled = 3,
        /// <summary>
        /// 出错
        /// </summary>
        Error = 4,
    }
    /// <summary>
    /// 耗时任务回调
    /// </summary>
    public interface IProgressHandler
    {
        /// <summary>
        /// 任务进度变化时的操作
        /// </summary>
        /// <param name="key"></param>
        /// <param name="percent"></param>
        /// <param name="message"></param>
        /// <param name="status"></param>
        void OnProgress(string key, int percent, string message);
    }
    /// <summary>
    /// 耗时处理任务进度事件
    /// </summary>
    /// <param name="e"></param>
    public delegate void ProgressEventHandler(ProgressEventArgs e);

    /// <summary>
    /// 耗时处理任务进度参数
    /// </summary>
    public class ProgressEventArgs : EventArgs
    {
        /// <summary>
        /// 任务名
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 完成百分百（1-100）
        /// </summary>
        public int Percent { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
    }
}
