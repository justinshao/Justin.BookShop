using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Justin.BookShop.Web
{
    public class PagingControl
    {
        /// <summary>
        /// 产生分页控件主函数
        /// </summary>
        /// <param name="currentIndex">当前请求页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="tatalSize">总条数</param>
        /// <param name="torgetUrl">请求提交的目标url,空代表当前页面</param>
        /// <param name="isByAjax">是否异步加载</param>
        /// <returns>html形式的分页控件</returns>
        public static string GenerateControl(int currentIndex, int pageSize, int totalSize, string targetUrl, bool isByAjax)
        {
            targetUrl = targetUrl ?? "";
            string header = GenerateHeader(currentIndex, targetUrl, isByAjax);                               // 头部
            string Pagination = GeneratePagination(currentIndex, pageSize, totalSize, targetUrl, isByAjax);  // 页码
            string footer = GenerateFooter(currentIndex, pageSize, totalSize, targetUrl, isByAjax);          // 尾部
            string pageSelect = GeneratePageSelect(currentIndex, pageSize, totalSize, targetUrl, isByAjax);  // 页码选择
            return "<div class=\"pagination\">" + header + Pagination + footer + pageSelect + "</div>";      // 拼接
        }

        /// <summary>
        /// 产生分页控件的页码部分
        /// 格式要求为：当前请求页前后可选择的页码最多不超过4页
        /// 如：1 2 3  *4* 5 6 7 8...
        ///     1 2 3 4 *5* 6 7 8 9...
        ///     2 3 4 5 *6* 7 8 9
        ///     3 4 5 6 *7* 8 9 10 11...
        /// </summary>
        /// <param name="currentIndex">当前请求页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="tatalSize">总条数</param>
        /// <param name="targetUrl">请求提交的目标url</param>
        /// <param name="isByAjax">是否异步加载</param>
        /// <returns></returns>
        private static string GeneratePagination(int currentIndex, int pageSize, int totalSize, string targetUrl, bool isByAjax)
        {
            StringBuilder sbPagination = new StringBuilder();
            int totalPage = Math.Max((totalSize + pageSize - 1) / pageSize, 1); // 总页数

            // 以下分支代码是产生当前请求页之前(包括当前页)的页码
            if (currentIndex <= 5)
            {
                // <a href="targetUrl">index</a>
                for (int i = 1; i <= currentIndex; i++)
                {
                    string href = targetUrl.Contains("?") ? string.Format("{0}&pageIndex={1}", targetUrl, i) :
                        string.Format("{0}?pageIndex={1}", targetUrl, i);
                    sbPagination.AppendFormat(isByAjax ? "<a href=\"{0}\" onclick=\"getPageByAjax({1});return false;\">{1}</a> "
                                  : "<a href=\"{0}\">{1}</a> ", href, i);
                }
            }
            else
            {
                for (int i = currentIndex - 4; i <= currentIndex; i++)
                {
                    string href = targetUrl.Contains("?") ? string.Format("{0}&pageIndex={1}", targetUrl, i)
                        : string.Format("{0}?pageIndex={1}", targetUrl, i);
                    sbPagination.AppendFormat(isByAjax ? "<a href=\"{0}\" onclick=\"getPageByAjax({1});return false;\">{1}</a> "
                                  : "<a href=\"{0}\">{1}</a> ", href, i);
                }
            }

            // 以下是产生当前页之后的页码
            if (currentIndex != totalPage)
            {
                int maxIndex = Math.Min(totalPage, currentIndex + 4);
                for (int i = currentIndex + 1; i <= maxIndex; i++)
                {
                    string href = targetUrl.Contains("?") ? string.Format("{0}&pageIndex={1}", targetUrl, i) :
                        string.Format("{0}?pageIndex={1}", targetUrl, i);
                    sbPagination.AppendFormat(isByAjax ? "<a href=\"{0}\" onclick=\"getPageByAjax({1});return false;\">{1}</a> "
                                  : "<a href=\"{0}\">{1}</a> ", href, i);
                }

                // 产生省略号
                if (maxIndex < totalPage)
                {
                    sbPagination.Append("...");
                }
            }

            return sbPagination.ToString();
        }

        /// <summary>
        /// 产生头部
        /// </summary>
        /// <param name="currentIndex">当前请求页</param>
        /// <param name="targetUrl">目标地址</param>
        /// <param name="isByAjax">是否异步加载</param>
        /// <returns></returns>
        private static string GenerateHeader(int currentIndex, string targetUrl, bool isByAjax)
        {
            StringBuilder sbHeader = new StringBuilder();
            if (currentIndex != 1)
            {
                string hrefFirst = targetUrl.Contains("?") ? string.Format("{0}&pageIndex={1}", targetUrl, 1) :
                    string.Format("{0}?pageIndex={1}", targetUrl, 1);
                string hrefPrev = targetUrl.Contains("?") ? string.Format("{0}&pageIndex={1}", targetUrl, currentIndex - 1) :
                    string.Format("{0}?pageIndex={1}", targetUrl, currentIndex - 1);
                sbHeader.AppendFormat(isByAjax ? "<a href=\"{0}\" onclick=\"getPageByAjax(1);return false;\">首页</a> " :
                               "<a href=\"{0}\">首页</a> ", hrefFirst);
                sbHeader.AppendFormat(isByAjax ? "<a href=\"{0}\" onclick=\"getPageByAjax({1});return false;\"><<上一页</a> " :
                    "<a href=\"{0}\"><<上一页</a> ", hrefPrev, currentIndex - 1);
            }
            return sbHeader.ToString();
        }

        /// <summary>
        /// 产生尾部
        /// </summary>
        /// <param name="currentIndex">当前请求页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="tatalSize">总条数</param>
        /// <param name="targetUrl">请求的目标url</param>
        /// <returns></returns>
        private static string GenerateFooter(int currentIndex, int pageSize, int totalSize, string targetUrl, bool isByAjax)
        {
            int totalPage = Math.Max((totalSize + pageSize - 1) / pageSize, 1); // 总页数
            StringBuilder sbFooter = new StringBuilder();

            if (currentIndex < totalPage)
            {
                string hrefLast = targetUrl.Contains("?") ? string.Format("{0}&pageIndex={1}", targetUrl, totalPage) : 
                                string.Format("{0}?pageIndex={1}", targetUrl, totalPage);
                string hrefNext = targetUrl.Contains("?") ? string.Format("{0}&pageIndex={1}", targetUrl, currentIndex + 1) :
                        string.Format("{0}?pageIndex={1}", targetUrl, currentIndex + 1);
                sbFooter.AppendFormat(isByAjax ? "<a href=\"{0}\" onclick=\"getPageByAjax({1});return false;\">尾页</a> " :
                                   "<a href=\"{0}\">尾页</a> ", hrefLast, totalPage);
                sbFooter.AppendFormat(isByAjax ? "<a href=\"{0}\" onclick=\"getPageByAjax({1});return false;\">下一页>></a> " :
                                   "<a href=\"{0}\">下一页>></a> ", hrefNext, currentIndex + 1);
            }
            sbFooter.AppendFormat("<label style=\"color:red\">{0}</label>/{1} ", currentIndex, totalPage);
            return sbFooter.ToString();
        }

        /// <summary>
        /// 产生页码下拉选择列表
        /// </summary>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="totalSize">总条数</param>
        /// <param name="targetUrl">请求的目标地址</param>
        /// <returns></returns>
        private static string GeneratePageSelect(int currentIndex, int pageSize, int totalSize, string targetUrl, bool isByAjax)
        {
            StringBuilder sbPageOptions = new StringBuilder();
            string location = targetUrl.Contains("?") ? string.Format("'{0}&pageIndex=' + this.value", targetUrl) :
                string.Format("'{0}?pageIndex=' + this.value", targetUrl);
            string select = string.Format(isByAjax ? "转到第<select onchange=\"getPageByAjax(this.value)\">@options</select>页" :
                              "转到第<select onchange=\"window.location={0}\">@options</select>页", location);
            int totalPage = Math.Max((totalSize + pageSize - 1) / pageSize, 1); // 总页数

            for (int i = 1; i <= totalPage; i++)
            {
                if (i == currentIndex)
                {
                    sbPageOptions.AppendFormat("<option value=\"{0}\" selected=\"selected\">{0}</option>", i);
                }
                else
                {
                    sbPageOptions.AppendFormat("<option value=\"{0}\">{0}</option>", i);
                }
            }

            select = select.Replace("@options", sbPageOptions.ToString());
            return select;
        }
    }
}