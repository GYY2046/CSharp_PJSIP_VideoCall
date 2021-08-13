using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace friVideoCall
{
    public enum VideoFormStatusCommand
    {
        /// <summary>
        /// 初始状态
        /// </summary>
        Init,
        /// <summary>
        /// 拨打电话
        /// </summary>
        MakeCall,
        /// <summary>
        /// 接听电话
        /// </summary>
        AnswerCall,
        /// <summary>
        /// 挂断电话
        /// </summary>
        HangCall
    }
}
