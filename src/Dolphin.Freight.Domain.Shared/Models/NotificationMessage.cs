using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Dolphin.Freight.Models
{
    public class NotificationMessage
    {
        public MessageType MsgType { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }

        public NotificationMessage() { }

        public NotificationMessage(string message = null, string title = null, MessageType msgType = MessageType.Info)
        {
            MsgType = msgType;
            Message = message ?? "";
            Title = title ?? "";
        }

        /// <summary>
        /// 將內容轉換為 Javascript 顯示在網頁上的語法
        /// </summary>
        /// <param name="useHtml">是否將 Message 以 Html 的方式呈現</param>
        /// <returns></returns>
        public string JavascriptString(bool useHtml = false)
        {
            string js = "<script type=\"text/javascript\">\r\n";
            js += "\twindow.onload = function () {\r\n";

            if (useHtml)
            {
                js += $"\t\tSwal.fire({{\r\n";
                js += $"\t\t\ttitle: '{Title.Replace("'", @"\'")}',\r\n";
                js += $"\t\t\thtml: '{Message.Replace("'", @"\'")}',\r\n";
                js += $"\t\t\ticon: '{MsgType.ToString().ToLower()}',\r\n";
                js += $"\t\t}});\r\n";
            }
            else
            {
                js += $"\t\tabp.message.{MsgType.ToString().ToLower()}('{Message.Replace("'", @"\'")}','{Title.Replace("'", @"\'")}');\r\n";
            }

            js += "\t};\r\n";
            js += "</script>";

            return js;
        }

    }

    public enum MessageType
    {
        Info = 0,
        Success = 1,
        Warn = 2,
        Error = 3
    }

}
