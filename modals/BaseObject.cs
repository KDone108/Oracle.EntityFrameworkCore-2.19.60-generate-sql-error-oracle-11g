using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebEFCoreDemo.modals
{
    [System.Serializable()]
    public class BaseObject : IObjectSerialize, ICloneable//, IBinarizable
    {

        /// <summary>
        /// 主键            
        /// </summary>
        [Key]
        //[QuerySqlField(IsIndexed = true)]
        public virtual long PK { get; set; } = 0;

        /// <summary>
        /// 外键
        /// </summary>
        public virtual long? FK { get; set; } = -1;

        /// <summary>
        /// 版本号
        /// </summary>
        public virtual int? VERSION { get; set; } = 1;

        /// <summary>
        /// 工作流状态
        /// </summary>
        public virtual string WORKFLOWSTATE { get; set; } = string.Empty;

        /// <summary>
        /// 工作流GUID
        /// </summary>
        public virtual string WORKFLOWGUID { get; set; } = string.Empty;

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), ReadOnly(true)]
        public virtual DateTime? LASTMODIFYTIME { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), ReadOnly(true)]
        public virtual DateTime? CREATETIME { get; set; } = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string GetText()
        {
            return "unknown name";
        }

        /// <summary>
        /// tag 
        /// </summary>
        [XmlIgnore]
        [NotMapped]
        public virtual object Tag { get; set; }

        #region 序列化支持接口

        /// <summary>
        /// 处理流对象。部分字段作为不直接保存到数据中，而保存在流字段中所做的转换。
        /// </summary>
        public virtual void SaveToStreamField()
        {
        }


        /// <summary>
        /// 处理流对象。部分字段作为不直接保存到数据中，而保存在流字段中所做的转换。
        /// </summary>
        public virtual void LoadFromStreamField()
        {
        }

        /// <summary>
        /// 处理流对象。部分字段作为不直接保存到数据中，而保存在流字段中所做的转换。
        /// </summary>
        public virtual void SaveToXMLField()
        {
        }


        /// <summary>
        /// 处理流对象。部分字段作为不直接保存到数据中，而保存在流字段中所做的转换。
        /// </summary>
        public virtual void LoadFromXMLField()
        {
        }

        #endregion

        /// <summary>
        /// 将类的pk 及所属属性的pk也设为-1 ，主要用作对象传递到一个新服务器时用到。
        /// </summary>
        public virtual void ResetPK()
        {
            //_pk = -1;

            List<BaseObject> list = GetSubClassList();

            foreach (BaseObject item in list)
            {
                if (item != null)
                {
                    item.PK = 0;
                }
            }

        }

        /// <summary>
        /// 调置本对象的子对象的最后修改时间。子对象需要时要求继承。
        /// </summary>
        /// <param name="dateTime"></param>
        public virtual void SetLastModifyTime(DateTime dateTime)
        {
            //_lastModifyTime = dateTime;

            List<BaseObject> list = GetSubClassList();

            foreach (BaseObject item in list)
            {
                if (item != null)
                {
                    item.LASTMODIFYTIME = dateTime;
                }
            }

        }

        /// <summary>
        /// 设置本对象的子对象的创建时间。子对象需要时要求继承。
        /// </summary>
        /// <param name="dateTime"></param>
        public virtual void SetCreateTime(DateTime dateTime)
        {
            //_createTime = dateTime;

            List<BaseObject> list = GetSubClassList();

            foreach (BaseObject item in list)
            {
                if (item != null)
                {
                    item.CREATETIME = dateTime;
                }
            }

        }

        //EdifierWill-20151002
        //public virtual DataSet GetSchema()
        //{
        //    return UtilList.CreateDataSetSchema(this.GetType());
        //}

        public virtual string GetPKSQLByCode()
        {
            return string.Empty;
        }

        public virtual string GetHQLOfThis()
        {
            return string.Empty;
        }

        //EdifierWill-20151002
        //public virtual List<Param_Info> GetHQLParamsOfThis()
        //{
        //    return new List<Param_Info>();
        //}

        public virtual string GetKeyText()
        {
            return PK.ToString();
        }

        public virtual List<BaseObject> GetSubClassList()
        {
            List<BaseObject> objectList = new List<BaseObject>();

            objectList.Add(this);

            return objectList;

        }

        #region ICloneable 成员

        public virtual object Clone()
        {
            BaseObject obj = this.MemberwiseClone() as BaseObject;

            obj.VERSION = 1;
            obj.ResetPK();

            return obj;
        }

        #endregion

        /// <summary>
        /// 深拷贝
        /// </summary>
        /// <returns></returns>
        public virtual BaseObject DeepClone()
        {
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, this);
                objectStream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(objectStream) as BaseObject;
            }
        }

        /// <summary>
        /// 浅拷贝
        /// </summary>
        /// <returns></returns>
        public virtual BaseObject ShallowClone()
        {
            return Clone() as BaseObject;
        }


        //EdifierWill-20151002
        //private static Type[] GetKnownType()
        //{
        //    return KnownTypesProvider.GetKnownTypes().ToArray();
        //}

        #region IBinarizable接口成员


        //public virtual void WriteBinary(IBinaryWriter writer)
        //{
        //    foreach(var prop in this.GetType().GetProperties()){
        //        writer.WriteObject(prop.Name, prop.GetValue(this));
        //    }            
        //}

        //public virtual void ReadBinary(IBinaryReader reader)
        //{
        //    foreach (var prop in this.GetType().GetProperties()) {
        //        prop.SetValue(this, reader.ReadObject<object>(prop.Name));
        //    }            
        //}

        #endregion
    }
}
