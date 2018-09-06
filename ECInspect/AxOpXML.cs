using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ECInspect
{
    class MyBaseClass
    {
        protected string m_strLastError = "";
        public string GetLastError()
        {
            return m_strLastError;
        }
    }

    /// <summary>
    /// 自定义的XML操作类
    /// </summary>
    class OpXML:MyBaseClass
    {
        public const string _XML_PATH = "Config.XML";//默认XML文件
        public const string _XML_NODE_ROOT = "Root";//默认根节点

        #region Construction/Destruction
        public OpXML() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strXMLPath">XML文件路径，若不存在，将自动创建</param>
        public OpXML(string strXMLPath)
        {
            if (!System.IO.File.Exists(strXMLPath))
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration Declaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                XmlNode xnRoot = xmlDoc.AppendChild(xmlDoc.CreateElement(OpXML._XML_NODE_ROOT));
                xmlDoc.Save(strXMLPath);
            }
        }
        #endregion
        /// <summary>
        /// 判断某个节点是否存在
        /// </summary>
        /// <param name="strFilePath">xml文件完整路径</param>
        /// <param name="strNodeName">节点名称</param>
        /// <returns>true表示存在，false表示不存在</returns>
        public bool NodeIsExisted(string strFilePath, string strNodeName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilePath);
            if (FindNode(xmlDoc.DocumentElement, strNodeName) != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 遍历查找指定名称的XmlNode
        /// </summary>
        /// <param name="xn">从节点xn开始查找遍历</param>
        /// <param name="strNodeName">要查找的节点名称</param>
        /// <returns>返回找到的节点</returns>
        private static XmlNode FindNode(XmlNode xn, string strNodeName)
        {
            if (strNodeName == xn.Name)
            {
                return xn;
            }
            if (xn.HasChildNodes)
            {
                if (FindNode(xn.FirstChild, strNodeName) != null)
                {
                    return FindNode(xn.FirstChild, strNodeName);
                }
            }
            if (xn.NextSibling != null)
            {
                if (FindNode(xn.NextSibling, strNodeName) != null)
                {
                    return FindNode(xn.NextSibling, strNodeName);
                }
            }
            return null;
        }
        /// <summary>
        /// 查找节点,若未找到会创建该节点
        /// </summary>
        /// <param name="xmlDoc">xml文档</param>
        /// <param name="xnParent">指定父节点进行查找，当未找到指定节点时，会在父节点下创建节点</param>
        /// <param name="strNodeName">给定的节点名称</param>
        /// <returns>返回要找的节点</returns>
        private XmlNode CustomizeSelSingleNode(XmlDocument xmlDoc, XmlNode xnParent, string strNodeName)
        {
            XmlNode xn;
            if ((xn = xnParent.SelectSingleNode(strNodeName)) != null)
            {
                return xn;
            }
            else
            {
                return xnParent.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, strNodeName, null));
            }
        }
        /// <summary>
        /// 删除指定名称的节点
        /// </summary>
        /// <param name="strFilePath">xml文档完整路径</param>
        /// <param name="strNodeName">要删除的节点名称</param>
        public void DeleteNode(string strFilePath, string strNodeName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilePath);
            XmlNode xn = FindNode(xmlDoc.DocumentElement, strNodeName);
            XmlNode xn_Parent = xn.ParentNode;
            xn_Parent.RemoveChild(xn);
            xmlDoc.Save(strFilePath);
            return;
        }
        /// <summary>
        /// 删除指定名称的节点 的 属性
        /// </summary>
        /// <param name="strFilePath">xml文档完整路径</param>
        /// <param name="strNodeName">要删除的节点名称</param>
        public void DeleteNodeAttribute(string strFilePath, string strNodeName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilePath);
            XmlNode xn = FindNode(xmlDoc.DocumentElement, strNodeName);
            if (xn != null)
            {
                xn.RemoveAll();
            }
            xmlDoc.Save(strFilePath);
            return;
        }
        /// <summary>
        /// 对指定节点批量添加子节点
        /// </summary>
        /// <param name="strFilePath">xml文件的完整路径</param>
        /// <param name="strNodeName">指定的父节点名称</param>
        /// <param name="lsStrChildNodes">需要添加的子节点名称列表</param>
        public void AppendChildNodes(string strFilePath, string strNodeName, List<string> lsStrChildNodes)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilePath);
            XmlNode xn = FindNode(xmlDoc.DocumentElement, strNodeName);
            foreach (string str in lsStrChildNodes)
            {
                xn.AppendChild(xmlDoc.CreateElement(str));
            }
            xmlDoc.Save(strFilePath);
        }
        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="strFilePath">文件路径</param>
        /// <param name="strParentNode">需要添加子节点的节点名称</param>
        /// <param name="strAddNode">添加节点名称</param>
        /// <param name="strExp">执行发生异常提示</param>
        public void AddNode(string strFilePath, string strParentNode, string strAddNode)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFilePath);
                if (strParentNode == "" || strParentNode == null)
                {
                    xmlDoc.AppendChild(xmlDoc.CreateElement(strAddNode));
                    xmlDoc.Save(strFilePath);
                }
                else 
                {
                    XmlNode xnParent = FindNode(xmlDoc.DocumentElement, strParentNode);
                    xnParent.AppendChild(xmlDoc.CreateElement(strAddNode));
                    xmlDoc.Save(strFilePath);
                }
                
                
            }
            catch (Exception ex)
            {
                m_strLastError = ex.Message;
            }
        }
        /// <summary>
        /// 获取某一节点的所有子节点
        /// </summary>
        /// <param name="strFilePath">xml文件的完整路径</param>
        /// <param name="strNodeName">指定父节点的名称</param>
        /// <returns>返回所有子节点名</returns>
        public static List<XmlNode> GetChildNodes(string strFilePath, string strNodeName)
        {
            List<XmlNode> lsNode = new List<XmlNode> { };
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilePath);
            XmlNode xn = FindNode(xmlDoc.DocumentElement, strNodeName);
            if (xn != null)
            {
                if (xn.HasChildNodes)
                {
                    lsNode.Add(xn.FirstChild);
                    xn = xn.FirstChild;
                    while ((xn = xn.NextSibling) != null)
                    {
                        lsNode.Add(xn);
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
            return lsNode;
        }
        /// <summary>
        /// 设置节点属性,若该节点不存在，则会自动在父节点下创建节点并设置属性值
        /// </summary>
        /// <param name="strFilePath">xml文件完整路径</param>
        /// <param name="strParentNode">需要设置的节点的父节点，用于定位指定节点</param>
        /// <param name="strNode">需要设置的节点名</param>
        /// <param name="strAttribute">需要设置的属性名称</param>
        /// <param name="strValue">需要设置的属性值</param>
        /// <returns></returns>
        public bool CustomizeSetAttribute(string strFilePath, string strParentNode, string strNode, string strAttribute, string strValue)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFilePath);
                XmlNode xnParent = FindNode(xmlDoc.DocumentElement, strParentNode);
                XmlElement xe = (XmlElement)CustomizeSelSingleNode(xmlDoc, xnParent, strNode);
                xe.SetAttribute(strAttribute, strValue);
                xmlDoc.Save(strFilePath);
                return true;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// 获取节点属性值
        /// </summary>
        /// <param name="strFilePath">xml文件完整路径</param>
        /// <param name="strParentNode">制定节点的父节点名称</param>
        /// <param name="strNode">指定的节点名称</param>
        /// <param name="strAttribute">属性名</param>
        /// <param name="strDefaultRet">如果获取失败，返回预设的默认值</param>
        /// <returns></returns>
        public string CustomizeGetAttribute(string strFilePath, string strParentNode, string strNode, string strAttribute, string strDefaultRet)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFilePath);
                XmlNode xnRoot = FindNode(xmlDoc.DocumentElement, strParentNode);
                XmlElement xe = (XmlElement)CustomizeSelSingleNode(xmlDoc, xnRoot, strNode);
                xmlDoc.Save(strFilePath);
                return (xe.GetAttribute(strAttribute) != "") ? xe.GetAttribute(strAttribute) : strDefaultRet;
            }
            catch
            {
                return strDefaultRet;
            }

        }               

        /// <summary>
        /// 重命名节点
        /// </summary>
        /// <param name="strFilePath">XML文件完整路径</param>
        /// <param name="strOldNode">之前的节点名称</param>
        /// <param name="strNewNode">新的节点名称</param>
        /// <returns>true表示重命名成功，false则是失败</returns>
        public bool RenameNode(string strFilePath, string strOldNode, string strNewNode)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFilePath);
                XmlNode xnOldNode = FindNode(xmlDoc.DocumentElement, strOldNode);
                if (xnOldNode == null)
                {
                    throw new Exception("未找到该名称的节点！");
                }
                XmlNode xnNewNode = xnOldNode.ParentNode.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, strNewNode, null));
                while (xnOldNode.HasChildNodes)
                {
                    xnNewNode.AppendChild(xnOldNode.FirstChild);
                    //xnOldNode.RemoveChild(xnOldNode.FirstChild);
                }
                xnOldNode.ParentNode.RemoveChild(xnOldNode);
                xmlDoc.Save(strFilePath);
                return true;
            }
            catch (Exception ex)
            {
                m_strLastError = ex.Message;
                return false;
            }

        }
   
    }
}
