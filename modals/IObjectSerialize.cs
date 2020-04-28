using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebEFCoreDemo.modals
{
    public interface IObjectSerialize
    {
        /// <summary>
        /// 处理流对象。部分字段作为不直接保存到数据中，而保存在流字段中所做的转换。
        /// </summary>
        void SaveToStreamField();


        /// <summary>
        /// 处理流对象。部分字段作为不直接保存到数据中，而保存在流字段中所做的转换。
        /// </summary>
        void LoadFromStreamField();

        /// <summary>
        /// 处理流对象。部分字段作为不直接保存到数据中，而保存在流字段中所做的转换。
        /// </summary>
        void SaveToXMLField();


        /// <summary>
        /// 处理流对象。部分字段作为不直接保存到数据中，而保存在流字段中所做的转换。
        /// </summary>
        void LoadFromXMLField();


    }
}
