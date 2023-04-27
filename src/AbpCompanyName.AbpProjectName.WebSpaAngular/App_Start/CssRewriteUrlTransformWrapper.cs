using System.Web.Optimization;
using System.Web;

public class CssRewriteUrlTransformWrapper : IItemTransform
{
    public string Process(string includedVirtualPath, string input)
    {
        return new CssRewriteUrlTransform().Process("~" + VirtualPathUtility.ToAbsolute(includedVirtualPath), input);
    }
}