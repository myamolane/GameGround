using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utility;

namespace GameGround.Api
{
    public class LocalizedProvider : ILocalizedProvider
    {
        static readonly Dictionary<string, string> Values = new Dictionary<string, string>
        {
            {"Code","代码" },
            {"Email","邮箱" },
            {"Region","地区" },
            {"UserName", "用户名"},
            {"Login","账号" },
            {"Player","玩家" },
            {"Name", "名称"},
            {"Password", "密码"},
            {"ZoneDescription", "空间简介"},
            {"User", "用户"},
            {"Post", "帖子"},
            {"Course", "课程"},
            {"Tags", "知识点"},
            {"Comment", "评论"},
            {"Note", "笔记"},
            {"Content", "文字内容"},
            {"Object", "数据"},
            {"InvalidEmailAddress", "邮件地址不合法"},
            {"Message", "留言"},
            {"Event", "动态"},
            {"Required", "请输入 {0}"},
            {"UploadRequired", "请上传 {0}" },
            {"MaxLengthError", "{0} 超出字数限制"},
            {"MaxLength", "{0} 最多 {1} 个字符"},
            {"NotFound", "不存在"},
            {"DuplicateData", "{0} 已经存在"},
            {"FileNotFound", "文件不存在"},
            {"AccessDenied", "对不起，您没有权限进行此操作，请联系管理员"},
            {"InvalidRequest", "Invalid Request"},
            {"IncorrectPassword", "密码不正确" },
            {"AtLeast2Tags", "请至少选择两个知识点"},
            {"FailedToMergeTags", "合并知识点失败，请刷新页面后重试"},
            {"FailedToInsert", "添加 {0} 失败，请稍后重试"},
            {"FailedToUpdate", "保存数据失败，请稍后重试"},
            {"FailedToDelete", "删除 {0} 失败，请刷新页面后重试"},
            {"InvalidFile", "非法文件"},
            {"FobiddenToRateSelf", "不能评价自己"},
            {"InternalError", "网站出现内部错误，请联系管理员"},
            {"IncludeSensitiveWords", "保存失败，您输入的内容包含以下敏感关键字：{0}"},
            {"DuplicateOperation_Recommend", "已经推荐过了"},
            {"DataRemoved", "无法找到 {0} ，可能已经被删除了！"},
            {"DataNotFound", "无法找到 {0}"},
            {"PleaseUploadFiles", "请上传文件"},
            {"InvalidFiles", "文件正在上传，请稍候"},
            {"NotSame","{0} 不一致" }
        };

        public string GetString(string key)
        {
            return Values.ContainsKey(key) ? Values[key] : key;
        }
    }
}