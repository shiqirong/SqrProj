﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.Common.Utils
{

    /// <summary>
    ///  数字编号生成基类
    /// </summary>
    public class BaseNumGenerator
    {
        // 符号位(1位) + Timestamp(41位 最长70年) + WorkId + sequence  = 编号Id (64位)

        //【sequence 部分】  随机序列 
        private long _maxSequence; // 最大值
        private int _sequenceBitLength; //长度

        // 【WorkId部分】 工作Id 
        private long _maxWorkerId;    // 最大值
        private int _workerIdBitLength; // 长度
        /// <summary>
        ///  workerId需要偏移的位置
        /// </summary>
        protected int WorkerLeftShift { get; private set; }

        /// <summary>
        /// Timestamp 需要偏移的位置
        /// </summary>
        protected int TimestampLeftShift { get; private set; }

        private void InitailConfig(int seqBitLength, int worIdBitLength)
        {
            _sequenceBitLength = seqBitLength;
            _maxSequence = -1L ^ (-1L << _sequenceBitLength);

            _workerIdBitLength = worIdBitLength;
            _maxWorkerId = -1L ^ (-1L << _workerIdBitLength);
            WorkerLeftShift = _sequenceBitLength;

            TimestampLeftShift = WorkerLeftShift + _workerIdBitLength;
        }

        /// <summary>
        ///  获取当前的工作ID
        /// </summary>
        public long WorkId { get; }


        private long _sequence;   //  时间戳下 序号值
        private long _timestamp;  // 最后一次的时间戳值

        private readonly object obj = new object();// 
        /// <summary>
        /// 构造函数
        /// </summary>
        protected BaseNumGenerator(long workId, int seqBitLength, int worIdBitLength)
        {
            InitailConfig(seqBitLength, worIdBitLength);

            if (workId > _maxWorkerId || workId < 0)
            {
                throw new ArgumentException("workId", $"工作Id不能大于 {_maxWorkerId} 或 小于 0");
            }
            WorkId = workId;
        }


        /// <summary>
        ///  生成下一个编号
        /// </summary>
        /// <returns></returns>
        public long NextNum()
        {
            long ts, seq;
            lock (obj)
            {
                SetTimestampAndSeq();
                ts = _timestamp;
                seq = _sequence;
            }
            return CombineNum(ts, seq);
        }

        /// <summary>
        ///   组合数字ID
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        protected virtual long CombineNum(long timestamp, long sequence)
        {
            return (timestamp << TimestampLeftShift)
                         | (WorkId << WorkerLeftShift)
                         | sequence;
        }

        private void SetTimestampAndSeq()
        {
            var newTimestamp = NumUtil.TimeMilliNum();
            if (newTimestamp < _timestamp)
            {
                //如果当前时间小于上一次ID生成的时间戳，说明系统时钟回退过这个时候应当抛出异常
                throw new ArgumentException(
                    $"当前时间小于上次生成时间 {_timestamp - newTimestamp} 毫秒，注意系统时间是否发生变化！");
            }

            // 如果是同一时间生成的，则进行毫秒内序列
            if (_timestamp == newTimestamp)
            {
                _sequence = (_sequence + 1) & _maxSequence;

                //毫秒内序列溢出
                //阻塞到下一个毫秒,获得新的时间戳
                if (_sequence == 0)
                    newTimestamp = WaitNextMillis(_timestamp);
            }
            //时间戳改变，毫秒内序列重置
            else
                _sequence = 0L;

            _timestamp = newTimestamp;
        }

        /// <summary>
        ///  当前毫秒内序列使用完，等待下一毫秒
        /// </summary>
        /// <returns></returns>
        protected long WaitNextMillis(long curTimeSpan)
        {
            long timeTicks;
            do
            {
                timeTicks = NumUtil.TimeMilliNum();
            } while (timeTicks <= curTimeSpan);
            return timeTicks;
        }
    }

    /// <summary>
    /// 生成兼容js的编号（53bit）
    /// </summary>
    public class SmallNumGenerator : BaseNumGenerator
    {
        public SmallNumGenerator(long workId) : base(workId, 9, 3)
        {

        }
    }

    /// <summary>
    ///  唯一编码生成类
    ///   受限工单JS使用，并且已经通过数据库生成15位，强制在53位占1
    /// </summary>
    public class JsNum16LenGenerator : BaseNumGenerator
    {
        //  53位唯一Id确认 
        // 符号位(1位) + 最高位占位(1位) + Timestamp(41位 最长70年) + WorkId(2位 范围0-3) + sequence(9位 范围0-511)  = 编号Id (64位)

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="workId"></param>
        public JsNum16LenGenerator(long workId) : base(workId, 9, 2)
        {
            highBaseConst = 1L << (TimestampLeftShift + 41);
        }

        private readonly long highBaseConst;
        /// <summary>
        ///  重新定义编号合并规则
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        protected override long CombineNum(long timestamp, long sequence)
        {
            return highBaseConst
                   | (timestamp << TimestampLeftShift)
                   | (WorkId << WorkerLeftShift)
                   | sequence;
        }
    }

    /// <summary>
    ///  唯一编码生成类
    /// </summary>
    public class NumGenerator : BaseNumGenerator
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="workId">当前的工作id 最大值不能超过（2的11次方 - 1）</param>
        public NumGenerator(long workId) : base(workId, 12, 10)
        {
        }
    }

    /// <summary>
    ///  唯一数字编码生成静态通用类
    /// </summary>
    public static class NumUtil
    {
        private static readonly long _timeStartTicks = new DateTime(2017, 12, 1).ToUniversalTime().Ticks;
        private static readonly Random _rnd = new Random(DateTime.Now.Millisecond);

        /// <summary>		
        /// 随机数字		
        /// </summary>		
        /// <returns></returns>		
        public static string RandomNum(int length = 4)
        {
            var num = new StringBuilder(length);
            for (var i = 0; i < length; i++)
            {
                num.Append(_rnd.Next(0, 9));
            }
            return num.ToString();
        }


        private static readonly NumGenerator generator = new NumGenerator(0);
        private static readonly SmallNumGenerator smallGeneratetor = new SmallNumGenerator(7);
        private static readonly JsNum16LenGenerator generator16 = new JsNum16LenGenerator(3);

        /// <summary>
        /// twitter 的snowflake唯一Id算法(排除机器位)
        /// </summary>
        /// <returns></returns>
        public static long SnowNumBig()
        {
            return generator.NextNum();
        }

        /// <summary>
        ///  小值的数字编号
        /// </summary>
        /// <returns></returns>
        public static long SnowNum()
        {
            return smallGeneratetor.NextNum();
        }

        /// <summary>
        ///   受限工单，生成满足js使用的16位长度数字ID
        /// </summary>
        /// <returns></returns>
        public static long SnowNumJs16()
        {
            return generator16.NextNum();
        }

        /// <summary>
        ///  时间戳数字编号（精度 毫秒
        /// </summary>
        /// <returns></returns>
        public static long TimeMilliNum()
        {
            return (DateTime.UtcNow.Ticks - _timeStartTicks) / 10000;
        }

        /// <summary>
        ///  时间戳（秒）+ 主编号的后四位 生成的数字编号
        /// </summary>
        /// <param name="mainNum"></param>
        /// <returns></returns>
        public static long SubTimeNum(long mainNum)
        {
            var suffixNum = mainNum % 10000;
            return Convert.ToInt64(string.Concat(TimeMilliNum(), suffixNum));
        }



    }
}
