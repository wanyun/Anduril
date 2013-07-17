using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Anduril.Web.EF;
namespace Anduril.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        static Regex referer_pattern = new Regex("@([^@^\\s^:]{1,})([\\s\\:\\,\\;]{0,1})");//@.+?[\\s:]

        /**
         * 处理提到某人 @xxxx
         * @param msg  传入的文本内容
         * @param referers 传出被引用到的会员名单
         * @return 返回带有链接的文本内容
         */
        public static String _GenerateRefererLinks(String msg, List<long> referers)
        {

            StringBuilder html = new StringBuilder();
            int lastIdx = 0;
            Match matchr = referer_pattern.Match(msg);
            while (matchr.Index > 0)
            {
                String origion_str = matchr.Value;
                String str = origion_str.Substring(1, origion_str.Length).Trim();
                html.Append(msg.Substring(lastIdx, matchr.Index));

                User u = null;
                List<User> users = null;
                if (users != null && users.Count > 0)
                {
                    u = users.FirstOrDefault();
                    //foreach(User ref in users)
                    //{
                    //    if(ref.getThis_login_time()!=null && u.getThis_login_time()!=null && 
                    //            ref.getThis_login_time().after(u.getThis_login_time())){
                    //        u = ref;
                    //    }
                    //}
                }
                if (u == null)
                {
                    //u = User.GetByIdent(str);
                }

                if (u != null && !u.IsBlocked())
                {
                    //html.Append("<a href='"+LinkTool.user(u)+"' class='referer' target='_blank'>@");
                    //html.Append(str.Trim());
                    //html.Append("</a> ");
                    //if(referers != null && !referers.contains(u.getId()))
                    //    referers.add(u.getId());
                }
                else
                {
                    html.Append(origion_str);
                }
                //lastIdx = matchr.;
                //if(ch == ':' || ch == ',' || ch == ';')
                //	html.append(ch);
            }
            html.Append(msg.Substring(lastIdx));
            return html.ToString();
        }
    }

    public class User
    {

        internal bool IsBlocked()
        {
            throw new NotImplementedException();
        }

        internal object getThis_login_time()
        {
            throw new NotImplementedException();
        }
    }
}