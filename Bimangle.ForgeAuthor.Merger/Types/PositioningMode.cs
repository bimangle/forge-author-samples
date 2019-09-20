using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bimangle.ForgeBrowser.Author.Merger.Types
{
    /// <summary>
    /// 坐标对齐模式
    /// </summary>
    public enum PositioningMode
    {
        /// <summary>
        /// 通过共享坐标
        /// </summary>
        BySharedCoordinates = 0,

        /// <summary>
        /// 原点对原点
        /// </summary>
        OriginToOrigin = 1,

        /// <summary>
        /// 项目基点到项目基点
        /// </summary>
        ProjectBasePointToProjectBasePoint = 2,

        /// <summary>
        /// 中心对中心
        /// </summary>
        CenterToCenter = 3,
    }
}
